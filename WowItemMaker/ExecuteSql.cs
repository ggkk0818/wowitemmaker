using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Threading;

namespace WOWItemMaker
{
    public partial class ExecuteSql : Form
    {
        public DataSet[] ResaultDataSet;
        int RowsPerPage = 500;
        public ExecuteSql()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExecuteBtn_Click(object sender, EventArgs e)
        {
            //ExecuteBtn.Enabled = false;
            string[] sql = GetValues("[^\\n\\r;]+;", SqlTextBox.Text.Trim());
            if (sql != null)
            {
                ResaultList.Items.Clear();
                ExecuteBtn.Enabled = false;
                BackBtn.Enabled = false;
                NextBtn.Enabled = false;
                PageList.Enabled = false;
                ResaultList.Enabled = false;
                Thread Exec = new Thread(new ParameterizedThreadStart(Execute));
                Exec.IsBackground = true;
                Exec.Start();
            }
            else
            {
                toolTip1.Show("命令没有执行？看一看结尾处是否加上了分号！", this, SqlTextBox.Location.X + SqlTextBox.Width / 2, SqlTextBox.Location.Y + SqlTextBox.Height+30);
            }
        }
        private void Execute(object sender)
        {
            MyInvoke mi = new MyInvoke(miExecute);
            string[] SQLS = GetValues("[^\\n\\r;]+;", SqlTextBox.Text.Trim());
            MySqlConnection Conn = new MySqlConnection(MainForm.GetConnStr());
            MySqlCommand setname = new MySqlCommand("set names 'gbk';", Conn);
            ResaultDataSet = new DataSet[SQLS.Length];
            try
            {
                Conn.Open();
                setname.ExecuteNonQuery();
                setname.Dispose();
                //ResaultList.Items.Clear();
                for(int i=0;i<SQLS.Length;i++)
                {
                    try
                    {
                        MySqlDataAdapter adp = new MySqlDataAdapter(SQLS[i].ToString(), Conn);
                        ResaultDataSet[i] = new DataSet();
                        adp.Fill(ResaultDataSet[i]);
                        //ResaultList.Items.Add((i+1).ToString() + "-成功");
                        this.Invoke(mi, (i + 1).ToString() + "-成功");
                    }
                    catch(Exception err)
                    {
                        ResaultDataSet[i].Tables.Add(new DataTable("ExecuteResault"));
                        if (err.Message.ToString() == "值不能为空。\r\n参数名: dataReader")
                        {
                            ResaultDataSet[i].Tables[0].Columns.Add("执行结果");
                            ResaultDataSet[i].Tables[0].Rows.Add("命令成功完成。");
                            //ResaultList.Items.Add((i+1).ToString() + "-成功");
                            this.Invoke(mi, (i + 1).ToString() + "-成功");
                        }
                        else
                        {
                            ResaultDataSet[i].Tables[0].Columns.Add("错误信息");
                            ResaultDataSet[i].Tables[0].Rows.Add(new object[] { err.Message });
                            //ResaultList.Items.Add((i+1).ToString() + "-失败");
                            this.Invoke(mi, (i + 1).ToString() + "-失败");
                        }
                    }
                }
            }
            catch (Exception err)
            {
                ResaultDataSet[0] = new DataSet();
                ResaultDataSet[0].Tables.Add();
                ResaultDataSet[0].Tables[0].Columns.Add("错误信息");
                ResaultDataSet[0].Tables[0].Rows.Add(new object[] { err.Message });
                //dataGridView1.Columns.Clear();
                //dataGridView1.Rows.Clear();
                //dataGridView1.Columns.Add("ErrInfo", "错误信息");
                //dataGridView1.Rows.Add(err.Message.ToString());
                this.Invoke(mi, "出现错误");
            }
            //ResaultList.SelectedItem = ResaultList.Items[0];
            //ExecuteBtn.Enabled = true;
            this.Invoke(mi, "ExecuteFinished");
        }

        private void miExecute(string str)
        {
            if (str == "ExecuteFinished")
            {
                ResaultList.SelectedItem = ResaultList.Items[0];
                ExecuteBtn.Enabled = true;
                ResaultList.Enabled = true;
            }
            else
                ResaultList.Items.Add(str);
        }
        private void GetSqls()
        {
            string[] Sql = GetValues("[^\\n\\r;]+;", SqlTextBox.Text.Trim());
            string msg=null;
            if (Sql != null)
            {
                foreach (string sqlstring in Sql)
                {
                    msg += sqlstring + "\r\n";
                }
            }
            MessageBox.Show(msg);
        }
        public string[] GetValues(string pattern, string TextBox)
        {
            string[] re = null;
            try
            {
                Regex TestReg = new Regex(pattern);
                MatchCollection Resaults = TestReg.Matches(TextBox);
                re = new string[Resaults.Count];
                if (Resaults.Count > 0)
                {
                    for (int i = 0; i < Resaults.Count; i++)
                    {
                        re[i] = Resaults[i].Value;
                    }
                }
                else
                {
                    re = null;
                }
            }
            catch(Exception err)
            {
                re = null;
            }
            return re;
        }

