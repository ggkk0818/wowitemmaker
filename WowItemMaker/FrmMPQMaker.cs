using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;
using System.IO;

namespace WOWItemMaker
{
    public partial class FrmMPQMaker : Form
    {
        private string fileName;
        private Thread myThread;
        public FrmMPQMaker()
        {
            InitializeComponent();
        }

        private void FrmMPQMaker_Load(object sender, EventArgs e)
        {
            fileName = Application.StartupPath + @"\patch-zhTW-6.MPQ";
            TXT_FileName.Text = fileName;
            saveFileDialog1.InitialDirectory = Application.StartupPath;
        }

        private void Btn_OpenDialog_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            fileName = saveFileDialog1.FileName;
            TXT_FileName.Text = saveFileDialog1.FileName;
        }

        private void Btn_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            if (Btn_Ok.Text == "取消" && myThread != null && myThread.ThreadState != ThreadState.Stopped)
            {
                myThread.Abort();
                LB_State.Text = "已取消";
                Btn_Ok.Text = "开始";
            }
            else if (Btn_Ok.Text == "开始")
            {
                myThread = new Thread(new ParameterizedThreadStart(DoMakeMPQ));
                myThread.Start();
                Btn_Ok.Text = "取消";
            }
        }

        void DoMakeMPQ(object param)
        {
            MyInvoke miUI = new MyInvoke(miUpdateUI);
            MyInvoke miFin = new MyInvoke(miFinish);
            string sql = string.Empty;
            if (ConnInfo.Dbstruct == "3.3.5(TC2)")
            {
                sql = "SELECT entry,class,subclass,SoundOverrideSubclass,material,displayid,InventoryType,sheath FROM item_template ORDER BY entry ASC;";
            }
            //else if (ConnInfo.Dbstruct == "3.1.X")
            //{
            //    sql = "SELECT entry,displayid,InventoryType,sheath FROM item_template ORDER BY entry ASC;";
            //}
            else
            {
                sql = "SELECT entry,class,subclass,unk0,material,displayid,InventoryType,sheath FROM item_template ORDER BY entry ASC;";
            }
            DataSet ds = new DataSet();
            MySqlConnection Conn = new MySqlConnection(MainForm.GetConnStr());
            MySqlCommand setname = new MySqlCommand("set names 'gbk';", Conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(sql, Conn);
            this.Invoke(miUI, "查询物品信息...");
            try
            {
                Conn.Open();
                adp.Fill(ds);
            }
            catch (ThreadAbortException err)
            {
                return;
            }
            catch (Exception err)
            {
                this.Invoke(miFin, "无法查询物品信息。" + err.Message);
                return;
            }
            finally
            {
                Conn.Close();
            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count < 1)
                {
                    this.Invoke(miFin, "没有任何物品信息，操作已终止。");
                    return;
                }
            }
            else
            {
                this.Invoke(miFin, "查询物品信息发生错误。");
                return;
            }
            string mastdbcfilename = Application.StartupPath + @"\Data\Item.dbc";
            string dbcfilename = Application.StartupPath + @"\Item.dbc";
            this.Invoke(miUI, "筛选自定义物品...");
            DataTable dt_items = null;
            if (File.Exists(mastdbcfilename))
            {
                DataTable dt_mastitems = null;
                DataTable dt_additems = new DataTable();
                try
                {
                    dt_mastitems = LibDBC.GetData(mastdbcfilename);
                    //if (dt_mastitems.Rows.Count == 0 || dt_mastitems.Columns.Count != 8)
                    if (dt_mastitems.Columns.Count != ds.Tables[0].Columns.Count)
                    {
                        this.Invoke(miFin, "Item.dbc格式不正确。\r\n请从服务端dbc目录拷贝此文件到软件Data目录下。");
                        return;
                    }
                    foreach (DataColumn dc in dt_mastitems.Columns)
                    {
                        dt_additems.Columns.Add(dc.ColumnName, dc.DataType);
                    }
                }
                catch (Exception err)
                {
                    this.Invoke(miFin, "无法读取Item.dbc。" + err.Message + "\r\n请从服务端dbc目录拷贝此文件到软件Data目录下。");
                    return;
                }
                try
                {
                    int rowIndex = 0;
                    dt_mastitems.DefaultView.Sort = dt_mastitems.Columns[0].ColumnName + " ASC";
                    dt_mastitems = dt_mastitems.DefaultView.ToTable();
                    for (int i = 0; i < dt_mastitems.Rows.Count; i++)
                    {
                        if (i >= dt_mastitems.Rows.Count)
                            break;
                        this.Invoke(miUI, "筛选自定义物品..." + (i * 100 / dt_mastitems.Rows.Count).ToString() + "%");
                        DataRow curdr = dt_mastitems.Rows[i];
                        bool isExists = false;
                        for (int j = rowIndex; j < ds.Tables[0].Rows.Count; j++)
                        {
                            DataRow dr = ds.Tables[0].Rows[j];
                            if (int.Parse(dr[0].ToString()) > int.Parse(curdr[0].ToString()))
                                break;
                            if (curdr[0].ToString() == dr[0].ToString())
                            {
                                isExists = true;
                                rowIndex = j + 1;
                                break;
                            }
                        }
                        if (!isExists)
                        {
                            dt_additems.Rows.Add(curdr.ItemArray);
                        }
                    }
                    foreach (DataRow dr in dt_additems.Rows)
                    {
                        ds.Tables[0].Rows.Add(dr.ItemArray);
                    }
                    ds.Tables[0].DefaultView.Sort = ds.Tables[0].Columns[0].ColumnName + " ASC";
                    dt_items = ds.Tables[0].DefaultView.ToTable();
                }
                catch (ThreadAbortException err)
                {
                    return;
                }
            }
            else
            {
                this.Invoke(miFin, "文件Item.dbc不存在。\r\n请从服务端dbc目录拷贝此文件到软件Data目录下。");
                return;
            }
            this.Invoke(miUI, "生成DBC文件...");
            try
            {
                LibDBC.SaveData(dbcfilename, dt_items);
            }
            catch (ThreadAbortException err)
            {
                return;
            }
            catch (Exception err)
            {
                this.Invoke(miFin, "无法生成DBC文件。" + err.Message);
                return;
            }
            if (File.Exists(this.fileName))
            {
                try
                {
                    File.Delete(this.fileName);
                }
                catch (ThreadAbortException err)
                {
                    return;
                }
                catch (Exception err)
                {
                    this.Invoke(miFin, "无法替换保存位置的文件。" + err.Message);
                    return;
                }
            }
            try
            {
                int handle = -1;
                int pro = 0x00030200;
                bool b = false;
                handle = LibMPQ.MpqOpenArchiveForUpdate(this.fileName, 1, 4096);
                if (handle > 0)
                {
                    b = LibMPQ.MpqAddFileToArchive(handle, dbcfilename, @"DBFilesClient\Item.dbc", pro);
                    if (!b)
                    {
                        this.Invoke(miFin, "无法对MPQ添加Item.dbc文件。");
                        return;
                    }

                    b = LibMPQ.MpqCompactArchive(handle);
                    if (!b)
                    {
                        this.Invoke(miFin, "无法编译MPQ文件。");
                        return;
                    }
                    b = LibMPQ.SFileCloseArchive(handle);
                    if (!b)
                    {
                        this.Invoke(miFin, "无法关闭MPQ文件。");
                        return;
                    }
                    try
                    {
                        File.Delete(dbcfilename);
                    }
                    catch
                    { }
                    this.Invoke(miFin, "success");
                    return;
                }
                else
                {
                    this.Invoke(miFin, "获取文件指针错误。");
                    return;
                }
            }
            catch (ThreadAbortException err)
            {
                return;
            }
            catch (Exception err)
            {
                this.Invoke(miFin, "无法生成MPQ文件。" + err.Message);
                return;
            }

        }

        void miUpdateUI(string str)
        {
            LB_State.Text = str;
        }

        void miFinish(string str)
        {
            LB_State.Text = string.Empty;
            Btn_Ok.Text = "开始";
            if (str == "success")
                MessageBox.Show("生成成功！", "问号补丁", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(str, "问号补丁", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmMPQMaker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Btn_Ok.Text == "取消" && myThread != null && myThread.ThreadState != ThreadState.Stopped)
            {
                myThread.Abort();
            }

        }

        private void TXT_FileName_Leave(object sender, EventArgs e)
        {
            if (!Directory.Exists(Path.GetDirectoryName(TXT_FileName.Text)))
            {
                MessageBox.Show("该路径不存在！", "问号补丁", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TXT_FileName.Focus();
            }
        }
    }
}
