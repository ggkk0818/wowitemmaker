using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using MySQLDriverCS;
using MySql.Data.MySqlClient;
using System.Threading;

namespace WOWItemMaker
{
    public partial class SearchItemsFormcs : Form
    {
        private bool AllSelect;
        private ServerManager sManager;
        private DataSet ItemsSet;
        private int Mail_SearchItemsType;
        private string Mail_SearchItemsStr;
        private Thread GetItemsThread;
        private DataSet _itemsList;

        public DataSet ItemsList
        {
            get { return _itemsList; }
            set { _itemsList = value; }
        }

        public SearchItemsFormcs()
        {
            InitializeComponent();
        }

        private void Mail_SearchItemsBtn_Click(object sender, EventArgs e)
        {
            if (GetItemsThread.ThreadState != ThreadState.Unstarted)
            {
                GetItemsThread = new Thread(new ParameterizedThreadStart(GetItemsDataSet));
                GetItemsThread.IsBackground = true;
            }
            GetItemsThread.Start(ServerManager.MangosDB);
        }

        private void GetItemsDataSet(object mangosDB)
        {
            string SQL = "SELECT entry,name FROM item_template;";
            MyReceiverInvoke mi = new MyReceiverInvoke(invokeDataGridView);
            MySqlConnection Conn = new MySqlConnection(sManager.GetConnStr());
            MySqlCommand chgDB = new MySqlCommand("USE " + mangosDB.ToString() + ";", Conn);
            MySqlCommand setname = new MySqlCommand("set names 'gbk';", Conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(SQL, Conn);
            try
            {
                this.Invoke(mi, new object[] { 1, "正在读取物品信息..." });
                Conn.Open();
                setname.ExecuteNonQuery();
                setname.Dispose();
                chgDB.ExecuteNonQuery();
                chgDB.Dispose();
                ItemsSet = new DataSet();
                adp.Fill(ItemsSet);
                adp.Dispose();
                if (ItemsSet.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("没有找到任何物品！");
                }
                this.Invoke(mi, new object[] { 2, string.Empty });
            }
            catch (Exception err)
            {
                this.Invoke(mi, new object[] { 0, err.Message });
            }
            finally
            {
                Conn.Close();
            }
        }

        private void invokeDataGridView(int type, string str)
        {
            switch (type)
            {
                case 0:
                    if (Mail_SearchItemsDataGridView.Columns.Count > 0)
                    {
                        if (Mail_SearchItemsDataGridView.Columns[0].Name != "ErrorInfo")
                        {
                            Mail_SearchItemsDataGridView.Columns.Clear();
                            Mail_SearchItemsDataGridView.Columns.Add("ErrInfo", "错误信息");
                            Mail_SearchItemsDataGridView.Columns[0].Width = Mail_SearchItemsDataGridView.Width - 10;
                        }
                    }
                    else
                    {
                        Mail_SearchItemsDataGridView.Columns.Add("ErrInfo", "错误信息");
                        Mail_SearchItemsDataGridView.Columns[0].Width = Mail_SearchItemsDataGridView.Width - 10;
                    }
                    Mail_SearchItemsDataGridView.Rows.Clear();
                    Mail_SearchItemsDataGridView.Rows.Add(str);
                    break;
                case 1:
                    if (Mail_SearchItemsDataGridView.Columns.Count > 0)
                    {
                        if (Mail_SearchItemsDataGridView.Columns[0].Name != "Stat")
                        {
                            Mail_SearchItemsDataGridView.Columns.Clear();
                            Mail_SearchItemsDataGridView.Columns.Add("Stat", "当前状态");
                            Mail_SearchItemsDataGridView.Columns[0].Width = Mail_SearchItemsDataGridView.Width - 10;
                        }
                    }
                    else
                    {
                        Mail_SearchItemsDataGridView.Columns.Add("Stat", "当前状态");
                        Mail_SearchItemsDataGridView.Columns[0].Width = Mail_SearchItemsDataGridView.Width - 10;
                    }
                    Mail_SearchItemsDataGridView.Rows.Clear();
                    Mail_SearchItemsDataGridView.Rows.Add(str);
                    break;
                case 2:
                    if (Mail_SearchItemsDataGridView.Columns.Count > 0)
                    {
                        if (Mail_SearchItemsDataGridView.Columns[0].Name != "选择")
                        {
                            Mail_SearchItemsDataGridView.Columns.Clear();
                            DataGridViewTextBoxColumn coln1 = new DataGridViewTextBoxColumn();
                            coln1.Width = 70;
                            coln1.Name = "物品ID";
                            coln1.ReadOnly = true;
                            DataGridViewTextBoxColumn coln2 = new DataGridViewTextBoxColumn();
                            coln2.Width = 80;
                            coln2.Name = "物品名称";
                            coln2.ReadOnly = true;
                            DataGridViewCheckBoxColumn checkboxColn = new DataGridViewCheckBoxColumn();
                            checkboxColn.Width = 50;
                            checkboxColn.Name = "选择";
                            Mail_SearchItemsDataGridView.Columns.Add(checkboxColn);
                            Mail_SearchItemsDataGridView.Columns.Add(coln1);
                            Mail_SearchItemsDataGridView.Columns.Add(coln2);
                        }
                    }
                    else
                    {
                        DataGridViewTextBoxColumn coln1 = new DataGridViewTextBoxColumn();
                        coln1.Width = 70;
                        coln1.Name = "物品ID";
                        coln1.ReadOnly = true;
                        DataGridViewTextBoxColumn coln2 = new DataGridViewTextBoxColumn();
                        coln2.Width = 80;
                        coln2.Name = "物品名称";
                        coln2.ReadOnly = true;
                        DataGridViewCheckBoxColumn checkboxColn = new DataGridViewCheckBoxColumn();
                        checkboxColn.Width = 50;
                        checkboxColn.Name = "选择";
                        Mail_SearchItemsDataGridView.Columns.Add(checkboxColn);
                        Mail_SearchItemsDataGridView.Columns.Add(coln1);
                        Mail_SearchItemsDataGridView.Columns.Add(coln2);

                    }
                    Mail_SearchItemsDataGridView.Rows.Clear();
                    object sender = new object();
                    EventArgs e = new EventArgs();
                    Mail_SearchItemsStrTextBox_TextChanged(sender, e);
                    break;
            }
        }

        private void SearchItemsFormcs_Load(object sender, EventArgs e)
        {
            sManager = new ServerManager();
            this.ItemsList = new DataSet();
            this.ItemsList.Tables.Add("Items");
            this.ItemsList.Tables[0].Columns.Add("entry");
            this.ItemsList.Tables[0].Columns.Add("name");
            Mail_SearchItemsType = int.MaxValue;
            AllSelect = true;
            Mail_SearchItemsStr = string.Empty;
            GetItemsThread = new Thread(new ParameterizedThreadStart(GetItemsDataSet));
            GetItemsThread.IsBackground = true;
            if (Mail_SearchItemsDataGridView.Rows.Count == 0)
            {
                GetItemsThread.Start(ServerManager.MangosDB);
            }
        }

        private void Mail_SearchItemsStrTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Mail_SearchItemsDataGridView.Columns.Count > 0)
            {
                if (Mail_SearchItemsDataGridView.Columns[0].Name == "选择")
                {
                    if (Mail_SearchItemsStrTextBox.Text == string.Empty)
                    {
                        if (ItemsSet != null)
                        {
                            if (ItemsSet.Tables[0].Rows.Count > 0)
                            {
                                Mail_SearchItemsDataGridView.Rows.Clear();
                                foreach (DataRow dr in ItemsSet.Tables[0].Rows)
                                {
                                    Mail_SearchItemsDataGridView.Rows.Add(new object[] { false, dr["entry"].ToString(), dr["name"].ToString() });
                                }
                            }
                        }
                    }
                    else if (ItemsSet != null)
                    {
                        if (ItemsSet.Tables.Count > 0)
                        {
                            if (ItemsSet.Tables[0].Rows.Count > 0)
                            {
                                if (Mail_SearchItemsType < int.MaxValue)
                                {
                                    Mail_SearchItemsDataGridView.Rows.Clear();
                                    foreach (DataRow dr in ItemsSet.Tables[0].Rows)
                                    {
                                        if (dr[Mail_SearchItemsType].ToString().ToLower().IndexOf(Mail_SearchItemsStrTextBox.Text.ToLower()) > -1)
                                        {
                                            Mail_SearchItemsDataGridView.Rows.Add(new object[] { false, dr["entry"].ToString(), dr["name"].ToString() });
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Mail_SearchItemsTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Mail_SearchItemsTypeList.Text)
            {
                case "物品ID":
                    Mail_SearchItemsType = 0;
                    break;
                case "物品名称":
                    Mail_SearchItemsType = 1;
                    break;
            }
            Mail_SearchItemsStrTextBox_TextChanged(sender, e);
        }

        private void Mail_SelectAllBtn_Click(object sender, EventArgs e)
        {
            if (Mail_SearchItemsDataGridView.Columns.Count > 0)
            {
                if (Mail_SearchItemsDataGridView.Columns[0].Name == "选择")
                {
                    foreach (DataGridViewRow dr in Mail_SearchItemsDataGridView.Rows)
                    {
                        dr.Cells[0].Value = AllSelect;
                    }
                    AllSelect = !AllSelect;
                }
            }
        }

        private void Mail_AddItemsToListBtn_Click(object sender, EventArgs e)
        {
            ItemsList.Tables[0].Rows.Clear();
            if (Mail_SearchItemsDataGridView.Rows.Count > 0)
            {
                if (Mail_SearchItemsDataGridView.Columns[0].Name == "选择")
                {
                    foreach (DataGridViewRow dr in Mail_SearchItemsDataGridView.Rows)
                    {
                        if ((bool)dr.Cells[0].Value == true)
                        {
                            ItemsList.Tables[0].Rows.Add(new object[] { dr.Cells[1].Value.ToString(), dr.Cells[2].Value.ToString() });
                        }
                    }
                }
            }
            this.Close();
        }

    }
}
