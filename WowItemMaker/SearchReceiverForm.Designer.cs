namespace WOWItemMaker
{
    partial class SearchReceiverForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.Mail_SearchReceiverTypeList = new System.Windows.Forms.ComboBox();
            this.Mail_SearchReceiverStrTextBox = new System.Windows.Forms.TextBox();
            this.Mail_AddReceiverToListBtn = new System.Windows.Forms.Button();
            this.Mail_RefreshReceiverBtn = new System.Windows.Forms.Button();
            this.Mail_SearchReceiverDataGridView = new System.Windows.Forms.DataGridView();
            this.Mail_SelectAllReceiverBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Mail_SearchReceiverDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "过滤：";
            // 
            // Mail_SearchReceiverTypeList
            // 
            this.Mail_SearchReceiverTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Mail_SearchReceiverTypeList.FormattingEnabled = true;
            this.Mail_SearchReceiverTypeList.Items.AddRange(new object[] {
            "账号ID",
            "账号名称",
            "角色ID",
            "角色名称"});
            this.Mail_SearchReceiverTypeList.Location = new System.Drawing.Point(12, 28);
            this.Mail_SearchReceiverTypeList.Name = "Mail_SearchReceiverTypeList";
            this.Mail_SearchReceiverTypeList.Size = new System.Drawing.Size(72, 20);
            this.Mail_SearchReceiverTypeList.TabIndex = 1;
            this.Mail_SearchReceiverTypeList.SelectedIndexChanged += new System.EventHandler(this.Mail_SearchReceiverTypeList_SelectedIndexChanged);
            // 
            // Mail_SearchReceiverStrTextBox
            // 
            this.Mail_SearchReceiverStrTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Mail_SearchReceiverStrTextBox.Location = new System.Drawing.Point(93, 28);
            this.Mail_SearchReceiverStrTextBox.Name = "Mail_SearchReceiverStrTextBox";
            this.Mail_SearchReceiverStrTextBox.Size = new System.Drawing.Size(329, 21);
            this.Mail_SearchReceiverStrTextBox.TabIndex = 2;
            this.Mail_SearchReceiverStrTextBox.TextChanged += new System.EventHandler(this.Mail_SearchReceiverStrTextBox_TextChanged);
            // 
            // Mail_AddReceiverToListBtn
            // 
            this.Mail_AddReceiverToListBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Mail_AddReceiverToListBtn.Location = new System.Drawing.Point(347, 229);
            this.Mail_AddReceiverToListBtn.Name = "Mail_AddReceiverToListBtn";
            this.Mail_AddReceiverToListBtn.Size = new System.Drawing.Size(75, 23);
            this.Mail_AddReceiverToListBtn.TabIndex = 3;
            this.Mail_AddReceiverToListBtn.Text = "添加";
            this.Mail_AddReceiverToListBtn.UseVisualStyleBackColor = true;
            this.Mail_AddReceiverToListBtn.Click += new System.EventHandler(this.Mail_AddReceiverToListBtn_Click);
            // 
            // Mail_RefreshReceiverBtn
            // 
            this.Mail_RefreshReceiverBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Mail_RefreshReceiverBtn.Location = new System.Drawing.Point(266, 229);
            this.Mail_RefreshReceiverBtn.Name = "Mail_RefreshReceiverBtn";
            this.Mail_RefreshReceiverBtn.Size = new System.Drawing.Size(75, 23);
            this.Mail_RefreshReceiverBtn.TabIndex = 4;
            this.Mail_RefreshReceiverBtn.Text = "刷新";
            this.Mail_RefreshReceiverBtn.UseVisualStyleBackColor = true;
            this.Mail_RefreshReceiverBtn.Click += new System.EventHandler(this.Mail_RefreshReceiverBtn_Click);
            // 
            // Mail_SearchReceiverDataGridView
            // 
            this.Mail_SearchReceiverDataGridView.AllowUserToAddRows = false;
            this.Mail_SearchReceiverDataGridView.AllowUserToDeleteRows = false;
            this.Mail_SearchReceiverDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Mail_SearchReceiverDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Mail_SearchReceiverDataGridView.Location = new System.Drawing.Point(12, 55);
            this.Mail_SearchReceiverDataGridView.Name = "Mail_SearchReceiverDataGridView";
            this.Mail_SearchReceiverDataGridView.RowTemplate.Height = 23;
            this.Mail_SearchReceiverDataGridView.Size = new System.Drawing.Size(410, 168);
            this.Mail_SearchReceiverDataGridView.TabIndex = 5;
            // 
            // Mail_SelectAllReceiverBtn
            // 
            this.Mail_SelectAllReceiverBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Mail_SelectAllReceiverBtn.Location = new System.Drawing.Point(12, 229);
            this.Mail_SelectAllReceiverBtn.Name = "Mail_SelectAllReceiverBtn";
            this.Mail_SelectAllReceiverBtn.Size = new System.Drawing.Size(40, 23);
            this.Mail_SelectAllReceiverBtn.TabIndex = 6;
            this.Mail_SelectAllReceiverBtn.Text = "全选";
            this.Mail_SelectAllReceiverBtn.UseVisualStyleBackColor = true;
            this.Mail_SelectAllReceiverBtn.Click += new System.EventHandler(this.Mail_SelectAllReceiverBtn_Click);
            // 
            // SearchReceiverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 264);
            this.Controls.Add(this.Mail_SelectAllReceiverBtn);
            this.Controls.Add(this.Mail_SearchReceiverDataGridView);
            this.Controls.Add(this.Mail_RefreshReceiverBtn);
            this.Controls.Add(this.Mail_AddReceiverToListBtn);
            this.Controls.Add(this.Mail_SearchReceiverStrTextBox);
            this.Controls.Add(this.Mail_SearchReceiverTypeList);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SearchReceiverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加收件人";
            this.Load += new System.EventHandler(this.SearchReceiverFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Mail_SearchReceiverDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Mail_SearchReceiverTypeList;
        private System.Windows.Forms.TextBox Mail_SearchReceiverStrTextBox;
        private System.Windows.Forms.Button Mail_AddReceiverToListBtn;
        private System.Windows.Forms.Button Mail_RefreshReceiverBtn;
        private System.Windows.Forms.DataGridView Mail_SearchReceiverDataGridView;
        private System.Windows.Forms.Button Mail_SelectAllReceiverBtn;
    }
}