namespace WOWItemMaker
{
    partial class ServerManager
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Mail_ContentTextBox = new System.Windows.Forms.TextBox();
            this.Mail_TittleTextBox = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.Mail_ClearReceiverListBtn = new System.Windows.Forms.Button();
            this.Mail_DeleteReveicerCheckedBtn = new System.Windows.Forms.Button();
            this.Mail_AddReceiverBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Mail_ReceiverDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.Mail_ClearItemListBtn = new System.Windows.Forms.Button();
            this.Mail_DeleteCheckedItemsBtn = new System.Windows.Forms.Button();
            this.Mail_AddItemBtn = new System.Windows.Forms.Button();
            this.Mail_ItemDataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.Mail_SendBtn = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.realmdDBList = new System.Windows.Forms.ComboBox();
            this.charactersDBList = new System.Windows.Forms.ComboBox();
            this.mangosDBList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PWDTextBox = new System.Windows.Forms.TextBox();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.HostNameTextBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.ExpireTime_Days_TextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ExpireTime_Hours_TextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ExpireTime_Minuets_TextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ExpireTime_Seconds_TextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Mail_ReceiverDataGridView)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Mail_ItemDataGridView)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(484, 264);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Controls.Add(this.Mail_SendBtn);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(476, 238);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "发送邮件";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(470, 200);
            this.tabControl2.TabIndex = 9;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.label1);
            this.tabPage5.Controls.Add(this.Mail_ContentTextBox);
            this.tabPage5.Controls.Add(this.Mail_TittleTextBox);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(462, 174);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "邮件内容";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "内容：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标题：";
            // 
            // Mail_ContentTextBox
            // 
            this.Mail_ContentTextBox.Location = new System.Drawing.Point(8, 57);
            this.Mail_ContentTextBox.Multiline = true;
            this.Mail_ContentTextBox.Name = "Mail_ContentTextBox";
            this.Mail_ContentTextBox.Size = new System.Drawing.Size(448, 111);
            this.Mail_ContentTextBox.TabIndex = 7;
            // 
            // Mail_TittleTextBox
            // 
            this.Mail_TittleTextBox.Location = new System.Drawing.Point(8, 18);
            this.Mail_TittleTextBox.Name = "Mail_TittleTextBox";
            this.Mail_TittleTextBox.Size = new System.Drawing.Size(448, 21);
            this.Mail_TittleTextBox.TabIndex = 1;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.Mail_ClearReceiverListBtn);
            this.tabPage6.Controls.Add(this.Mail_DeleteReveicerCheckedBtn);
            this.tabPage6.Controls.Add(this.Mail_AddReceiverBtn);
            this.tabPage6.Controls.Add(this.label2);
            this.tabPage6.Controls.Add(this.Mail_ReceiverDataGridView);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(462, 174);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "收件人";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // Mail_ClearReceiverListBtn
            // 
            this.Mail_ClearReceiverListBtn.Location = new System.Drawing.Point(222, 148);
            this.Mail_ClearReceiverListBtn.Name = "Mail_ClearReceiverListBtn";
            this.Mail_ClearReceiverListBtn.Size = new System.Drawing.Size(75, 23);
            this.Mail_ClearReceiverListBtn.TabIndex = 9;
            this.Mail_ClearReceiverListBtn.Text = "清空列表";
            this.Mail_ClearReceiverListBtn.UseVisualStyleBackColor = true;
            this.Mail_ClearReceiverListBtn.Click += new System.EventHandler(this.Mail_ClearReceiverListBtn_Click);
            // 
            // Mail_DeleteReveicerCheckedBtn
            // 
            this.Mail_DeleteReveicerCheckedBtn.Location = new System.Drawing.Point(303, 148);
            this.Mail_DeleteReveicerCheckedBtn.Name = "Mail_DeleteReveicerCheckedBtn";
            this.Mail_DeleteReveicerCheckedBtn.Size = new System.Drawing.Size(75, 23);
            this.Mail_DeleteReveicerCheckedBtn.TabIndex = 5;
            this.Mail_DeleteReveicerCheckedBtn.Text = "删除选中";
            this.Mail_DeleteReveicerCheckedBtn.UseVisualStyleBackColor = true;
            this.Mail_DeleteReveicerCheckedBtn.Click += new System.EventHandler(this.Mail_DeleteReveicerCheckedBtn_Click);
            // 
            // Mail_AddReceiverBtn
            // 
            this.Mail_AddReceiverBtn.Location = new System.Drawing.Point(384, 148);
            this.Mail_AddReceiverBtn.Name = "Mail_AddReceiverBtn";
            this.Mail_AddReceiverBtn.Size = new System.Drawing.Size(75, 23);
            this.Mail_AddReceiverBtn.TabIndex = 4;
            this.Mail_AddReceiverBtn.Text = "添加...";
            this.Mail_AddReceiverBtn.UseVisualStyleBackColor = true;
            this.Mail_AddReceiverBtn.Click += new System.EventHandler(this.Mail_AddReceiverBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "收件人：";
            // 
            // Mail_ReceiverDataGridView
            // 
            this.Mail_ReceiverDataGridView.AllowUserToAddRows = false;
            this.Mail_ReceiverDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Mail_ReceiverDataGridView.Location = new System.Drawing.Point(3, 18);
            this.Mail_ReceiverDataGridView.Name = "Mail_ReceiverDataGridView";
            this.Mail_ReceiverDataGridView.RowTemplate.Height = 23;
            this.Mail_ReceiverDataGridView.Size = new System.Drawing.Size(453, 124);
            this.Mail_ReceiverDataGridView.TabIndex = 2;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.Mail_ClearItemListBtn);
            this.tabPage7.Controls.Add(this.Mail_DeleteCheckedItemsBtn);
            this.tabPage7.Controls.Add(this.Mail_AddItemBtn);
            this.tabPage7.Controls.Add(this.Mail_ItemDataGridView);
            this.tabPage7.Controls.Add(this.label3);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(462, 174);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "附加物品";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // Mail_ClearItemListBtn
            // 
            this.Mail_ClearItemListBtn.Location = new System.Drawing.Point(222, 148);
            this.Mail_ClearItemListBtn.Name = "Mail_ClearItemListBtn";
            this.Mail_ClearItemListBtn.Size = new System.Drawing.Size(75, 23);
            this.Mail_ClearItemListBtn.TabIndex = 15;
            this.Mail_ClearItemListBtn.Text = "清空列表";
            this.Mail_ClearItemListBtn.UseVisualStyleBackColor = true;
            this.Mail_ClearItemListBtn.Click += new System.EventHandler(this.Mail_ClearItemListBtn_Click);
            // 
            // Mail_DeleteCheckedItemsBtn
            // 
            this.Mail_DeleteCheckedItemsBtn.Location = new System.Drawing.Point(303, 148);
            this.Mail_DeleteCheckedItemsBtn.Name = "Mail_DeleteCheckedItemsBtn";
            this.Mail_DeleteCheckedItemsBtn.Size = new System.Drawing.Size(75, 23);
            this.Mail_DeleteCheckedItemsBtn.TabIndex = 11;
            this.Mail_DeleteCheckedItemsBtn.Text = "删除选中";
            this.Mail_DeleteCheckedItemsBtn.UseVisualStyleBackColor = true;
            this.Mail_DeleteCheckedItemsBtn.Click += new System.EventHandler(this.Mail_DeleteCheckedItemsBtn_Click);
            // 
            // Mail_AddItemBtn
            // 
            this.Mail_AddItemBtn.Location = new System.Drawing.Point(384, 148);
            this.Mail_AddItemBtn.Name = "Mail_AddItemBtn";
            this.Mail_AddItemBtn.Size = new System.Drawing.Size(75, 23);
            this.Mail_AddItemBtn.TabIndex = 10;
            this.Mail_AddItemBtn.Text = "添加...";
            this.Mail_AddItemBtn.UseVisualStyleBackColor = true;
            this.Mail_AddItemBtn.Click += new System.EventHandler(this.Mail_AddItemBtn_Click);
            // 
            // Mail_ItemDataGridView
            // 
            this.Mail_ItemDataGridView.AllowUserToAddRows = false;
            this.Mail_ItemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Mail_ItemDataGridView.Location = new System.Drawing.Point(3, 18);
            this.Mail_ItemDataGridView.Name = "Mail_ItemDataGridView";
            this.Mail_ItemDataGridView.RowTemplate.Height = 23;
            this.Mail_ItemDataGridView.Size = new System.Drawing.Size(453, 124);
            this.Mail_ItemDataGridView.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "附加物品：";
            // 
            // Mail_SendBtn
            // 
            this.Mail_SendBtn.Location = new System.Drawing.Point(391, 209);
            this.Mail_SendBtn.Name = "Mail_SendBtn";
            this.Mail_SendBtn.Size = new System.Drawing.Size(75, 23);
            this.Mail_SendBtn.TabIndex = 8;
            this.Mail_SendBtn.Text = "发送";
            this.Mail_SendBtn.UseVisualStyleBackColor = true;
            this.Mail_SendBtn.Click += new System.EventHandler(this.Mail_SendBtn_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.realmdDBList);
            this.tabPage1.Controls.Add(this.charactersDBList);
            this.tabPage1.Controls.Add(this.mangosDBList);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.PWDTextBox);
            this.tabPage1.Controls.Add(this.UserNameTextBox);
            this.tabPage1.Controls.Add(this.HostNameTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(476, 238);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "配置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 28;
            this.label10.Text = "realmd库：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "characters库：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 26;
            this.label8.Text = "mangos库：";
            // 
            // realmdDBList
            // 
            this.realmdDBList.FormattingEnabled = true;
            this.realmdDBList.Location = new System.Drawing.Point(103, 139);
            this.realmdDBList.Name = "realmdDBList";
            this.realmdDBList.Size = new System.Drawing.Size(197, 20);
            this.realmdDBList.TabIndex = 25;
            this.realmdDBList.Text = "realmd";
            this.realmdDBList.SelectedIndexChanged += new System.EventHandler(this.realmdDBList_SelectedIndexChanged);
            this.realmdDBList.TextUpdate += new System.EventHandler(this.realmdDBList_SelectedIndexChanged);
            this.realmdDBList.DropDown += new System.EventHandler(this.DBList_DropDown);
            // 
            // charactersDBList
            // 
            this.charactersDBList.FormattingEnabled = true;
            this.charactersDBList.Location = new System.Drawing.Point(103, 113);
            this.charactersDBList.Name = "charactersDBList";
            this.charactersDBList.Size = new System.Drawing.Size(197, 20);
            this.charactersDBList.TabIndex = 24;
            this.charactersDBList.Text = "characters";
            this.charactersDBList.SelectedIndexChanged += new System.EventHandler(this.charactersDBList_SelectedIndexChanged);
            this.charactersDBList.TextUpdate += new System.EventHandler(this.charactersDBList_SelectedIndexChanged);
            this.charactersDBList.DropDown += new System.EventHandler(this.DBList_DropDown);
            // 
            // mangosDBList
            // 
            this.mangosDBList.FormattingEnabled = true;
            this.mangosDBList.Location = new System.Drawing.Point(103, 87);
            this.mangosDBList.Name = "mangosDBList";
            this.mangosDBList.Size = new System.Drawing.Size(197, 20);
            this.mangosDBList.TabIndex = 23;
            this.mangosDBList.Text = "mangos";
            this.mangosDBList.SelectedIndexChanged += new System.EventHandler(this.mangosDBList_SelectedIndexChanged);
            this.mangosDBList.TextUpdate += new System.EventHandler(this.mangosDBList_SelectedIndexChanged);
            this.mangosDBList.DropDown += new System.EventHandler(this.DBList_DropDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "密码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "用户名：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "服务器地址：";
            // 
            // PWDTextBox
            // 
            this.PWDTextBox.Location = new System.Drawing.Point(103, 60);
            this.PWDTextBox.Name = "PWDTextBox";
            this.PWDTextBox.PasswordChar = '*';
            this.PWDTextBox.Size = new System.Drawing.Size(197, 21);
            this.PWDTextBox.TabIndex = 19;
            this.PWDTextBox.Text = "mangos";
            this.PWDTextBox.TextChanged += new System.EventHandler(this.PWDTextBox_TextChanged);
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(103, 33);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(197, 21);
            this.UserNameTextBox.TabIndex = 18;
            this.UserNameTextBox.Text = "mangos";
            this.UserNameTextBox.TextChanged += new System.EventHandler(this.UserNameTextBox_TextChanged);
            // 
            // HostNameTextBox
            // 
            this.HostNameTextBox.Location = new System.Drawing.Point(103, 7);
            this.HostNameTextBox.Name = "HostNameTextBox";
            this.HostNameTextBox.Size = new System.Drawing.Size(197, 21);
            this.HostNameTextBox.TabIndex = 17;
            this.HostNameTextBox.Text = "LocalHost";
            this.HostNameTextBox.TextChanged += new System.EventHandler(this.HostNameTextBox_TextChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(462, 174);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "日期";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 12);
            this.label11.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.ExpireTime_Seconds_TextBox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.ExpireTime_Minuets_TextBox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.ExpireTime_Hours_TextBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.ExpireTime_Days_TextBox);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(3, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 82);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "终止日期";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 47);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // ExpireTime_Days_TextBox
            // 
            this.ExpireTime_Days_TextBox.Location = new System.Drawing.Point(26, 17);
            this.ExpireTime_Days_TextBox.Name = "ExpireTime_Days_TextBox";
            this.ExpireTime_Days_TextBox.Size = new System.Drawing.Size(30, 21);
            this.ExpireTime_Days_TextBox.TabIndex = 2;
            this.ExpireTime_Days_TextBox.Text = "90";
            this.ExpireTime_Days_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(62, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "天";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(263, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 9;
            this.label15.Text = "秒后到期";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(26, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 10;
            this.label16.Text = "到这个时间";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(97, 44);
            this.dateTimePicker1.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // ExpireTime_Hours_TextBox
            // 
            this.ExpireTime_Hours_TextBox.Location = new System.Drawing.Point(85, 17);
            this.ExpireTime_Hours_TextBox.Name = "ExpireTime_Hours_TextBox";
            this.ExpireTime_Hours_TextBox.Size = new System.Drawing.Size(30, 21);
            this.ExpireTime_Hours_TextBox.TabIndex = 4;
            this.ExpireTime_Hours_TextBox.Text = "0";
            this.ExpireTime_Hours_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(121, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 5;
            this.label13.Text = "小时";
            // 
            // ExpireTime_Minuets_TextBox
            // 
            this.ExpireTime_Minuets_TextBox.AccessibleDescription = "";
            this.ExpireTime_Minuets_TextBox.Location = new System.Drawing.Point(156, 17);
            this.ExpireTime_Minuets_TextBox.Name = "ExpireTime_Minuets_TextBox";
            this.ExpireTime_Minuets_TextBox.Size = new System.Drawing.Size(30, 21);
            this.ExpireTime_Minuets_TextBox.TabIndex = 6;
            this.ExpireTime_Minuets_TextBox.Text = "0";
            this.ExpireTime_Minuets_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(192, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 7;
            this.label14.Text = "分钟";
            // 
            // ExpireTime_Seconds_TextBox
            // 
            this.ExpireTime_Seconds_TextBox.Location = new System.Drawing.Point(227, 17);
            this.ExpireTime_Seconds_TextBox.Name = "ExpireTime_Seconds_TextBox";
            this.ExpireTime_Seconds_TextBox.Size = new System.Drawing.Size(30, 21);
            this.ExpireTime_Seconds_TextBox.TabIndex = 8;
            this.ExpireTime_Seconds_TextBox.Text = "0";
            this.ExpireTime_Seconds_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(456, 80);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送日期";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(26, 20);
            this.dateTimePicker2.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker2.TabIndex = 0;
            // 
            // ServerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 264);
            this.Controls.Add(this.tabControl1);
            this.Name = "ServerManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务器管理";
            this.Load += new System.EventHandler(this.ServerManager_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Mail_ReceiverDataGridView)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Mail_ItemDataGridView)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView Mail_ReceiverDataGridView;
        private System.Windows.Forms.TextBox Mail_TittleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Mail_SendBtn;
        private System.Windows.Forms.TextBox Mail_ContentTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView Mail_ItemDataGridView;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Button Mail_DeleteReveicerCheckedBtn;
        private System.Windows.Forms.Button Mail_AddReceiverBtn;
        private System.Windows.Forms.Button Mail_ClearReceiverListBtn;
        private System.Windows.Forms.Button Mail_ClearItemListBtn;
        private System.Windows.Forms.Button Mail_DeleteCheckedItemsBtn;
        private System.Windows.Forms.Button Mail_AddItemBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PWDTextBox;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.TextBox HostNameTextBox;
        private System.Windows.Forms.ComboBox mangosDBList;
        private System.Windows.Forms.ComboBox realmdDBList;
        private System.Windows.Forms.ComboBox charactersDBList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ExpireTime_Days_TextBox;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox ExpireTime_Seconds_TextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox ExpireTime_Minuets_TextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox ExpireTime_Hours_TextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;

    }
}