using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace WOWItemMaker
{
    public delegate void MyInvoke(string str);
    public delegate void UpdateItemInfo(DataSet ds);
    public partial class StateForm : Form
    {
        public StateForm()
        {
            InitializeComponent();
        }

        private void StateForm_Load(object sender, EventArgs e)
        {
            
        }
        public void DBCMD(object SQL)
        {
            MyInvoke mi = new MyInvoke(miCMDSQL);
            MyInvoke end = new MyInvoke(miEND);
            MySqlConnection Conn = new MySqlConnection(MainForm.GetConnStr());
            MySqlCommand setname = new MySqlCommand("set names 'gbk';", Conn);
            MySqlCommand cmd = new MySqlCommand(SQL.ToString(), Conn);
            try
            {
                Conn.Open();
                setname.ExecuteNonQuery();
                setname.Dispose();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Invoke(mi, "执行成功！");
                Thread.Sleep(1500);
                this.Invoke(end, "true");
            }
            catch (Exception err)
            {
                this.Invoke(mi, "执行失败！");
                this.Invoke(end, err.Message);
            }
            finally
            {
                Conn.Close();
            }
        }
        public void DBAdapter(object SQL)
        {
            MyInvoke mi = new MyInvoke(miCMDSQL);
            MyInvoke end = new MyInvoke(miEND);
            MainForm f1 = new MainForm();
            UpdateItemInfo uii = new UpdateItemInfo(f1.GetItemInfo);
            DataSet ds = new DataSet();
            MySqlConnection Conn = new MySqlConnection(MainForm.GetConnStr());
            MySqlCommand setname = new MySqlCommand("set names 'gbk';", Conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(SQL.ToString(), Conn);
            try
            {
                Conn.Open();
                setname.ExecuteNonQuery();
                setname.Dispose();
                adp.Fill(ds);
                this.Invoke(uii, ds);
                this.Invoke(mi, "执行成功！");
                Thread.Sleep(1000);
                this.Invoke(end, "true");
            }
            catch (Exception err)
            {
                ItemInfo.Stat = false;
                this.Invoke(mi, "执行失败！");
                this.Invoke(end, err.Message);
            }
        }
        public void miCMDSQL(string msg)
        {
            StateTextBox.Text = msg;
        }
        public void miEND(string result)
        {
            if (result == "true")
            {
                this.Close();
            }
            else
            {
                StateBtn.Visible = true;
                linkLabel1.Visible = true;
                ErrInfo.Content = result;
            }
        }
        private void StateBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetDataObject(ErrInfo.Content);
            toolTip1.Show(ErrInfo.Content+"\r\n错误信息已经复制到剪贴板，请联系作者解决。", linkLabel1);
        }
    }
    public class ErrInfo
    {
        private static string _content;

        public static string Content
        {
            get { return ErrInfo._content; }
            set { ErrInfo._content = value; }
        }
    }

}
