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
using System.Text.RegularExpressions;

namespace WOWItemMaker
{
    public partial class ServerManager : Form
    {
        private SearchReceiverForm Receiver;
        private SearchItemsFormcs ItemsForm;
        Server_SendMailResault SendMailResault;
        Server_SendMail SendMail;
        private static string _hostName;

        public static string HostName
        {
            get { return ServerManager._hostName; }
            set { ServerManager._hostName = value; }
        }

        private static string _userName;

        public static string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private static string _password;

        public static string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private static string _charactersDB;

        public static string CharactersDB
        {
            get { return _charactersDB; }
            set { _charactersDB = value; }
        }
        private static string _mangosDB;

        public static string MangosDB
        {
            get { return _mangosDB; }
            set { _mangosDB = value; }
        }
        private static string _realmdDB;

        public static string RealmdDB
        {
            get { return _realmdDB; }
            set { _realmdDB = value; }
        }

        private DataSet DBListSet;

        public ServerManager()
        {
            InitializeComponent();
            Receiver = new SearchReceiverForm();
            ItemsForm = new SearchItemsFormcs();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Mail_AddReceiverBtn_Click(object sender, EventArgs e)
        {
            Receiver.ShowDialog();
            if (Receiver.ReceiverList.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in Receiver.ReceiverList.Tables[0].Rows)
                {
                    Mail_ReceiverDataGridView.Rows.Add(new object[] { false, dr["AccountID"].ToString(), dr["AccountName"].ToString(), dr["CharacterID"].ToString(), dr["CharacterName"].ToString() });
                }
            }
        }

        private void ServerManager_Load(object sender, EventArgs e)
        {
            DBListSet = new DataSet();
            mangosDBList.DropDown += new EventHandler(DBList_DropDown);
            charactersDBList.DropDown += new EventHandler(DBList_DropDown);
            realmdDBList.DropDown += new EventHandler(DBList_DropDown);
            HostNameTextBox.Text = ConnInfo.HostName;
            PWDTextBox.Text = ConnInfo.PassWord;
            UserNameTextBox.Text = ConnInfo.UserName;
            ServerManager.HostName = HostNameTextBox.Text;
            ServerManager.Password = PWDTextBox.Text;
            ServerManager.UserName = UserNameTextBox.Text;
            ServerManager.MangosDB = mangosDBList.Text;
            ServerManager.CharactersDB = charactersDBList.Text;
            ServerManager.RealmdDB = realmdDBList.Text;
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
            DataGridViewCheckBoxColumn checkboxColn1 = new DataGridViewCheckBoxColumn();
            checkboxColn1.Width = 50;
            checkboxColn1.Name = "选择";
            Mail_ReceiverDataGridView.Columns.Add(checkboxColn1);
            Mail_ReceiverDataGridView.Columns.Add(coln1);
            Mail_ReceiverDataGridView.Columns.Add(coln2);
            Mail_ReceiverDataGridView.Columns.Add(coln3);
            Mail_ReceiverDataGridView.Columns.Add(coln4);


            DataGridViewTextBoxColumn coln5 = new DataGridViewTextBoxColumn();
            coln5.Width = 70;
            coln5.Name = "物品ID";
            coln5.ReadOnly = true;
            DataGridViewTextBoxColumn coln6 = new DataGridViewTextBoxColumn();
            coln6.Width = 80;
            coln6.Name = "物品名称";
            coln6.ReadOnly = true;
            DataGridViewTextBoxColumn coln7 = new DataGridViewTextBoxColumn();
            coln7.Width = 60;
            coln7.Name = "数量";
            coln7.ReadOnly = false;
            DataGridViewCheckBoxColumn checkboxColn2 = new DataGridViewCheckBoxColumn();
            checkboxColn2.Width = 50;
            checkboxColn2.Name = "选择";
            Mail_ItemDataGridView.Columns.Add(checkboxColn2);
            Mail_ItemDataGridView.Columns.Add(coln5);
            Mail_ItemDataGridView.Columns.Add(coln6);
            Mail_ItemDataGridView.Columns.Add(coln7);

        }

        void DBList_DropDown(object sender, EventArgs e)
        {
            if (DBListSet == null)
            {
                Thread GetList = new Thread(new ParameterizedThreadStart(GetDBList));
                GetList.IsBackground = true;
                GetList.Start();
            }
            else if (DBListSet.Tables.Count == 0)
            {
                Thread GetList = new Thread(new ParameterizedThreadStart(GetDBList));
                GetList.IsBackground = true;
                GetList.Start();
            }
            else if (DBListSet.Tables[0].Rows.Count == 0)
            {
                Thread GetList = new Thread(new ParameterizedThreadStart(GetDBList));
                GetList.IsBackground = true;
                GetList.Start();
            }
        }

