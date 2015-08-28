namespace WOWItemMaker
{
    partial class SearchItemsFormcs
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
            this.Mail_SelectAllBtn = new System.Windows.Forms.Button();
            this.Mail_SearchItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.Mail_AddItemsToListBtn = new System.Windows.Forms.Button();
            this.Mail_SearchItemsStrTextBox = new System.Windows.Forms.TextBox();
            this.Mail_SearchItemsTypeList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Mail_SearchItemsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Mail_SearchItemsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Mail_SelectAllBtn
            // 
            this.Mail_SelectAllBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Mail_SelectAllBtn.Location = new System.Drawing.Point(14, 229);
            this.Mail_SelectAllBtn.Name = "Mail_SelectAllBtn";
            this.Mail_SelectAllBtn.Size = new System.Drawing.Size(40, 23);
            this.Mail_SelectAllBtn.TabIndex = 13;
            this.Mail_SelectAllBtn.Text = "全选";
            this.Mail_SelectAllBtn.UseVisualStyleBackColor = true;
            this.Mail_SelectAllBtn.Click += new System.EventHandler(this.Mail_SelectAllBtn_Click);
            // 
            // Mail_SearchItemsDataGridView
            // 
            this.Mail_SearchItemsDataGridView.AllowUserToAddRows = false;
            this.Mail_SearchItemsDataGridView.AllowUserToDeleteRows = false;
            this.Mail_SearchItemsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Mail_SearchItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Mail_SearchItemsDataGridView.Location = new System.Drawing.Point(14, 55);
            this.Mail_SearchItemsDataGridView.Name = "Mail_SearchItemsDataGridView";
            this.Mail_SearchItemsDataGridView.RowTemplate.Height = 23;
            this.Mail_SearchItemsDataGridView.Size = new System.Drawing.Size(358, 168);
            this.Mail_SearchItemsDataGridView.TabIndex = 12;
            // 
            // Mail_AddItemsToListBtn
            // 
            this.Mail_AddItemsToListBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Mail_AddItemsToListBtn.Location = new System.Drawing.Point(297, 229);
            this.Mail_AddItemsToListBtn.Name = "Mail_AddItemsToListBtn";
            this.Mail_AddItemsToListBtn.Size = new System.Drawing.Size(75, 23);
            this.Mail_AddItemsToListBtn.TabIndex = 10;
            this.Mail_AddItemsToListBtn.Text = "添加";
            this.Mail_AddItemsToListBtn.UseVisualStyleBackColor = true;
            this.Mail_AddItemsToListBtn.Click += new System.EventHandler(this.Mail_AddItemsToListBtn_Click);
            // 
            // Mail_SearchItemsStrTextBox
            // 
            this.Mail_SearchItemsStrTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Mail_SearchItemsStrTextBox.Location = new System.Drawing.Point(95, 28);
            this.Mail_SearchItemsStrTextBox.Name = "Mail_SearchItemsStrTextBox";
            this.Mail_SearchItemsStrTextBox.Size = new System.Drawing.Size(277, 21);
            this.Mail_SearchItemsStrTextBox.TabIndex = 9;
            this.Mail_SearchItemsStrTextBox.TextChanged += new System.EventHandler(this.Mail_SearchItemsStrTextBox_TextChanged);
            // 
            // Mail_SearchItemsTypeList
            // 
            this.Mail_SearchItemsTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Mail_SearchItemsTypeList.FormattingEnabled = true;
            this.Mail_SearchItemsTypeList.Items.AddRange(new object[] {
            "物品ID",
            "物品名称"});
            this.Mail_SearchItemsTypeList.Location = new System.Drawing.Point(14, 28);
            this.Mail_SearchItemsTypeList.Name = "Mail_SearchItemsTypeList";
            this.Mail_SearchItemsTypeList.Size = new System.Drawing.Size(72, 20);
            this.Mail_SearchItemsTypeList.TabIndex = 8;
            this.Mail_SearchItemsTypeList.SelectedIndexChanged += new System.EventHandler(this.Mail_SearchItemsTypeList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "过滤：";
            // 
            // Mail_SearchItemsBtn
            // 
            this.Mail_SearchItemsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Mail_SearchItemsBtn.Location = new System.Drawing.Point(216, 229);
            this.Mail_SearchItemsBtn.Name = "Mail_SearchItemsBtn";
            this.Mail_SearchItemsBtn.Size = new System.Drawing.Size(75, 23);
            this.Mail_SearchItemsBtn.TabIndex = 14;
            this.Mail_SearchItemsBtn.Text = "刷新";
            this.Mail_SearchItemsBtn.UseVisualStyleBackColor = true;
            this.Mail_SearchItemsBtn.Click += new System.EventHandler(this.Mail_SearchItemsBtn_Click);
            // 
            // SearchItemsFormcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 264);
            this.Controls.Add(this.Mail_SearchItemsBtn);
            this.Controls.Add(this.Mail_SelectAllBtn);
            this.Controls.Add(this.Mail_SearchItemsDataGridView);
            this.Controls.Add(this.Mail_AddItemsToListBtn);
            this.Controls.Add(this.Mail_SearchItemsStrTextBox);
            this.Controls.Add(this.Mail_SearchItemsTypeList);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SearchItemsFormcs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SearchItemsFormcs";
            this.Load += new System.EventHandler(this.SearchItemsFormcs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Mail_SearchItemsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Mail_SelectAllBtn;
        private System.Windows.Forms.DataGridView Mail_SearchItemsDataGridView;
        private System.Windows.Forms.Button Mail_AddItemsToListBtn;
        private System.Windows.Forms.TextBox Mail_SearchItemsStrTextBox;
        private System.Windows.Forms.ComboBox Mail_SearchItemsTypeList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Mail_SearchItemsBtn;
    }
}