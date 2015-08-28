namespace WOWItemMaker
{
    partial class Downloader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Downloader));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.CancleBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CloseCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 35);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(268, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 1;
            // 
            // CancleBtn
            // 
            this.CancleBtn.Location = new System.Drawing.Point(106, 79);
            this.CancleBtn.Name = "CancleBtn";
            this.CancleBtn.Size = new System.Drawing.Size(75, 23);
            this.CancleBtn.TabIndex = 2;
            this.CancleBtn.Text = "取消";
            this.CancleBtn.UseVisualStyleBackColor = true;
            this.CancleBtn.Click += new System.EventHandler(this.CancleBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "下载进度：0%|0/0MB";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "正在准备下载";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CloseCheckBox
            // 
            this.CloseCheckBox.AutoSize = true;
            this.CloseCheckBox.Location = new System.Drawing.Point(196, 84);
            this.CloseCheckBox.Name = "CloseCheckBox";
            this.CloseCheckBox.Size = new System.Drawing.Size(84, 16);
            this.CloseCheckBox.TabIndex = 5;
            this.CloseCheckBox.Text = "完成后关闭";
            this.CloseCheckBox.UseVisualStyleBackColor = true;
            // 
            // Downloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 112);
            this.Controls.Add(this.CloseCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancleBtn);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Downloader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下载文件";
            this.Load += new System.EventHandler(this.Downloader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button CancleBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CloseCheckBox;
    }
}