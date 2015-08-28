using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
//using MySQLDriverCS;

namespace WOWItemMaker
{
    public partial class FrmGetSql : Form
    {
        public FrmGetSql()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void SaveSQL(string file)
        {
            try
            {
                StreamWriter sw = new StreamWriter(file);
                sw.Write(SQLContent.Text);
                sw.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("保存失败！\r\n" + err.Message, "保存文件");
            }
        }
        public void ShowSQL(string SQL,string FileName)
        {
            SQLContent.Text = SQL;
            saveFileDialog1.FileName = FileName;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            SaveSQL(saveFileDialog1.FileName);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveSQLBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void ToClipboardBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(SQLContent.Text);
                MessageBox.Show("信息已经复制到剪贴板！", "复制到剪贴板");
            }
            catch
            {
                MessageBox.Show("复制失败！", "复制到剪贴板");
            }
        }
    }
}