        private void ResaultList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainForm f1 = new MainForm();
            if(f1.GetValue("\\d+",RowsPerPageTextBox.Text).Length>0)
                RowsPerPage = Convert.ToInt32(f1.GetValue("\\d+",RowsPerPageTextBox.Text));
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            if (ResaultDataSet[ResaultList.SelectedIndex].Tables.Count > 0)
            {
                foreach (DataColumn dc in ResaultDataSet[ResaultList.SelectedIndex].Tables[0].Columns)
                {
                    dataGridView1.Columns.Add(dc.ColumnName.ToString(), dc.ColumnName.ToString());
                }
                if (ResaultDataSet[ResaultList.SelectedIndex].Tables[0].Rows.Count > 0)
                {
                    if (ResaultDataSet[ResaultList.SelectedIndex].Tables[0].Rows.Count > RowsPerPage)
                    {
                        PageList.Items.Clear();
                        GetPage(ResaultList.SelectedIndex);
                        PageList.SelectedItem = PageList.Items[0];
                        PageList.Enabled = true;
                    }
                    else
                    {
                        foreach (DataRow dr in ResaultDataSet[ResaultList.SelectedIndex].Tables[0].Rows)
                        {
                            object[] dtrow = new object[dr.Table.Columns.Count];
                            for (int ii = 0; ii < dr.Table.Columns.Count; ii++)
                            {
                                if (dr[ii] == DBNull.Value)
                                {
                                    dtrow[ii] = "null";
                                }
                                else
                                {
                                    dtrow[ii] = dr[ii].ToString();
                                }
                            }
                            dataGridView1.Rows.Add(dtrow);
                        }
                        BackBtn.Enabled = false;
                        NextBtn.Enabled = false;
                        PageList.Enabled = false;
                    }
                }
                else
                {
                    dataGridView1.Rows.Add("没有记录。");
                }
                ResaultStatLabel.Text = "返回" + ResaultDataSet[ResaultList.SelectedIndex].Tables[0].Columns.Count.ToString() + "列" + ResaultDataSet[ResaultList.SelectedIndex].Tables[0].Rows.Count.ToString() + "行数据。";
            }
            else
            {
                dataGridView1.Columns.Add("column1", string.Empty);
                dataGridView1.Rows.Add("没有返回数据。");
            }
        }

        private void GetPage(int ResaultIndex)
        {
            int Rows = ResaultDataSet[ResaultIndex].Tables[0].Rows.Count;
            int PageCount = Rows / RowsPerPage;
            if ((Rows % RowsPerPage) > 0)
                PageCount++;
            for (int i = 0; i < PageCount; i++)
            {
                PageList.Items.Add((i + 1).ToString());
            }
        }

        private void ExecuteSql_Load(object sender, EventArgs e)
        {

        }

        private void PageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = PageList.SelectedIndex * RowsPerPage; i < (PageList.SelectedIndex + 1) * RowsPerPage; i++)
            {
                if (i > (ResaultDataSet[ResaultList.SelectedIndex].Tables[0].Rows.Count - 1))
                    break;
                object[] dtrow = new object[ResaultDataSet[ResaultList.SelectedIndex].Tables[0].Columns.Count];
                for (int ii = 0; ii < ResaultDataSet[ResaultList.SelectedIndex].Tables[0].Columns.Count; ii++)
                {
                    if (ResaultDataSet[ResaultList.SelectedIndex].Tables[0].Rows[i][ii] == DBNull.Value)
                    {
                        dtrow[ii] = "null";
                    }
                    else
                    {
                        dtrow[ii] = ResaultDataSet[ResaultList.SelectedIndex].Tables[0].Rows[i][ii].ToString();
                    }
                }
                dataGridView1.Rows.Add(dtrow);
            }
            if (PageList.SelectedIndex == 0)
                BackBtn.Enabled = false;
            else
                BackBtn.Enabled = true;
            if (PageList.SelectedIndex == (PageList.Items.Count - 1))
                NextBtn.Enabled = false;
            else
                NextBtn.Enabled = true;
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            try
            {
                PageList.SelectedItem = PageList.Items[PageList.SelectedIndex - 1];
            }
            catch
            {
                MessageBox.Show("页码出错！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            try
            {
                PageList.SelectedItem = PageList.Items[PageList.SelectedIndex + 1];
            }
            catch
            {
                MessageBox.Show("页码出错！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RowsPerPageTextBox_TextChanged(object sender, EventArgs e)
        {
            MainForm f1 = new MainForm();
            if (f1.GetValue("\\d+", RowsPerPageTextBox.Text).Length > 0)
            {
                if (Convert.ToInt32(f1.GetValue("\\d+", RowsPerPageTextBox.Text)) > 1000)
                    toolTip1.Show("每页显示数量过多容易导致程序无响应，建议不要超过500", this, RowsPerPageTextBox.Location.X, RowsPerPageTextBox.Location.Y + RowsPerPageTextBox.Height+30);
            }
        }

    }
    public class ResaultClass
    {
        private static DataSet[] _ResaultDataSet;

        public static DataSet[] ResaultDataSet
        {
            get { return ResaultClass._ResaultDataSet; }
            set { ResaultClass._ResaultDataSet = value; }
        }

    }
}
