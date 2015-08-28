using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace WOWItemMaker
{
    public partial class Downloader : Form
    {

        WebClient myWebClient = new WebClient();
    public Downloader()
        {
            InitializeComponent();
        }
        public void DownloadFile()
        {
            if (!Directory.Exists(Application.ExecutablePath + "/" + DownloadInfo.FileDirectory))
            {
                Directory.CreateDirectory(Application.StartupPath + "/" + DownloadInfo.FileDirectory);
            }
            myWebClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
            myWebClient.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
            myWebClient.DownloadFileAsync(new Uri(DownloadInfo.Url), Application.StartupPath + "/" + DownloadInfo.FileDirectory + "/" + DownloadInfo.FileName);
        }

        void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null&&!e.Cancelled)
            {
                //下载出错
                label2.Text = e.Error.Message;
                CancleBtn.Text = "关闭";
                //File.Delete(Application.StartupPath + "/" + DownloadInfo.FileDirectory + "/" + DownloadInfo.FileName);
            }
            else
            {
                if (!e.Cancelled)
                {
                    label2.Text = "下载完成";
                    CancleBtn.Text = "关闭";
                    Process proc = new Process();
                    proc.StartInfo.FileName = Application.StartupPath + "/" + DownloadInfo.FileDirectory + "/" + DownloadInfo.FileName;
                    proc.StartInfo.Arguments = "";
                    proc.Start();
                    if (CloseCheckBox.Checked)
                    {
                        this.Close();
                    }
                }
                else
                {
                    //用户取消了下载
                    File.Delete(Application.StartupPath + "/" + DownloadInfo.FileDirectory + "/" + DownloadInfo.FileName);
                    this.Close();
                }
            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            string FileName = DownloadInfo.FileName;
            if (DownloadInfo.FileName.Length > 25)
            {
                FileName = DownloadInfo.FileName.Substring(0, 10) + "..." + DownloadInfo.FileName.Substring(DownloadInfo.FileName.Length - 10);
            }
            label2.Text = "正在下载文件：" + FileName;
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = "下载进度：" + e.ProgressPercentage + "%|" + (Convert.ToDecimal(e.BytesReceived) / 1024 / 1024).ToString("f2") + "/" + (Convert.ToDecimal(e.TotalBytesToReceive) / 1024 / 1024).ToString("f2") + "MB";
            
        }

        private void CancleBtn_Click(object sender, EventArgs e)
        {
            if (CancleBtn.Text == "取消")
            {
                myWebClient.CancelAsync();
                myWebClient.Dispose();
            }
            else if (CancleBtn.Text == "关闭")
            {
                this.Close();
            }
        }

        private void Downloader_Load(object sender, EventArgs e)
        {
            try
            {
                DownloadInfo.Url = System.Configuration.ConfigurationManager.AppSettings["DownloadUrl"].Replace("!", "&");
                DownloadInfo.FileName = System.Configuration.ConfigurationManager.AppSettings["DownloadFileName"];
                DownloadInfo.FileDirectory = System.Configuration.ConfigurationManager.AppSettings["DownloadDirectory"];
                DownloadFile();
                this.FormClosing += new FormClosingEventHandler(Downloader_FormClosing);
            }
            catch(Exception err)
            {
                MessageBox.Show("初始化失败，请检查配置文件是否正常。", "下载文件");
                this.Close();
            }
        }

        void Downloader_FormClosing(object sender, FormClosingEventArgs e)
        {
            myWebClient.CancelAsync();
            myWebClient.Dispose();
        }
    }
    public class DownloadInfo
    {
        private static string _Url;

        public static string Url
        {
            get { return DownloadInfo._Url; }
            set { DownloadInfo._Url = value; }
        }
        private static string _FileName;

        public static string FileName
        {
            get { return DownloadInfo._FileName; }
            set { DownloadInfo._FileName = value; }
        }
        private static string _FileDirectory;

        public static string FileDirectory
        {
            get { return DownloadInfo._FileDirectory; }
            set { DownloadInfo._FileDirectory = value; }
        }
    }
}
