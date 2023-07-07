
namespace DotSpatial_期中综合
{
    partial class login
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
            this.tabLogin = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Local = new System.Windows.Forms.CheckBox();
            this.DataBase = new System.Windows.Forms.CheckBox();
            this.LoginIn = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnSendV = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxVerification = new System.Windows.Forms.TextBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabLogin.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabLogin
            // 
            this.tabLogin.Controls.Add(this.tabPage1);
            this.tabLogin.Controls.Add(this.tabPage2);
            this.tabLogin.Location = new System.Drawing.Point(4, 9);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.SelectedIndex = 0;
            this.tabLogin.Size = new System.Drawing.Size(382, 272);
            this.tabLogin.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Local);
            this.tabPage1.Controls.Add(this.DataBase);
            this.tabPage1.Controls.Add(this.LoginIn);
            this.tabPage1.Controls.Add(this.txtPassword);
            this.tabPage1.Controls.Add(this.txtUserName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(374, 243);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "登录";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Local
            // 
            this.Local.AutoSize = true;
            this.Local.Checked = true;
            this.Local.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Local.Location = new System.Drawing.Point(207, 191);
            this.Local.Name = "Local";
            this.Local.Size = new System.Drawing.Size(69, 19);
            this.Local.TabIndex = 14;
            this.Local.Text = "Local";
            this.Local.UseVisualStyleBackColor = true;
            // 
            // DataBase
            // 
            this.DataBase.AutoSize = true;
            this.DataBase.Location = new System.Drawing.Point(207, 149);
            this.DataBase.Name = "DataBase";
            this.DataBase.Size = new System.Drawing.Size(93, 19);
            this.DataBase.TabIndex = 13;
            this.DataBase.Text = "DataBase";
            this.DataBase.UseVisualStyleBackColor = true;
            // 
            // LoginIn
            // 
            this.LoginIn.BackColor = System.Drawing.Color.Silver;
            this.LoginIn.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoginIn.Location = new System.Drawing.Point(26, 166);
            this.LoginIn.Name = "LoginIn";
            this.LoginIn.Size = new System.Drawing.Size(107, 39);
            this.LoginIn.TabIndex = 12;
            this.LoginIn.Text = "登录";
            this.LoginIn.UseVisualStyleBackColor = false;
            this.LoginIn.Click += new System.EventHandler(this.LoginIn_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(100, 102);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(228, 25);
            this.txtPassword.TabIndex = 11;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(100, 48);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(228, 25);
            this.txtUserName.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(22, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(22, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "用户名";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRegister);
            this.tabPage2.Controls.Add(this.btnSendV);
            this.tabPage2.Controls.Add(this.textBoxPassword);
            this.tabPage2.Controls.Add(this.textBoxVerification);
            this.tabPage2.Controls.Add(this.textBoxMail);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(374, 243);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "注册";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(134, 174);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(101, 36);
            this.btnRegister.TabIndex = 18;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnSendV
            // 
            this.btnSendV.Location = new System.Drawing.Point(244, 89);
            this.btnSendV.Name = "btnSendV";
            this.btnSendV.Size = new System.Drawing.Size(97, 23);
            this.btnSendV.TabIndex = 17;
            this.btnSendV.Text = "获取验证码";
            this.btnSendV.UseVisualStyleBackColor = true;
            this.btnSendV.Click += new System.EventHandler(this.btnSendV_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(105, 128);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(236, 25);
            this.textBoxPassword.TabIndex = 15;
            // 
            // textBoxVerification
            // 
            this.textBoxVerification.Location = new System.Drawing.Point(105, 87);
            this.textBoxVerification.Name = "textBoxVerification";
            this.textBoxVerification.Size = new System.Drawing.Size(106, 25);
            this.textBoxVerification.TabIndex = 14;
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(105, 43);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(236, 25);
            this.textBoxMail.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "密码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(24, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "验证码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(24, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "邮箱";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 293);
            this.Controls.Add(this.tabLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.tabLogin.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabLogin;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox Local;
        private System.Windows.Forms.CheckBox DataBase;
        private System.Windows.Forms.Button LoginIn;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnSendV;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxVerification;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}