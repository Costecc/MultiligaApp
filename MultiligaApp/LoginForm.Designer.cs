namespace MultiligaApp
{
    partial class LoginForm
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
            this.Login = new System.Windows.Forms.TextBox();
            this.LoginBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ForgetPassword = new System.Windows.Forms.Label();
            this.IncorrectLoginLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.LoginBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(91, 35);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(201, 22);
            this.Login.TabIndex = 0;
            // 
            // LoginBox
            // 
            this.LoginBox.Controls.Add(this.label1);
            this.LoginBox.Controls.Add(this.ForgetPassword);
            this.LoginBox.Controls.Add(this.IncorrectLoginLabel);
            this.LoginBox.Controls.Add(this.label3);
            this.LoginBox.Controls.Add(this.LoginButton);
            this.LoginBox.Controls.Add(this.Password);
            this.LoginBox.Controls.Add(this.PasswordLabel);
            this.LoginBox.Controls.Add(this.LoginLabel);
            this.LoginBox.Controls.Add(this.Login);
            this.LoginBox.Location = new System.Drawing.Point(22, 15);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(332, 200);
            this.LoginBox.TabIndex = 1;
            this.LoginBox.TabStop = false;
            this.LoginBox.Text = "Zaloguj";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(201, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Załóż konto";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ForgetPassword
            // 
            this.ForgetPassword.AutoSize = true;
            this.ForgetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForgetPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForgetPassword.ForeColor = System.Drawing.Color.Black;
            this.ForgetPassword.Location = new System.Drawing.Point(44, 144);
            this.ForgetPassword.Name = "ForgetPassword";
            this.ForgetPassword.Size = new System.Drawing.Size(132, 17);
            this.ForgetPassword.TabIndex = 7;
            this.ForgetPassword.Text = "Nie pamiętam hasła";
            this.ForgetPassword.Click += new System.EventHandler(this.ForgetPassword_Click);
            // 
            // IncorrectLoginLabel
            // 
            this.IncorrectLoginLabel.AutoSize = true;
            this.IncorrectLoginLabel.ForeColor = System.Drawing.Color.Red;
            this.IncorrectLoginLabel.Location = new System.Drawing.Point(38, 171);
            this.IncorrectLoginLabel.Name = "IncorrectLoginLabel";
            this.IncorrectLoginLabel.Size = new System.Drawing.Size(188, 17);
            this.IncorrectLoginLabel.TabIndex = 6;
            this.IncorrectLoginLabel.Text = "Niepoprawny login lub hasło!";
            this.IncorrectLoginLabel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(38, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 5;
            // 
            // LoginButton
            // 
            this.LoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginButton.Location = new System.Drawing.Point(41, 106);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(251, 35);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Zaloguj";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(90, 70);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(202, 22);
            this.Password.TabIndex = 3;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(38, 69);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(44, 17);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "Hasło";
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Location = new System.Drawing.Point(38, 39);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(42, 17);
            this.LoginLabel.TabIndex = 1;
            this.LoginLabel.Text = "Email";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 229);
            this.Controls.Add(this.LoginBox);
            this.Name = "LoginForm";
            this.Text = "Logowanie";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.LoginBox.ResumeLayout(false);
            this.LoginBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.GroupBox LoginBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label IncorrectLoginLabel;
        private System.Windows.Forms.Label ForgetPassword;
        private System.Windows.Forms.Label label1;
    }
}