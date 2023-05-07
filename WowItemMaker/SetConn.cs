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
using Microsoft.Win32;

namespace WOWItemMaker
{
    public partial class SetConn : Form
    {
        public SetConn()
        {
            InitializeComponent();
        }


        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetDBListBtn_Click(object sender, EventArgs e)
        {
            Thread GetList = new Thread(new ParameterizedThreadStart(GetDBList));
            string host = HostNameTextBox.Text;
            uint port = 3306;
            if (host.LastIndexOf(':') > -1)
            {
                int pos = host.LastIndexOf(':');
                try
                {
                    port = uint.Parse(host.Substring(pos + 1));
                }
                catch { }
                host = host.Substring(0, pos);
            }
            GetList.Start("Password=" + PWDTextBox.Text + ";User ID=" + UserNameTextBox.Text + ";Data Source=" + host + ";port=" + port + ";CharSet=gbk");
        }
        private void GetDBList(object strConn)
        {
            MyInvoke mi = new MyInvoke(miGetDBList);
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                MySqlConnection Conn = new MySqlConnection(strConn.ToString());
                MySqlCommand setname = new MySqlCommand("set names 'gbk';", Conn);
                MySqlDataAdapter adp = new MySqlDataAdapter("SHOW DATABASES;", Conn);
                DataSet ds = new DataSet();
                Conn.Open();
                setname.ExecuteNonQuery();
                setname.Dispose();
                adp.Fill(ds);
                DBListInfo.DBList1 = ds;
                this.Invoke(mi, "true");
            }
            catch
            {
                this.Invoke(mi, "false");
            }
        }
        private void miGetDBList(string result)
        {
            if (result == "true")
            {
                DBList.Items.Clear();
                foreach (DataRow dr in DBListInfo.DBList1.Tables[0].Rows)
                {
                    DBList.Items.Add(dr["Database"].ToString());
                }
            }
            else if (result == "false")
            {
                DBList.Items.Clear();
            }
        }

        private void ConnBtn_Click(object sender, EventArgs e)
        {
            if (DbStructList.Text.Length == 0)
            {
                MessageBox.Show("必须选择数据库结构！", "连接数据库");
                return;
            }
            this.Enabled = false;
            Thread TestCon = new Thread(new ParameterizedThreadStart(TestConn));
            TestCon.Start(getConnString());
        }
        private void TestConn(object strConn)
        {
            MySqlConnection Conn = null;
            Conn = new MySqlConnection(strConn.ToString());
            MyInvoke mi = new MyInvoke(miTestConn);
            try
            {
                Conn.Open();
                this.Invoke(mi, "true");
            }
            catch(Exception err)
            {
                this.Invoke(mi, "false" + err.Message);
            }
            finally
            {
                Conn.Close();
            }

        }
        public void miTestConn(string result)
        {
            if (result == "true")
            {
                ConnInfo.HostName = HostNameTextBox.Text;
                ConnInfo.UserName = UserNameTextBox.Text;
                ConnInfo.PassWord = PWDTextBox.Text;
                ConnInfo.DataBase = DBList.Text;
                ConnInfo.Stat = true;
                this.Enabled = true;
                this.Close();
            }
            else if (result.IndexOf("false") == 0)
            {
                this.Enabled = true;
                string errMsg = result.Substring(5);
                MessageBox.Show("连接失败！\r\n" + errMsg, "测试连接");
            }
            else
            {
                this.Enabled = true;
            }

        }

        private void SetConn_Load(object sender, EventArgs e)
        {
            HostNameTextBox.Text = ConnInfo.HostName;
            if (ConnInfo.Port != 3306)
                HostNameTextBox.Text += ":" + ConnInfo.Port;
            UserNameTextBox.Text = ConnInfo.UserName;
            PWDTextBox.Text = ConnInfo.PassWord;
            DBList.Text = ConnInfo.DataBase;
            DbStructList.Text = ConnInfo.Dbstruct;
            SaveConnInfoCheckBox.Checked = ConnInfo.SaveConnInfo;
            SavePwdCheckBox.Checked = ConnInfo.SavePwd;
        }

        private void SaveConnInfoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SaveConnInfoCheckBox.Checked)
            {
                SavePwdCheckBox.Enabled = true;
            }
            else
            {
                SavePwdCheckBox.Enabled = false;
            }
            ConnInfo.SaveConnInfo = SaveConnInfoCheckBox.Checked;
        }

        private void DbStructList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnInfo.Dbstruct = DbStructList.Text;
        }

        private void SavePwdCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ConnInfo.SavePwd = SavePwdCheckBox.Checked;
        }

        private string getConnString()
        {
            string HostName = HostNameTextBox.Text;
            uint port = 3306;
            string UserName = UserNameTextBox.Text.Trim();
            string PWD = PWDTextBox.Text.Trim();
            string db = DBList.Text;
            if (HostName.LastIndexOf(':') > -1)
            {
                int pos = HostName.LastIndexOf(':');
                try
                {
                    port = uint.Parse(HostName.Substring(pos + 1));
                }
                catch { }
                HostName = HostName.Substring(0, pos);
            }
            string strConn = "Database=" + db + ";Data Source=" + HostName + ";port=" + port + ";User Id=" + UserName + ";Password=" + PWD;
            return strConn;
        }
    }
    public class DBListInfo
    {
        private static DataSet _DBList;

        public static DataSet DBList1
        {
            get { return DBListInfo._DBList; }
            set { DBListInfo._DBList = value; }
        }
    }
}