        public string GetConnStr()
        {
            string HostName = ServerManager.HostName;
            string UserName = ServerManager.UserName;
            string PWD = ServerManager.Password;
            //MySQLConnectionString strConn = new MySQLConnectionString(HostName,string.Empty, UserName, PWD);
            string strConn = "Data Source=" + HostName + ";User Id=" + UserName + ";Password=" + PWD;
            return strConn;
        }

        private void mangosDBList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerManager.MangosDB = mangosDBList.Text;
        }

        private void GetDBList(object sender)
        {
            MyInvoke mi = new MyInvoke(miGetDBList);
            try
            {
                MySqlConnection Conn = new MySqlConnection(GetConnStr());
                MySqlCommand setname = new MySqlCommand("set names 'gbk';", Conn);
                MySqlDataAdapter adp = new MySqlDataAdapter("SHOW DATABASES;", Conn);
                Conn.Open();
                setname.ExecuteNonQuery();
                setname.Dispose();
                adp.Fill(DBListSet);
                this.Invoke(mi, "true");
            }
            catch
            {
                this.Invoke(mi, "false");
            }
        }
        private void miGetDBList(string result)
        {
            mangosDBList.Items.Clear();
            charactersDBList.Items.Clear();
            realmdDBList.Items.Clear();
            if (result == "true")
            {
                foreach (DataRow dr in DBListSet.Tables[0].Rows)
                {
                    mangosDBList.Items.Add(dr["Database"].ToString());
                    charactersDBList.Items.Add(dr["Database"].ToString());
                    realmdDBList.Items.Add(dr["Database"].ToString());
                }
            }
        }

