namespace WOWItemMaker
{
    partial class ExecuteSql
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExecuteSql));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SqlTextBox = new System.Windows.Forms.TextBox();
            this.ExecuteBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.ResaultList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ResaultStatLabel = new System.Windows.Forms.Label();
            this.BackBtn = new System.Windows.Forms.Button();
            this.NextBtn = new System.Windows.Forms.Button();
            this.PageList = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.RowsPerPageTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(468, 267);
            this.dataGridView1.TabIndex = 0;
            // 
            // SqlTextBox
            // 
            this.SqlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SqlTextBox.Location = new System.Drawing.Point(12, 24);
            this.SqlTextBox.Multiline = true;
            this.SqlTextBox.Name = "SqlTextBox";
            this.SqlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SqlTextBox.Size = new System.Drawing.Size(468, 49);
            this.SqlTextBox.TabIndex = 1;
            // 
            // ExecuteBtn
            // 
            this.ExecuteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecuteBtn.Location = new System.Drawing.Point(324, 375);
            this.ExecuteBtn.Name = "ExecuteBtn";
            this.ExecuteBtn.Size = new System.Drawing.Size(75, 23);
            this.ExecuteBtn.TabIndex = 2;
            this.ExecuteBtn.Text = "执行";
            this.ExecuteBtn.UseVisualStyleBackColor = true;
            this.ExecuteBtn.Click += new System.EventHandler(this.ExecuteBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "SQL:";
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(405, 375);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 4;
            this.CloseBtn.Text = "关闭";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // ResaultList
            // 
            this.ResaultList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ResaultList.FormattingEnabled = true;
            this.ResaultList.Location = new System.Drawing.Point(59, 76);
            this.ResaultList.Name = "ResaultList";
            this.ResaultList.Size = new System.Drawing.Size(121, 20);
            this.ResaultList.TabIndex = 5;
            this.ResaultList.SelectedIndexChanged += new System.EventHandler(this.ResaultList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "结果：";
            // 
            // ResaultStatLabel
            // 
            this.ResaultStatLabel.Location = new System.Drawing.Point(297, 76);
            this.ResaultStatLabel.Name = "ResaultStatLabel";
            this.ResaultStatLabel.Size = new System.Drawing.Size(183, 20);
            this.ResaultStatLabel.TabIndex = 7;
            this.ResaultStatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BackBtn
            // 
            this.BackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackBtn.Enabled = false;
            this.BackBtn.Location = new System.Drawing.Point(14, 375);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(75, 23);
            this.BackBtn.TabIndex = 8;
            this.BackBtn.Text = "上一页";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // NextBtn
            // 
            this.NextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NextBtn.Enabled = false;
            this.NextBtn.Location = new System.Drawing.Point(95, 375);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(75, 23);
            this.NextBtn.TabIndex = 9;
            this.NextBtn.Text = "下一页";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // PageList
            // 
            this.PageList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PageList.Enabled = false;
            this.PageList.FormattingEnabled = true;
            this.PageList.Location = new System.Drawing.Point(176, 377);
            this.PageList.Name = "PageList";
            this.PageList.Size = new System.Drawing.Size(40, 20);
            this.PageList.TabIndex = 10;
            this.PageList.SelectedIndexChanged += new System.EventHandler(this.PageList_SelectedIndexChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "提示";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "每页显示";
            // 
            // RowsPerPageTextBox
            // 
            this.RowsPerPageTextBox.Location = new System.Drawing.Point(245, 77);
            this.RowsPerPageTextBox.Name = "RowsPerPageTextBox";
            this.RowsPerPageTextBox.Size = new System.Drawing.Size(46, 21);
            this.RowsPerPageTextBox.TabIndex = 12;
            this.RowsPerPageTextBox.Text = "500";
            this.RowsPerPageTextBox.TextChanged += new System.EventHandler(this.RowsPerPageTextBox_TextChanged);
            // 
            // ExecuteSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(492, 410);
            this.Controls.Add(this.RowsPerPageTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PageList);
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.ResaultStatLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ResaultList);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExecuteBtn);
            this.Controls.Add(this.SqlTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExecuteSql";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "执行SQL";
            this.Load += new System.EventHandler(this.ExecuteSql_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox SqlTextBox;
        private System.Windows.Forms.Button ExecuteBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.ComboBox ResaultList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ResaultStatLabel;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.ComboBox PageList;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RowsPerPageTextBox;
    }
}