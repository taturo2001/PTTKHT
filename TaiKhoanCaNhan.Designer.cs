namespace ProjectWFA
{
    partial class TaiKhoanCaNhan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaiKhoanCaNhan));
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbDisplayName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbPassWord = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbNewPassWord = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbReEnterPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbUserName
            // 
            this.txbUserName.Location = new System.Drawing.Point(288, 81);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.ReadOnly = true;
            this.txbUserName.Size = new System.Drawing.Size(188, 27);
            this.txbUserName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(32, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // txbDisplayName
            // 
            this.txbDisplayName.Location = new System.Drawing.Point(288, 141);
            this.txbDisplayName.Name = "txbDisplayName";
            this.txbDisplayName.Size = new System.Drawing.Size(188, 27);
            this.txbDisplayName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(32, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên hiển thị:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txbPassWord
            // 
            this.txbPassWord.Location = new System.Drawing.Point(288, 191);
            this.txbPassWord.Name = "txbPassWord";
            this.txbPassWord.Size = new System.Drawing.Size(188, 27);
            this.txbPassWord.TabIndex = 4;
            this.txbPassWord.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(32, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mật khẩu:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txbNewPassWord
            // 
            this.txbNewPassWord.Location = new System.Drawing.Point(288, 241);
            this.txbNewPassWord.Name = "txbNewPassWord";
            this.txbNewPassWord.Size = new System.Drawing.Size(188, 27);
            this.txbNewPassWord.TabIndex = 4;
            this.txbNewPassWord.UseSystemPasswordChar = true;
            this.txbNewPassWord.TextChanged += new System.EventHandler(this.txbNewPassWord_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(32, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mật khẩu mới:";
            // 
            // txbReEnterPass
            // 
            this.txbReEnterPass.Location = new System.Drawing.Point(288, 289);
            this.txbReEnterPass.Name = "txbReEnterPass";
            this.txbReEnterPass.Size = new System.Drawing.Size(188, 27);
            this.txbReEnterPass.TabIndex = 4;
            this.txbReEnterPass.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(32, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 24);
            this.label6.TabIndex = 3;
            this.label6.Text = "Xác nhận mật khẩu mới:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(288, 352);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(82, 60);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(394, 352);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 60);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // TaiKhoanCaNhan
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(505, 440);
            this.Controls.Add(this.txbReEnterPass);
            this.Controls.Add(this.txbNewPassWord);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbPassWord);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbDisplayName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TaiKhoanCaNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin cá nhân";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label2;
        private Label label3;
        private TextBox txbUserName;
        private TextBox txbDisplayName;
        private TextBox txbPassWord;
        private Label label4;
        private TextBox txbNewPassWord;
        private Label label5;
        private TextBox txbReEnterPass;
        private Label label6;
        private Button btnUpdate;
        private Button btnExit;
    }
}