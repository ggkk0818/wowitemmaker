using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWItemMaker
{
    public partial class Server_SendMailResault : Form
    {
        private DataSet _sendMailResault;

        public DataSet SendMailResault
        {
            get { return _sendMailResault; }
            set { _sendMailResault = value; }
        }

        private string _resaultMsg1;

        public string ResaultMsg1
        {
            get { return _resaultMsg1; }
            set { _resaultMsg1 = value; }
        }
        private string _resaultMsg2;

        public string ResaultMsg2
        {
            get { return _resaultMsg2; }
            set { _resaultMsg2 = value; }
        }

        public Server_SendMailResault()
        {
            InitializeComponent();
        }

        private void Server_SendMailResault_Load(object sender, EventArgs e)
        {
            label1.Text = this.ResaultMsg1;
            label2.Text = this.ResaultMsg2;
            dataGridView1.Columns.Add("AccountID", "账号ID");
            dataGridView1.Columns.Add("AccountName", "账号名称");
            dataGridView1.Columns.Add("CharactersID", "角色ID");
            dataGridView1.Columns.Add("CharactersName", "角色名称");
            dataGridView1.Columns.Add("Resault", "状态");
            foreach (DataRow dr in this.SendMailResault.Tables[0].Rows)
            {
                dataGridView1.Rows.Add(new object[] { dr[0], dr[1], dr[2], dr[3], dr[4] });
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetDataObject(label2.Text);
            MessageBox.Show("信息已复制", "剪贴板");
        }
    }
}
