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
using System.Collections;

namespace WOWItemMaker
{
    
    public delegate void SendMailInvoke(int type,string str);
    public partial class Server_SendMail : Form
    {
        private DataSet _receiversSet;

        public DataSet ReceiversSet
        {
            get { return _receiversSet; }
            set { _receiversSet = value; }
        }
        private DataSet _itemsSet;

        public DataSet ItemsSet
        {
            get { return _itemsSet; }
            set { _itemsSet = value; }
        }

        private string _mailTittle;

        public string MailTittle
        {
            get { return _mailTittle; }
            set { _mailTittle = value; }
        }
        private string _mailText;

        public string MailText
        {
            get { return _mailText; }
            set { _mailText = value; }
        }

        private DataSet _sendMailResault;

        public DataSet SendMailResault
        {
            get { return _sendMailResault; }
            set { _sendMailResault = value; }
        }

        private string _resaultInfo1;

        public string ResaultInfo1
        {
            get { return _resaultInfo1; }
            set { _resaultInfo1 = value; }
        }

        private Int64 _expireTime;

        public Int64 ExpireTime
        {
            get { return _expireTime; }
            set { _expireTime = value; }
        }

        private Int64 _deliverTime;

        public Int64 DeliverTime
        {
            get { return _deliverTime; }
            set { _deliverTime = value; }
        }

        private string _resaultInfo2;

        public string ResaultInfo2
        {
            get { return _resaultInfo2; }
            set { _resaultInfo2 = value; }
        }

        private ArrayList Inserted_item_instance;
        private ArrayList Inserted_item_text;
        private ArrayList Inserted_mail;
        private ArrayList Inserted_mail_items;

        private Thread SendMailThread;
        private Thread CancleSendThread;
        private ServerManager sManager;
        private bool FormClose;
        public Server_SendMail()
        {
            InitializeComponent();
        }

        private void Server_SendMail_Load(object sender, EventArgs e)
        {
            sManager = new ServerManager();
            Inserted_item_instance = new ArrayList();
            Inserted_item_text = new ArrayList();
            Inserted_mail = new ArrayList();
            Inserted_mail_items = new ArrayList();
            this.SendMailResault = new DataSet();
            this.SendMailResault.Tables.Add("Resault");
            this.SendMailResault.Tables[0].Columns.Add("AccountID", typeof(string));
            this.SendMailResault.Tables[0].Columns.Add("AccountName", typeof(string));
            this.SendMailResault.Tables[0].Columns.Add("CharactersID", typeof(string));
            this.SendMailResault.Tables[0].Columns.Add("CharactersName", typeof(string));
            this.SendMailResault.Tables[0].Columns.Add("Resault", typeof(string));
            SendMailThread = new Thread(new ParameterizedThreadStart(SendMail));
            SendMailThread.IsBackground = true;
            CancleSendThread = new Thread(new ParameterizedThreadStart(CancelSend));
            CancleSendThread.IsBackground = true;
            SendMailThread.Start();
        }

