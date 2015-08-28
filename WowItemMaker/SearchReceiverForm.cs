using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
//using MySQLDriverCS;
using MySql.Data.MySqlClient;
using System.Threading;

namespace WOWItemMaker
{
    public delegate void MyReceiverInvoke(int type, string str);
    public partial class SearchReceiverForm : Form
    {
        private DataSet _receiverList;

        public DataSet ReceiverList
        {
            get { return _receiverList; }
            set { _receiverList = value; }
        }

        private DataSet ReceiverAccountSet;
        private DataSet ReceiverListSet;
        private ServerManager sManager;
        private Thread GetReceiverThread;
        private string ReceiverType;
        private bool AllSelect;
        private int Mail_SearchReceiverType;

        public SearchReceiverForm()
        {
            InitializeComponent();
        }

        private void SearchReceiverFrom_Load(object sender, EventArgs e)
        {
            ReceiverType = string.Empty;
            Mail_SearchReceiverType = int.MaxValue;
            sManager = new ServerManager();
            this.ReceiverList = new DataSet();
            this.ReceiverList.Tables.Add("Receivers");
            this.ReceiverList.Tables[0].Columns.Add("AccountID");
            this.ReceiverList.Tables[0].Columns.Add("AccountName");
            this.ReceiverList.Tables[0].Columns.Add("CharacterID");
            this.ReceiverList.Tables[0].Columns.Add("CharacterName");
            AllSelect = true;
            GetReceiverThread = new Thread(new ParameterizedThreadStart(GetReceiverDataSet));
            GetReceiverThread.IsBackground = true;
            if (Mail_SearchReceiverDataGridView.Rows.Count == 0)
            {
                GetReceiverThread.Start(ServerManager.RealmdDB + "|" + ServerManager.CharactersDB);
            }
        }

        public void ShowReceiver(int Type)
        {

        }

