namespace WOWItemMaker
{
    partial class SetConn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetConn));
            this.ConnBtn = new System.Windows.Forms.Button();
            this.DBList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PWDTextBox = new System.Windows.Forms.TextBox();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.HostNameTextBox = new System.Windows.Forms.TextBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.DbStructList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SaveConnInfoCheckBox = new System.Windows.Forms.CheckBox();
            this.SavePwdCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ConnBtn
            // 
            this.ConnBtn.Location = new System.Drawing.Point(186, 139);
            this.ConnBtn.Name = "ConnBtn";
            this.ConnBtn.Size = new System.Drawing.Size(50, 23);
            this.ConnBtn.TabIndex = 1;
            this.ConnBtn.Text = "连接";
            this.ConnBtn.UseVisualStyleBackColor = true;
            this.ConnBtn.Click += new System.EventHandler(this.ConnBtn_Click);
            // 
            // DBList
            // 
            this.DBList.FormattingEnabled = true;
            this.DBList.Location = new System.Drawing.Point(95, 86);
            this.DBList.Name = "DBList";
            this.DBList.Size = new System.Drawing.Size(197, 20);
            this.DBList.TabIndex = 6;
            this.DBList.Text = "world";
            this.DBList.DropDown += new System.EventHandler(this.GetDBListBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "目标数据库：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "用户名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "服务器地址：";
            // 
            // PWDTextBox
            // 
            this.PWDTextBox.Location = new System.Drawing.Point(95, 59);
            this.PWDTextBox.Name = "PWDTextBox";
            this.PWDTextBox.PasswordChar = '*';
            this.PWDTextBox.Size = new System.Drawing.Size(197, 21);
            this.PWDTextBox.TabIndex = 5;
            this.PWDTextBox.Text = "root";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(95, 32);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(197, 21);
            this.UserNameTextBox.TabIndex = 4;
            this.UserNameTextBox.Text = "root";
            // 
            // HostNameTextBox
            // 
            this.HostNameTextBox.Location = new System.Drawing.Point(95, 6);
            this.HostNameTextBox.Name = "HostNameTextBox";
            this.HostNameTextBox.Size = new System.Drawing.Size(197, 21);
            this.HostNameTextBox.TabIndex = 3;
            this.HostNameTextBox.Text = "LocalHost";
            // 
            // CloseBtn
            // 
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(242, 139);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(50, 23);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "取消";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // DbStructList
            // 
            this.DbStructList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DbStructList.FormattingEnabled = true;
            this.DbStructList.Items.AddRange(new object[] {
            "3.0.X",
            "3.1.X",
            "3.2.X",
            "3.3.X",
            "真爱XV",
            "3.3.5",
            "3.3.5(TC2)"});
            this.DbStructList.Location = new System.Drawing.Point(95, 112);
            this.DbStructList.Name = "DbStructList";
            this.DbStructList.Size = new System.Drawing.Size(197, 20);
            this.DbStructList.TabIndex = 18;
            this.DbStructList.SelectedIndexChanged += new System.EventHandler(this.DbStructList_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "数据库结构：";
            // 
            // SaveConnInfoCheckBox
            // 
            this.SaveConnInfoCheckBox.AutoSize = true;
            this.SaveConnInfoCheckBox.Location = new System.Drawing.Point(6, 143);
            this.SaveConnInfoCheckBox.Name = "SaveConnInfoCheckBox";
            this.SaveConnInfoCheckBox.Size = new System.Drawing.Size(96, 16);
            this.SaveConnInfoCheckBox.TabIndex = 20;
            this.SaveConnInfoCheckBox.Text = "记住连接信息";
            this.SaveConnInfoCheckBox.UseVisualStyleBackColor = true;
            this.SaveConnInfoCheckBox.CheckedChanged += new System.EventHandler(this.SaveConnInfoCheckBox_CheckedChanged);
            // 
            // SavePwdCheckBox
            // 
            this.SavePwdCheckBox.AutoSize = true;
            this.SavePwdCheckBox.Enabled = false;
            this.SavePwdCheckBox.Location = new System.Drawing.Point(108, 143);
            this.SavePwdCheckBox.Name = "SavePwdCheckBox";
            this.SavePwdCheckBox.Size = new System.Drawing.Size(72, 16);
            this.SavePwdCheckBox.TabIndex = 21;
            this.SavePwdCheckBox.Text = "包括密码";
            this.SavePwdCheckBox.UseVisualStyleBackColor = true;
            this.SavePwdCheckBox.CheckedChanged += new System.EventHandler(this.SavePwdCheckBox_CheckedChanged);
            // 
            // SetConn
            // 
            this.AcceptButton = this.ConnBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(304, 174);
            this.Controls.Add(this.SavePwdCheckBox);
            this.Controls.Add(this.SaveConnInfoCheckBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DbStructList);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.ConnBtn);
            this.Controls.Add(this.DBList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PWDTextBox);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.HostNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SetConn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "连接数据库";
            this.Load += new System.EventHandler(this.SetConn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnBtn;
        private System.Windows.Forms.ComboBox DBList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PWDTextBox;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.TextBox HostNameTextBox;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.ComboBox DbStructList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox SaveConnInfoCheckBox;
        private System.Windows.Forms.CheckBox SavePwdCheckBox;

    }
}