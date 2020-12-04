using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiligaApp
{    public partial class LoginForm : TemplateForm
    {
        public LoginForm(TemplateForm form) : base(form)
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoggedUserUtility.logIn(this, Login.Text, Password.Text);
        }
        private void ForgetPassword_Click(object sender, EventArgs e)
        {
            AccountForm accountEditionForm = new AccountForm(this);
            accountEditionForm.setSaveButtonText("Wyślij");
            accountEditionForm.SetMenu("Przypomnienie hasła", "", "Adres email", "");
            accountEditionForm.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            CreateDeleteEditForm createDeleteEditForm = new CreateDeleteEditForm(this);
            createDeleteEditForm.SetCreateForm("Załóż konto", "", "", "Imię i nazwisko", "", "Email", "\nHasło", "");
            createDeleteEditForm.Show();
        }
        private void NoLoginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mf = new MainForm(this);
            var user = LoggedUserUtility.userType.lurker;
            LoggedUserUtility.setCurrentUserType(user);
            LoggedUserUtility.setCurrentEmail("");
            mf.SetMenu(user);
            mf.Show();
        }
        public void setIncorrectLoginLabel(bool value)
        {
            IncorrectLoginLabel.Visible = value;
        }
    }
}