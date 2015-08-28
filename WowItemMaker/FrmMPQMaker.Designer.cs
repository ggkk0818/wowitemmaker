namespace WOWItemMaker
{
    partial class FrmMPQMaker
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
            this.Btn_Cancle = new System.Windows.Forms.Button();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TXT_FileName = new System.Windows.Forms.TextBox();
            this.Btn_OpenDialog = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.LB_State = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_Cancle
            // 
            this.Btn_Cancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Cancle.Location = new System.Drawing.Point(397, 79);
            this.Btn_Cancle.Name = "Btn_Cancle";
            this.Btn_Cancle.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancle.TabIndex = 0;
            this.Btn_Cancle.Text = "关闭";
            this.Btn_Cancle.UseVisualStyleBackColor = true;
            this.Btn_Cancle.Click += new System.EventHandler(this.Btn_Cancle_Click);
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Ok.Location = new System.Drawing.Point(316, 79);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.Btn_Ok.TabIndex = 1;
            this.Btn_Ok.Text = "开始";
            this.Btn_Ok.UseVisualStyleBackColor = true;
            this.Btn_Ok.Click += new System.EventHandler(this.Btn_Ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "保存位置：";
            // 
            // TXT_FileName
            // 
            this.TXT_FileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_FileName.Location = new System.Drawing.Point(14, 24);
            this.TXT_FileName.Name = "TXT_FileName";
            this.TXT_FileName.Size = new System.Drawing.Size(377, 21);
            this.TXT_FileName.TabIndex = 3;
            this.TXT_FileName.Leave += new System.EventHandler(this.TXT_FileName_Leave);
            // 
            // Btn_OpenDialog
            // 
            this.Btn_OpenDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_OpenDialog.Location = new System.Drawing.Point(397, 24);
            this.Btn_OpenDialog.Name = "Btn_OpenDialog";
            this.Btn_OpenDialog.Size = new System.Drawing.Size(75, 23);
            this.Btn_OpenDialog.TabIndex = 4;
            this.Btn_OpenDialog.Text = "浏览";
            this.Btn_OpenDialog.UseVisualStyleBackColor = true;
            this.Btn_OpenDialog.Click += new System.EventHandler(this.Btn_OpenDialog_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "MPQ";
            this.saveFileDialog1.FileName = "patch-zhTW-6.MPQ";
            this.saveFileDialog1.Filter = "MPQ文件|*.mpq|所有文件|*.*";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // LB_State
            // 
            this.LB_State.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_State.Location = new System.Drawing.Point(12, 53);
            this.LB_State.Name = "LB_State";
            this.LB_State.Size = new System.Drawing.Size(460, 23);
            this.LB_State.TabIndex = 5;
            this.LB_State.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmMPQMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 114);
            this.Controls.Add(this.LB_State);
            this.Controls.Add(this.Btn_OpenDialog);
            this.Controls.Add(this.TXT_FileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Ok);
            this.Controls.Add(this.Btn_Cancle);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 150);
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "FrmMPQMaker";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "问号补丁生成工具";
            this.Load += new System.EventHandler(this.FrmMPQMaker_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMPQMaker_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Cancle;
        private System.Windows.Forms.Button Btn_Ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXT_FileName;
        private System.Windows.Forms.Button Btn_OpenDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label LB_State;
    }
}