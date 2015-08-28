using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
//using MySQLDriverCS;
using MySql.Data.MySqlClient;

namespace WOWItemMaker
{
    public delegate void OnEditBtnClick(string str);
    public partial class Search : Form
    {
        public event OnEditBtnClick OnEdit;
        public event OnEditBtnClick OnDel;
        public string[] AllAccord=new string[2];
        public DataSet SearchResault;
        public int RowsPerPage = 500;
        public Search()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            dataGridView1.Columns.Add("Entry", "物品ID");
            dataGridView1.Columns.Add("Name", "物品名称");
            dataGridView1.Columns.Add("DisplayId", "模型ID");
            DataGridViewButtonColumn BtnColumn1 = new DataGridViewButtonColumn();
            BtnColumn1.Name = "Edit";
            BtnColumn1.HeaderText = "";
            dataGridView1.Columns.Add(BtnColumn1);
            DataGridViewButtonColumn BtnColumn2 = new DataGridViewButtonColumn();
            BtnColumn2.Name = "Del";
            BtnColumn2.HeaderText = "";
            dataGridView1.Columns.Add(BtnColumn2);
            AllAccord[0] = "like";
            AllAccord[1] = "%";
        }

        void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (-1 < e.RowIndex && e.RowIndex < dataGridView1.Rows.Count)
            {
                if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "编辑")
                {
                    OnEdit(this.dataGridView1.Rows[e.RowIndex].Cells["Entry"].Value.ToString());
                }
                else if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "删除")
                {
                    OnDel(this.dataGridView1.Rows[e.RowIndex].Cells["Entry"].Value.ToString());
                }
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            MainForm f1 = new MainForm();
            if (f1.GetValue("\\d+", RowsPerPageTextBox.Text).Length > 0)
                RowsPerPage = Convert.ToInt32(f1.GetValue("\\d+", RowsPerPageTextBox.Text));
            SearchBtn.Enabled = false;
            PageList.Enabled = false;
            BackBtn.Enabled = false;
            NextBtn.Enabled = false;
            PageList.Items.Clear();
            Thread SearchThread = new Thread(new ParameterizedThreadStart(SearchItem));
            SearchThread.IsBackground = true;
            if (ItemNameTextBox.Text.Trim().Length > 0)
            {
                SearchThread.Start(ItemNameTextBox.Text.Trim());
            }
            else
            {
                SearchThread.Start("%");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                AllAccord[0] = "=";
                AllAccord[1] = "";
            }
            else
            {
                AllAccord[0] = "like";
                AllAccord[1] = "%";
            }
        }
        public void SearchItem(object key)
        {
            key = key.ToString().Replace("'", "''");
            string SQL = "select entry,name,displayid from item_template where name " + AllAccord[0] + " '"+AllAccord[1] + key.ToString() + AllAccord[1]+"';";
            MyInvoke end = new MyInvoke(miEND);
            SearchResault = new DataSet();
            MySqlConnection Conn = new MySqlConnection(MainForm.GetConnStr());
            MySqlCommand setname = new MySqlCommand("set names 'gbk';", Conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(SQL.ToString(), Conn);
            try
            {
                Conn.Open();
                setname.ExecuteNonQuery();
                setname.Dispose();
                adp.Fill(SearchResault);
                this.Invoke(end, "true");
            }
            catch (Exception err)
            {
                this.Invoke(end, err.Message);
            }
        }
        private void miEND(string re)
        {
            dataGridView1.Rows.Clear();
            if (re == "true")
            {
                if (SearchResault.Tables[0].Rows.Count > 0)
                {
                    if (SearchResault.Tables[0].Rows.Count > RowsPerPage)
                    {
                        GetPage();
                        PageList.SelectedItem = PageList.Items[0];
                        PageList.Enabled = true;
                    }
                    else
                    {
                        PageList.Enabled = false;
                        BackBtn.Enabled = false;
                        NextBtn.Enabled = false;
                        foreach (DataRow dr in SearchResault.Tables[0].Rows)
                        {
                            object[] dtrow = new object[dr.Table.Columns.Count + 2];
                            int ii = 0;
                            for (ii = 0; ii < dr.Table.Columns.Count; ii++)
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
                            dtrow[ii] = "编辑";
                            dtrow[ii + 1] = "删除";
                            dataGridView1.Rows.Add(dtrow);
                        }
                    }
                }
                else
                {
                    dataGridView1.Rows.Add(new object[] {"没有找到物品。","","","",""});
                }
            }
            else
            {
                MessageBox.Show(re, "物品搜索", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SearchBtn.Enabled = true;
        }

        private void GetPage()
        {
            int Rows = SearchResault.Tables[0].Rows.Count;
            int PageCount = Rows / RowsPerPage;
            if ((Rows % RowsPerPage) > 0)
                PageCount++;
            for (int i = 0; i < PageCount; i++)
            {
                PageList.Items.Add((i + 1).ToString());
            }
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

        private void PageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = PageList.SelectedIndex * RowsPerPage; i < (PageList.SelectedIndex + 1) * RowsPerPage; i++)
            {
                if (i > (SearchResault.Tables[0].Rows.Count - 1))
                    break;
                object[] dtrow = new object[SearchResault.Tables[0].Columns.Count + 2];
                int ii = 0;
                for (ii = 0; ii < SearchResault.Tables[0].Columns.Count; ii++)
                {
                    if (SearchResault.Tables[0].Rows[i][ii] == DBNull.Value)
                    {
                        dtrow[ii] = "null";
                    }
                    else
                    {
                        dtrow[ii] = SearchResault.Tables[0].Rows[i][ii].ToString();
                    }
                }
                dtrow[ii] = "编辑";
                dtrow[ii + 1] = "删除";
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

        private void RowsPerPageTextBox_TextChanged(object sender, EventArgs e)
        {
            MainForm f1 = new MainForm();
            if (f1.GetValue("\\d+", RowsPerPageTextBox.Text).Length > 0)
            {
                if (Convert.ToInt32(f1.GetValue("\\d+", RowsPerPageTextBox.Text)) > 1000)
                    toolTip1.Show("每页显示数量过多容易导致程序无响应，建议不要超过500", this, RowsPerPageTextBox.Location.X, RowsPerPageTextBox.Location.Y + RowsPerPageTextBox.Height + 30);
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
    }
}