        private void SendMail(object sender)
        {
            SendMailInvoke mi = new SendMailInvoke(invokeSendMail);
            MySqlConnection Conn = new MySqlConnection(sManager.GetConnStr());
            MySqlCommand setname = new MySqlCommand("set names 'gbk';", Conn);
            MySqlCommand chgDB = new MySqlCommand("USE " + ServerManager.CharactersDB + ";", Conn);
            try
            {
                Conn.Open();
                setname.ExecuteNonQuery();
                setname.Dispose();
                chgDB.ExecuteNonQuery();
                chgDB.Dispose();
                MySqlCommand setAuto_Increment = new MySqlCommand("alter table mail modify id int not null auto_increment;", Conn);
                setAuto_Increment.ExecuteNonQuery();
                setAuto_Increment = new MySqlCommand("alter table item_text modify id int not null auto_increment;", Conn);
                setAuto_Increment.ExecuteNonQuery();
                setAuto_Increment = new MySqlCommand("alter table item_instance modify guid int not null auto_increment;", Conn);
                setAuto_Increment.ExecuteNonQuery();
                setAuto_Increment.Dispose();
                foreach (DataRow dr in ReceiversSet.Tables[0].Rows)
                {
                    SendMailResault.Tables[0].Rows.Add(new object[] { dr[0], dr[1], dr[2], dr[3], "未发送" });
                }
                int ReceiversCount = SendMailResault.Tables[0].Rows.Count;
                this.Invoke(mi, new object[] { 1, "正在发送..." });
                for (int CurrentReceiver = 0; CurrentReceiver < ReceiversCount; CurrentReceiver++)
                {
                    this.Invoke(mi, new object[] { 1, "正在发送..." + (CurrentReceiver + 1).ToString() + "/" + ReceiversCount.ToString() });
                    this.Invoke(mi, new object[] { 3, (CurrentReceiver * 1000 / ReceiversCount).ToString() });
                    int CurrentProgress = CurrentReceiver * 1000 / ReceiversCount;
                    int InsertProgress = 2;
                    int CurrentInsertProgress = 0;
                    int has_items = 0;
                    int TotalItemsCount = 0;
                    int CurrentItemsCount = 0;
                    if (ItemsSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ItemsSet.Tables[0].Rows)
                        {
                            TotalItemsCount += Convert.ToInt32(dr[1]);
                        }
                        has_items = 1;
                        InsertProgress = TotalItemsCount * 2 + 2;
                    }
                    this.Invoke(mi, new object[] { 2, "插入邮件内容" });
                    MySqlCommand InsertMail = new MySqlCommand("INSERT INTO item_text(text) VALUES('" + MailText + "');", Conn);
                    InsertMail.ExecuteNonQuery();
                    InsertMail = new MySqlCommand("SELECT LAST_INSERT_ID();", Conn);
                    object Current_item_text_id = InsertMail.ExecuteScalar();
                    Inserted_item_text.Add(Current_item_text_id);
                    CurrentInsertProgress++;
                    this.Invoke(mi, new object[] { 3, (CurrentProgress + 1000 / ReceiversCount * CurrentInsertProgress / InsertProgress).ToString() });
                    this.Invoke(mi, new object[] { 2, "插入邮件信息" });
                    InsertMail = new MySqlCommand("INSERT INTO mail(messageType, stationery, mailTemplateId, sender, receiver, subject, itemTextId, has_items, expire_time, deliver_time, money, cod, checked) VALUES(0, 61, 0, 0, " + this.ReceiversSet.Tables[0].Rows[CurrentReceiver][2].ToString() + ", '" + MailTittle + "', " + Current_item_text_id.ToString() + ", " + has_items.ToString() + ", " + this.ExpireTime + ", " + this.DeliverTime + ", 0, 0, 0);", Conn);
                    InsertMail.ExecuteNonQuery();
                    InsertMail = new MySqlCommand("SELECT LAST_INSERT_ID();", Conn);
                    object Current_mail_id = InsertMail.ExecuteScalar();
                    Inserted_mail.Add(Current_mail_id);
                    CurrentInsertProgress++;
                    this.Invoke(mi, new object[] { 3, (CurrentProgress + 1000 / ReceiversCount * CurrentInsertProgress / InsertProgress).ToString() });
                    if (ItemsSet.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow ItemRow in ItemsSet.Tables[0].Rows)
                        {
                            for (int InsertItemRepeatCount = 0; InsertItemRepeatCount < Convert.ToInt32(ItemRow[1]); InsertItemRepeatCount++)
                            {
                                CurrentItemsCount++;
                                this.Invoke(mi, new object[] { 2, "插入物品信息..."+CurrentItemsCount.ToString()+"/"+TotalItemsCount.ToString() });
                                MySqlCommand InsertItem = new MySqlCommand("INSERT INTO item_instance(owner_guid,data) VALUES(0,null);", Conn);
                                InsertItem.ExecuteNonQuery();
                                InsertItem = new MySqlCommand("SELECT LAST_INSERT_ID();", Conn);
                                object Current_item_instance_guid = InsertItem.ExecuteScalar();
                                Inserted_item_instance.Add(Current_item_instance_guid);
                                CurrentInsertProgress++;
                                this.Invoke(mi, new object[] { 3, (CurrentProgress + 1000 / ReceiversCount * CurrentInsertProgress / InsertProgress).ToString() });
                                InsertItem = new MySqlCommand("UPDATE item_instance SET data='" + Current_item_instance_guid.ToString() + " 1073741824 3 " + ItemRow[0].ToString() + " 1065353216 0 0 0 0 0 0 0 0 0 " + ItemRow[1].ToString() + " 0 0 0 0 0 0 4 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 ' WHERE guid='" + Current_item_instance_guid.ToString() + "';", Conn);
                                InsertItem.ExecuteNonQuery();
                                InsertItem = new MySqlCommand("INSERT INTO mail_items(mail_id,item_guid,item_template,receiver) VALUES(" + Current_mail_id.ToString() + "," + Current_item_instance_guid + "," + ItemRow[0].ToString() + "," + this.ReceiversSet.Tables[0].Rows[CurrentReceiver][2].ToString() + ");", Conn);
                                InsertItem.ExecuteNonQuery();
                                CurrentInsertProgress++;
                                this.Invoke(mi, new object[] { 3, (CurrentProgress + 1000 / ReceiversCount * CurrentInsertProgress / InsertProgress).ToString() });
                            }
                        }
                    }
                    this.SendMailResault.Tables[0].Rows[CurrentReceiver][4] = "已发送";
                }
                MySqlCommand unsetAuto_Increment = new MySqlCommand("alter table mail modify id int not null;", Conn);
                unsetAuto_Increment.ExecuteNonQuery();
                unsetAuto_Increment = new MySqlCommand("alter table item_text modify id int not null;", Conn);
                unsetAuto_Increment.ExecuteNonQuery();
                unsetAuto_Increment = new MySqlCommand("alter table item_instance modify guid int not null;", Conn);
                unsetAuto_Increment.ExecuteNonQuery();
                this.Invoke(mi, new object[] { 4, "成功发送" + Inserted_mail.Count.ToString() + "封邮件" });

            }
            catch (Exception err)
            {
                if(err.Message!=string.Empty)
                    this.Invoke(mi, new object[] { 0, err.Message });
            }
            finally
            {
                Conn.Close();
            }
        }

        private void CancelSend(object sender)
        {
            SendMailInvoke mi = new SendMailInvoke(invokeSendMail);
            MySqlConnection Conn = new MySqlConnection(sManager.GetConnStr());
            MySqlCommand setname = new MySqlCommand("set names 'gbk';", Conn);
            MySqlCommand chgDB = new MySqlCommand("USE " + ServerManager.CharactersDB + ";", Conn);
            try
            {
                this.Invoke(mi, new object[] { 1, "正在取消..." });
                this.Invoke(mi, new object[] { 2, string.Empty });
                this.Invoke(mi, new object[] { 3, "0" });
                Conn.Open();
                setname.ExecuteNonQuery();
                setname.Dispose();
                chgDB.ExecuteNonQuery();
                chgDB.Dispose();
                MySqlCommand unsetAuto_Increment = new MySqlCommand("alter table mail modify id int not null;", Conn);
                unsetAuto_Increment.ExecuteNonQuery();
                unsetAuto_Increment = new MySqlCommand("alter table item_text modify id int not null;", Conn);
                unsetAuto_Increment.ExecuteNonQuery();
                unsetAuto_Increment = new MySqlCommand("alter table item_instance modify guid int not null;", Conn);
                unsetAuto_Increment.ExecuteNonQuery();
                int CurrentDelPos = 0;
                int CurrentDelProgress = 0;
                int TotalDelCount = Inserted_item_text.Count + Inserted_item_instance.Count + Inserted_mail.Count * 2;
                this.Invoke(mi, new object[] { 2, "删除邮件内容..." });
                foreach (string str in Inserted_item_text)
                {
                    CurrentDelPos++;
                    this.Invoke(mi, new object[] { 2, "删除邮件内容..." + CurrentDelPos.ToString() + "/" + Inserted_item_text.Count });
                    MySqlCommand Del_item_text = new MySqlCommand("DELETE FROM item_text WHERE id='" + str + "';", Conn);
                    Del_item_text.ExecuteNonQuery();
                    CurrentDelProgress++;
                    this.Invoke(mi, new object[] { 3, (CurrentDelProgress * 1000 / TotalDelCount).ToString() });
                }
                CurrentDelPos = 0;
                this.Invoke(mi, new object[] { 2, "删除物品信息..." });
                foreach (string str in Inserted_item_instance)
                {
                    CurrentDelPos++;
                    this.Invoke(mi, new object[] { 2, "删除物品信息..." + CurrentDelPos.ToString() + "/" + Inserted_item_instance.Count });
                    MySqlCommand Del_item_instance = new MySqlCommand("DELETE FROM item_instance WHERE guid='" + str + "';", Conn);
                    Del_item_instance.ExecuteNonQuery();
                    CurrentDelProgress++;
                    this.Invoke(mi, new object[] { 3, (CurrentDelProgress * 1000 / TotalDelCount).ToString() });
                }
                CurrentDelPos = 0;
                this.Invoke(mi, new object[] { 2, "删除邮件信息..." });
                foreach (string str in Inserted_mail)
                {
                    CurrentDelPos++;
                    this.Invoke(mi, new object[] { 2, "删除邮件信息..." + CurrentDelPos.ToString() + "/" + Inserted_mail.Count });
                    MySqlCommand Del_mail = new MySqlCommand("DELETE FROM mail WHERE id='" + str + "';", Conn);
                    MySqlCommand Del_mail_items = new MySqlCommand("DELETE FROM mail_items WHERE mail_id='" + str + "';", Conn);
                    Del_mail.ExecuteNonQuery();
                    CurrentDelProgress++;
                    this.Invoke(mi, new object[] { 3, (CurrentDelProgress * 1000 / TotalDelCount).ToString() });
                    Del_mail_items.ExecuteNonQuery();
                    CurrentDelProgress++;
                    this.Invoke(mi, new object[] { 3, (CurrentDelProgress * 1000 / TotalDelCount).ToString() });
                }
                foreach (DataRow dr in this.SendMailResault.Tables[0].Rows)
                {
                    if (dr[4].ToString() == "已发送")
                        dr[4] = "已取消";
                }
                this.Invoke(mi, new object[] { 0, "用户取消了发送" });
            }
            catch (Exception err)
            {
                this.Invoke(mi, new object[] { 5, err.Message });
            }
        }

        private void invokeSendMail(int type, string str)
        {
            switch (type)
            {
                case 0:
                    this.ResaultInfo1 = "由于以下原因，发送被迫中止：";
                    this.ResaultInfo2 = str;
                    if (SendMailThread.ThreadState.ToString().IndexOf("AbortRequested") == -1)
                    {
                        this.FormClose = true;
                        this.Close();
                    }
                    break;
                case 1:
                    label1.Text = str;
                    break;
                case 2:
                    label2.Text = str;
                    break;
                case 3:
                    progressBar1.Value = Convert.ToInt32(str);
                    break;
                case 4:
                    this.ResaultInfo1 = "发送完成！";
                    this.ResaultInfo2 = str;
                    this.FormClose = true;
                    this.Close();
                    break;
                case 5:
                    foreach (DataRow dr in this.SendMailResault.Tables[0].Rows)
                    {
                        if (dr[4].ToString() == "已发送")
                            dr[4] = "未知";
                    }
                    this.ResaultInfo1 = "由于以下原因，部分邮件没有成功取消：";
                    this.ResaultInfo2 = str;
                    this.FormClose = true;
                    this.Close();
                    break;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            CancelBtn.Enabled = false;
            SendMailThread.Abort();
            CancleSendThread.Start();
        }

        private void Server_SendMail_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (CancleSendThread.ThreadState.ToString().IndexOf(ThreadState.Unstarted.ToString()) > -1&&!this.FormClose)
            {
                EventArgs e1 = new EventArgs();
                CancelBtn_Click(sender, e1);
            }
            else if (this.FormClose)
            {
                e.Cancel = false;
            }
        }

    }
}