        private void charactersDBList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerManager.CharactersDB = charactersDBList.Text;
        }

        private void realmdDBList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerManager.RealmdDB = realmdDBList.Text;
        }

        private void HostNameTextBox_TextChanged(object sender, EventArgs e)
        {
            DBListSet = new DataSet();
            ServerManager.HostName = HostNameTextBox.Text;
        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            DBListSet = new DataSet();
            ServerManager.UserName = UserNameTextBox.Text;
        }

        private void PWDTextBox_TextChanged(object sender, EventArgs e)
        {
            DBListSet = new DataSet();
            ServerManager.Password = PWDTextBox.Text;
        }

        private void Mail_ClearReceiverListBtn_Click(object sender, EventArgs e)
        {
            Mail_ReceiverDataGridView.Rows.Clear();
        }

        private void Mail_DeleteReveicerCheckedBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Mail_ReceiverDataGridView.Rows.Count; i++)
            {
                if ((bool)Mail_ReceiverDataGridView.Rows[i].Cells[0].FormattedValue)
                {
                    Mail_ReceiverDataGridView.Rows.Remove(Mail_ReceiverDataGridView.Rows[i]);
                    i--;
                }
            }
        }

        private void Mail_AddItemBtn_Click(object sender, EventArgs e)
        {
            ItemsForm.ShowDialog();
            if (ItemsForm.ItemsList.Tables[0].Rows.Count > 0)
            {
                Regex reg = new Regex("\\d+");
                foreach (DataRow dr in ItemsForm.ItemsList.Tables[0].Rows)
                {
                    bool IsRepeatedItem = false;
                    foreach (DataGridViewRow dgvRow in Mail_ItemDataGridView.Rows)
                    {
                        if (dgvRow.Cells[1].Value.ToString() == dr["entry"].ToString())
                        {
                            IsRepeatedItem = true;
                            if (reg.Match(dgvRow.Cells[3].Value.ToString()).Success)
                            {
                                dgvRow.Cells[3].Value = (Convert.ToInt32(reg.Match(dgvRow.Cells[3].Value.ToString()).Value) + 1).ToString();
                            }
                            else
                            {
                                dgvRow.Cells[3].Value = 1;
                            }
                        }
                    }
                    if(!IsRepeatedItem)
                        Mail_ItemDataGridView.Rows.Add(new object[] { false, dr["entry"].ToString(), dr["name"].ToString(),"1" });
                }
            }
        }

        private void Mail_DeleteCheckedItemsBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Mail_ItemDataGridView.Rows.Count; i++)
            {
                if ((bool)Mail_ItemDataGridView.Rows[i].Cells[0].FormattedValue)
                {
                    Mail_ItemDataGridView.Rows.Remove(Mail_ItemDataGridView.Rows[i]);
                    i--;
                }
            }
        }

        private void Mail_ClearItemListBtn_Click(object sender, EventArgs e)
        {
            Mail_ItemDataGridView.Rows.Clear();
        }

        private void Mail_SendBtn_Click(object sender, EventArgs e)
        {
            SendMail = new Server_SendMail();
            Regex regExpireTime = new Regex("[^\\d]");
            Int64 Expiretime = new long();
            Int64 Delivertime = new long();
            int Expiretime_days = 0;
            int Expiretime_hours = 0;
            int Expiretime_minuets = 0;
            int Expiretime_seconds = 0;
            DataSet ReceiversSet = new DataSet();
            ReceiversSet.Tables.Add("Receivers");
            ReceiversSet.Tables[0].Columns.Add("AccountID", typeof(int));
            ReceiversSet.Tables[0].Columns.Add("AccountName", typeof(string));
            ReceiversSet.Tables[0].Columns.Add("CharactersID", typeof(int));
            ReceiversSet.Tables[0].Columns.Add("CharactersName", typeof(string));
            DataSet ItemsSet = new DataSet();
            ItemsSet.Tables.Add("Items");
            ItemsSet.Tables[0].Columns.Add("entry", typeof(string));
            ItemsSet.Tables[0].Columns.Add("count", typeof(int));
            if (Mail_ReceiverDataGridView.Rows.Count == 0)
            {
                toolTip1.Show("点击此标签添加收件人", this, 105, 70);
                return;
            }
            else if (Mail_TittleTextBox.Text.Trim().Length == 0)
            {
                toolTip1.Show("邮件标题不能为空", this, 50, 70);
                return;
            }
            else if (Mail_ContentTextBox.Text.Trim().Length == 0)
            {
                toolTip1.Show("邮件内容不能为空", this, 50, 70);
                return;
            }
            else if (regExpireTime.Match(ExpireTime_Days_TextBox.Text).Success || regExpireTime.Match(ExpireTime_Hours_TextBox.Text).Success || regExpireTime.Match(ExpireTime_Minuets_TextBox.Text).Success || regExpireTime.Match(ExpireTime_Seconds_TextBox.Text).Success)
            {
                toolTip1.Show("日期填写不正确", this, 130, 70);
                return;
            }
            foreach (DataGridViewRow dr in Mail_ItemDataGridView.Rows)
            {
                Regex CheckItemsCountReg = new Regex("[^0-9]");
                if (CheckItemsCountReg.Match(dr.Cells[3].Value.ToString()).Success)
                {
                    toolTip1.Show("物品["+dr.Cells[1].Value.ToString()+"]的数量填写不正确，无法发送。", this, 130, 70);
                    ItemsSet.Tables[0].Rows.Clear();
                    return;
                }
                ItemsSet.Tables[0].Rows.Add(new object[] { dr.Cells[1].Value, dr.Cells[3].Value });
            }
            foreach (DataGridViewRow dr in Mail_ReceiverDataGridView.Rows)
            {
                ReceiversSet.Tables[0].Rows.Add(new object[] { dr.Cells[1].Value, dr.Cells[2].Value, dr.Cells[3].Value, dr.Cells[4].Value });
            }
            if (radioButton1.Checked)
            {
                TimeSpan ts = new TimeSpan();
                ts = DateTime.Now - Convert.ToDateTime("1970/01/01 0:00:00");
                Int64 expireDays = Convert.ToInt64(ExpireTime_Days_TextBox.Text);
                long expireHours = Convert.ToInt64(ExpireTime_Hours_TextBox.Text);
                long expireMinuets = Convert.ToInt64(ExpireTime_Minuets_TextBox.Text);
                long expireSeconds = Convert.ToInt64(ExpireTime_Seconds_TextBox.Text);
                Expiretime = DateTime.Now.ToFileTimeUtc() - Convert.ToDateTime("1970/01/01 0:00:00").ToFileTimeUtc() + expireDays * 3600 * 24 + expireHours * 3600 + expireMinuets * 60 + expireSeconds;
            }
            else if (radioButton2.Checked)
            {
                TimeSpan ts = new TimeSpan();
                ts = dateTimePicker1.Value - Convert.ToDateTime("1970/01/01 0:00:00");
                Expiretime = dateTimePicker1.Value.ToFileTimeUtc() - Convert.ToDateTime("1970/01/01 0:00:00").ToFileTimeUtc();
            }
            Delivertime = dateTimePicker2.Value.ToFileTimeUtc() - Convert.ToDateTime("1970/01/01 0:00:00").ToFileTimeUtc();
            SendMail.MailTittle = Mail_TittleTextBox.Text;
            SendMail.MailText = Mail_ContentTextBox.Text;
            SendMail.ExpireTime = Expiretime;
            SendMail.DeliverTime = Delivertime;
            SendMail.ReceiversSet = ReceiversSet;
            SendMail.ItemsSet = ItemsSet;
            SendMail.ShowDialog();
            SendMailResault = new Server_SendMailResault();
            SendMailResault.SendMailResault = SendMail.SendMailResault;
            SendMailResault.ResaultMsg1 = SendMail.ResaultInfo1;
            SendMailResault.ResaultMsg2 = SendMail.ResaultInfo2;
            SendMailResault.ShowDialog();
        }

    }
}
