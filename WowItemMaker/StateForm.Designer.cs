namespace WOWItemMaker
{
    partial class StateForm
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
            this.StateTextBox = new System.Windows.Forms.Label();
            this.StateBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // StateTextBox
            // 
            this.StateTextBox.AutoSize = true;
            this.StateTextBox.Location = new System.Drawing.Point(56, 19);
            this.StateTextBox.Name = "StateTextBox";
            this.StateTextBox.Size = new System.Drawing.Size(101, 12);
            this.StateTextBox.TabIndex = 0;
            this.StateTextBox.Text = "正在执行操作……";
            this.StateTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StateBtn
            // 
            this.StateBtn.Location = new System.Drawing.Point(58, 41);
            this.StateBtn.Name = "StateBtn";
            this.StateBtn.Size = new System.Drawing.Size(75, 23);
            this.StateBtn.TabIndex = 1;
            this.StateBtn.Text = "确定";
            this.StateBtn.UseVisualStyleBackColor = true;
            this.StateBtn.Visible = false;
            this.StateBtn.Click += new System.EventHandler(this.StateBtn_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.toolTip1.ToolTipTitle = "执行操作时遇到问题：";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(129, 19);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "详细信息";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // StateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 76);
            this.ControlBox = false;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.StateBtn);
            this.Controls.Add(this.StateTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "当前状态";
            this.Load += new System.EventHandler(this.StateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StateTextBox;
        private System.Windows.Forms.Button StateBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}