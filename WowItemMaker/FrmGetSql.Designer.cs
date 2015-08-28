namespace WOWItemMaker
{
    partial class FrmGetSql
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGetSql));
            this.CloseBtn = new System.Windows.Forms.Button();
            this.SQLContent = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SaveSQLBtn = new System.Windows.Forms.Button();
            this.ToClipboardBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(505, 331);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 1;
            this.CloseBtn.Text = "关闭";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // SQLContent
            // 
            this.SQLContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SQLContent.Location = new System.Drawing.Point(12, 12);
            this.SQLContent.Multiline = true;
            this.SQLContent.Name = "SQLContent";
            this.SQLContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SQLContent.Size = new System.Drawing.Size(568, 313);
            this.SQLContent.TabIndex = 0;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "sql";
            this.saveFileDialog1.Filter = "SQL文件|*.sql|文本文件|*.txt|所有文件|*.*";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // SaveSQLBtn
            // 
            this.SaveSQLBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveSQLBtn.Location = new System.Drawing.Point(424, 331);
            this.SaveSQLBtn.Name = "SaveSQLBtn";
            this.SaveSQLBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveSQLBtn.TabIndex = 4;
            this.SaveSQLBtn.Text = "保存";
            this.SaveSQLBtn.UseVisualStyleBackColor = true;
            this.SaveSQLBtn.Click += new System.EventHandler(this.SaveSQLBtn_Click);
            // 
            // ToClipboardBtn
            // 
            this.ToClipboardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ToClipboardBtn.Location = new System.Drawing.Point(325, 331);
            this.ToClipboardBtn.Name = "ToClipboardBtn";
            this.ToClipboardBtn.Size = new System.Drawing.Size(93, 23);
            this.ToClipboardBtn.TabIndex = 5;
            this.ToClipboardBtn.Text = "复制到剪贴板";
            this.ToClipboardBtn.UseVisualStyleBackColor = true;
            this.ToClipboardBtn.Click += new System.EventHandler(this.ToClipboardBtn_Click);
            // 
            // Form2
            // 
            this.AcceptButton = this.SaveSQLBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(592, 366);
            this.Controls.Add(this.ToClipboardBtn);
            this.Controls.Add(this.SaveSQLBtn);
            this.Controls.Add(this.SQLContent);
            this.Controls.Add(this.CloseBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导出SQL";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.TextBox SQLContent;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button SaveSQLBtn;
        private System.Windows.Forms.Button ToClipboardBtn;
    }
}