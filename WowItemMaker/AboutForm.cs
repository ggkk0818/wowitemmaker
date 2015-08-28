using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics; 

namespace WOWItemMaker
{
    public partial class AboutForm : Form
    {
        private bool IsShowTooltip;
        public AboutForm()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MailToLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:ggkk0818@sina.com");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.wowitemmaker.com");
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            IsShowTooltip = false;
            //timer1.Interval = 10000;
            //timer1.Enabled = true;
            label8.Text = Application.ProductVersion;
        }

        private void label8_MouseMove(object sender, MouseEventArgs e)
        {
            //if (!IsShowTooltip)
            //{
            //    IsShowTooltip = true;
            //    toolTip1.Show("谨以此版本纪念九城的魔兽世界，你给无数玩家留下了美好的回忆。", this, e.Location);
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IsShowTooltip = false;
        }

    }
}