        public void GetReceiverDataSet(object Database)
        {
            int splitPos = Database.ToString().IndexOf("|");
            string accountDatabase = Database.ToString().Substring(0, splitPos);
            string charactersDatabase = Database.ToString().Substring(splitPos + 1, Database.ToString().Length - splitPos - 1);
            string SQL = "SELECT id,username FROM account;";
            MyReceiverInvoke mi = new MyReceiverInvoke(invokeDataGridView);
            MySqlConnection Conn = new MySqlConnection(sManager.GetConnStr());
            MySqlCommand setname = new MySqlCommand("set names 'gbk';", Conn);
            MySqlCommand chgDB = new MySqlCommand("USE " + accountDatabase.ToString() + ";", Conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(SQL, Conn);
            try
            {
                this.Invoke(mi, new object[] { 1, "正在读取账号信息..." });
                Conn.Open();
                setname.ExecuteNonQuery();
                setname.Dispose();
                chgDB.ExecuteNonQuery();
                chgDB.Dispose();
                ReceiverAccountSet = new DataSet();
                adp.Fill(ReceiverAccountSet);
                adp.Dispose();
                if (ReceiverAccountSet.Tables[0].Rows.Count > 0)
                {
                    this.Invoke(mi, new object[] { 1, "正在读取对应角色信息..." });
                    chgDB = new MySqlCommand("USE " + charactersDatabase.ToString() + ";", Conn);
                    chgDB.ExecuteNonQuery();
                    chgDB.Dispose();
                    ReceiverListSet = new DataSet();
                    ReceiverListSet.Tables.Add("Receivers");
                    ReceiverListSet.Tables[0].Columns.Add("AccountID");
                    ReceiverListSet.Tables[0].Columns.Add("AccountName");
                    ReceiverListSet.Tables[0].Columns.Add("CharacterID");
                    ReceiverListSet.Tables[0].Columns.Add("CharacterName");
                }
                else
                {
                    throw new Exception("没有找到任何账号！");
                }
                int CurrentAccount = 1;
                int TotalAccount = ReceiverAccountSet.Tables[0].Rows.Count;
                for (int i = 0; i < ReceiverAccountSet.Tables[0].Rows.Count; i++)
                {
                    this.Invoke(mi, new object[] { 1, "正在读取对应角色信息..." + i.ToString() + "/" + TotalAccount.ToString() });
                    adp = new MySqlDataAdapter("SELECT guid,name FROM characters WHERE account ='"+ReceiverAccountSet.Tables[0].Rows[i]["id"].ToString()+"';", Conn);
                    DataSet CurrentCharacter = new DataSet();
                    adp.Fill(CurrentCharacter);
                    if (CurrentCharacter.Tables[0].Rows.Count > 0)
                    {
                        for (int cCharacter = 0; cCharacter < CurrentCharacter.Tables[0].Rows.Count; cCharacter++)
                        {
                            ReceiverListSet.Tables[0].Rows.Add(new object[] { 
                                ReceiverAccountSet.Tables[0].Rows[i]["id"].ToString(), 
                                ReceiverAccountSet.Tables[0].Rows[i]["username"].ToString(), 
                                CurrentCharacter.Tables[0].Rows[cCharacter]["guid"].ToString(), 
                                CurrentCharacter.Tables[0].Rows[cCharacter]["name"].ToString() });
                        }
                        CurrentAccount++;
                    }
                }
                if (CurrentAccount == 1)
                {
                    this.Invoke(mi, new object[] { 1, "没有找到任何角色！" });
                }
                else
                {
                    this.Invoke(mi, new object[] { 2, string.Empty });
                }
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
                    if (Mail_SearchReceiverDataGridView.Columns.Count > 0)
                    {
                        if (Mail_SearchReceiverDataGridView.Columns[0].Name != "ErrorInfo")
                        {
                            Mail_SearchReceiverDataGridView.Columns.Clear();
                            Mail_SearchReceiverDataGridView.Columns.Add("ErrInfo", "错误信息");
                            Mail_SearchReceiverDataGridView.Columns[0].Width = Mail_SearchReceiverDataGridView.Width - 10;
                        }
                    }
                    else
                    {
                        Mail_SearchReceiverDataGridView.Columns.Add("ErrInfo", "错误信息");
                        Mail_SearchReceiverDataGridView.Columns[0].Width = Mail_SearchReceiverDataGridView.Width - 10;
                    }
                    Mail_SearchReceiverDataGridView.Rows.Clear();
                    Mail_SearchReceiverDataGridView.Rows.Add(str);
                    break;
                case 1:
                    if (Mail_SearchReceiverDataGridView.Columns.Count > 0)
                    {
                        if (Mail_SearchReceiverDataGridView.Columns[0].Name != "Stat")
                        {
                            Mail_SearchReceiverDataGridView.Columns.Clear();
                            Mail_SearchReceiverDataGridView.Columns.Add("Stat", "当前状态");
                            Mail_SearchReceiverDataGridView.Columns[0].Width = Mail_SearchReceiverDataGridView.Width - 10;
                        }
                    }
                    else
                    {
                        Mail_SearchReceiverDataGridView.Columns.Add("Stat", "当前状态");
                        Mail_SearchReceiverDataGridView.Columns[0].Width = Mail_SearchReceiverDataGridView.Width - 10;
                    }
                    Mail_SearchReceiverDataGridView.Rows.Clear();
                    Mail_SearchReceiverDataGridView.Rows.Add(str);
                    break;
                case 2:
                    if (Mail_SearchReceiverDataGridView.Columns.Count > 0)
                    {
                        if (Mail_SearchReceiverDataGridView.Columns[0].Name != "checkColn")
                        {
                            Mail_SearchReceiverDataGridView.Columns.Clear();
                            DataGridViewTextBoxColumn coln1 = new DataGridViewTextBoxColumn();
                            coln1.Width = 70;
                            coln1.Name = "账号ID";
                            coln1.ReadOnly = true;
                            DataGridViewTextBoxColumn coln2 = new DataGridViewTextBoxColumn();
                            coln2.Width = 80;
                            coln2.Name = "账号名称";
                            coln2.ReadOnly = true;
                            DataGridViewTextBoxColumn coln3 = new DataGridViewTextBoxColumn();
                            coln3.Width = 70;
                            coln3.Name = "角色ID";
                            coln3.ReadOnly = true;
                            DataGridViewTextBoxColumn coln4 = new DataGridViewTextBoxColumn();
                            coln4.Width = 80;
                            coln4.Name = "角色名称";
                            coln4.ReadOnly = true;
                            DataGridViewCheckBoxColumn checkboxColn = new DataGridViewCheckBoxColumn();
                            checkboxColn.Width = 50;
                            checkboxColn.Name = "选择";
                            Mail_SearchReceiverDataGridView.Columns.Add(checkboxColn);
                            Mail_SearchReceiverDataGridView.Columns.Add(coln1);
                            Mail_SearchReceiverDataGridView.Columns.Add(coln2);
                            Mail_SearchReceiverDataGridView.Columns.Add(coln3);
                            Mail_SearchReceiverDataGridView.Columns.Add(coln4);
                        }
                    }
                    else
                    {
                        DataGridViewTextBoxColumn coln1 = new DataGridViewTextBoxColumn();
                        coln1.Width = 70;
                        coln1.Name = "账号ID";
                        coln1.ReadOnly = true;
                        DataGridViewTextBoxColumn coln2 = new DataGridViewTextBoxColumn();
                        coln2.Width = 80;
                        coln2.Name = "账号名称";
                        coln2.ReadOnly = true;
                        DataGridViewTextBoxColumn coln3 = new DataGridViewTextBoxColumn();
                        coln3.Width = 70;
                        coln3.Name = "角色ID";
                        coln3.ReadOnly = true;
                        DataGridViewTextBoxColumn coln4 = new DataGridViewTextBoxColumn();
                        coln4.Width = 80;
                        coln4.Name = "角色名称";
                        coln4.ReadOnly = true;
                        DataGridViewCheckBoxColumn checkboxColn = new DataGridViewCheckBoxColumn();
                        checkboxColn.Width = 50;
                        checkboxColn.Name = "选择";
                        Mail_SearchReceiverDataGridView.Columns.Add(checkboxColn);
                        Mail_SearchReceiverDataGridView.Columns.Add(coln1);
                        Mail_SearchReceiverDataGridView.Columns.Add(coln2);
                        Mail_SearchReceiverDataGridView.Columns.Add(coln3);
                        Mail_SearchReceiverDataGridView.Columns.Add(coln4);
                    }
                    object sender = new object();
                    EventArgs e = new EventArgs();
                    Mail_SearchReceiverStrTextBox_TextChanged(sender,e);
                    break;
            }
        }

        private void Mail_RefreshReceiverBtn_Click(object sender, EventArgs e)
        {
            if (GetReceiverThread.ThreadState != ThreadState.Unstarted)
            {
                GetReceiverThread.Abort();
                GetReceiverThread = new Thread(new ParameterizedThreadStart(GetReceiverDataSet));
                GetReceiverThread.IsBackground = true;
            }
            GetReceiverThread.Start(ServerManager.RealmdDB + "|" + ServerManager.CharactersDB);
        }

        private void Mail_SelectAllReceiverBtn_Click(object sender, EventArgs e)
        {
            if (Mail_SearchReceiverDataGridView.Columns.Count > 0)
            {
                if (Mail_SearchReceiverDataGridView.Columns[0].Name == "选择")
                {
                    foreach (DataGridViewRow dr in Mail_SearchReceiverDataGridView.Rows)
                    {
                        dr.Cells[0].Value = AllSelect;
                    }
                    AllSelect = !AllSelect;
                }
            }
        }

        private void Mail_AddReceiverToListBtn_Click(object sender, EventArgs e)
        {
            ReceiverList.Tables[0].Rows.Clear();
            if (Mail_SearchReceiverDataGridView.Rows.Count > 0)
            {
                if (Mail_SearchReceiverDataGridView.Columns[0].Name == "选择")
                {
                    foreach (DataGridViewRow dr in Mail_SearchReceiverDataGridView.Rows)
                    {
                        if ((bool)dr.Cells[0].Value == true)
                        {
                            ReceiverList.Tables[0].Rows.Add(new object[] { dr.Cells[1].Value.ToString(), dr.Cells[2].Value.ToString(), dr.Cells[3].Value.ToString(), dr.Cells[4].Value.ToString() });
                        }
                    }
                }
            }
            this.Close();
        }

        private void Mail_SearchReceiverStrTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Mail_SearchReceiverDataGridView.Columns.Count > 0)
            {
                if (Mail_SearchReceiverDataGridView.Columns[0].Name == "选择")
                {
                    if (Mail_SearchReceiverStrTextBox.Text == string.Empty)
                    {
                        if (ReceiverListSet != null)
                        {
                            if (ReceiverListSet.Tables[0].Rows.Count > 0)
                            {
                                Mail_SearchReceiverDataGridView.Rows.Clear();
                                foreach (DataRow dr in ReceiverListSet.Tables[0].Rows)
                                {
                                    Mail_SearchReceiverDataGridView.Rows.Add(new object[] { false, dr["AccountID"].ToString(), dr["AccountName"].ToString(), dr["CharacterID"].ToString(), dr["CharacterName"].ToString() });
                                }
                            }
                        }
                    }
                    else if (ReceiverListSet != null)
                    {
                        if (ReceiverListSet.Tables.Count > 0)
                        {
                            if (ReceiverListSet.Tables[0].Rows.Count > 0)
                            {
                                if (Mail_SearchReceiverType < int.MaxValue)
                                {
                                    Mail_SearchReceiverDataGridView.Rows.Clear();
                                    foreach (DataRow dr in ReceiverListSet.Tables[0].Rows)
                                    {
                                        if (dr[Mail_SearchReceiverType].ToString().ToLower().IndexOf(Mail_SearchReceiverStrTextBox.Text.ToLower()) > -1)
                                        {
                                            Mail_SearchReceiverDataGridView.Rows.Add(new object[] { false, dr["AccountID"].ToString(), dr["AccountName"].ToString(), dr["CharacterID"].ToString(), dr["CharacterName"].ToString() });
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Mail_SearchReceiverTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Mail_SearchReceiverTypeList.Text)
            {
                case "账号ID":
                    Mail_SearchReceiverType = 0;
                    break;
                case "账号名称":
                    Mail_SearchReceiverType = 1;
                    break;
                case "角色ID":
                    Mail_SearchReceiverType = 2;
                    break;
                case "角色名称":
                    Mail_SearchReceiverType = 3;
                    break;
            }
            Mail_SearchReceiverStrTextBox_TextChanged(sender, e);
        }
    }
}
