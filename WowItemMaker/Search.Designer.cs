namespace WOWItemMaker
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.label1 = new System.Windows.Forms.Label();
            this.ItemNameTextBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.PageList = new System.Windows.Forms.ComboBox();
            this.NextBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.RowsPerPageTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "物品名称：";
            // 
            // ItemNameTextBox
            // 
            this.ItemNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemNameTextBox.Location = new System.Drawing.Point(84, 12);
            this.ItemNameTextBox.Name = "ItemNameTextBox";
            this.ItemNameTextBox.Size = new System.Drawing.Size(218, 21);
            this.ItemNameTextBox.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(419, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "全字匹配";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBtn.Location = new System.Drawing.Point(497, 10);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchBtn.TabIndex = 3;
            this.SearchBtn.Text = "搜索";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(560, 284);
            this.dataGridView1.TabIndex = 4;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.Location = new System.Drawing.Point(497, 329);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 5;
            this.CloseBtn.Text = "关闭";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // PageList
            // 
            this.PageList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PageList.Enabled = false;
            this.PageList.FormattingEnabled = true;
            this.PageList.Location = new System.Drawing.Point(174, 331);
            this.PageList.Name = "PageList";
            this.PageList.Size = new System.Drawing.Size(40, 20);
            this.PageList.TabIndex = 13;
            this.PageList.SelectedIndexChanged += new System.EventHandler(this.PageList_SelectedIndexChanged);
            // 
            // NextBtn
            // 
            this.NextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NextBtn.Enabled = false;
            this.NextBtn.Location = new System.Drawing.Point(93, 329);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(75, 23);
            this.NextBtn.TabIndex = 12;
            this.NextBtn.Text = "下一页";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackBtn.Enabled = false;
            this.BackBtn.Location = new System.Drawing.Point(12, 329);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(75, 23);
            this.BackBtn.TabIndex = 11;
            this.BackBtn.Text = "上一页";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // RowsPerPageTextBox
            // 
            this.RowsPerPageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RowsPerPageTextBox.Location = new System.Drawing.Point(367, 12);
            this.RowsPerPageTextBox.Name = "RowsPerPageTextBox";
            this.RowsPerPageTextBox.Size = new System.Drawing.Size(46, 21);
            this.RowsPerPageTextBox.TabIndex = 15;
            this.RowsPerPageTextBox.Text = "500";
            this.RowsPerPageTextBox.TextChanged += new System.EventHandler(this.RowsPerPageTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "每页显示";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "提示";
            // 
            // Search
            // 
            this.AcceptButton = this.SearchBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 364);
            this.Controls.Add(this.RowsPerPageTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PageList);
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ItemNameTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "物品搜索";
            this.Load += new System.EventHandler(this.Search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ItemNameTextBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.ComboBox PageList;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.TextBox RowsPerPageTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}