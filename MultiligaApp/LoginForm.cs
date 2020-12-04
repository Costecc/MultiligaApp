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
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoggedUserUtility.logIn(this, Login.Text, Password.Text);
        }

        private void ForgetPassword_Click(object sender, EventArgs e)
        {
            AccountForm accountEditionForm = new AccountForm();
            accountEditionForm.setSaveButtonText("Wyślij");
            accountEditionForm.SetMenu("Przypomnienie hasła", "", "Adres email", "");
            accountEditionForm.Show();            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            CreateDeleteEditForm createDeleteEditForm = new CreateDeleteEditForm();
            createDeleteEditForm.SetCreateForm("Załóż konto", "", "", "Imię i nazwisko", "", "Email", "\nHasło", "");
            createDeleteEditForm.Show();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
            else
            {
                int visibleForms = 0;
                for (int i = 0; i < Application.OpenForms.Count; ++i)
                {
                    if (Application.OpenForms[i].Visible == true)
                    {
                        ++visibleForms;
                    }
                }
                if (visibleForms == 0)
                {
                    Application.Exit();
                }
            }
        }

        private void NoLoginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mf = new MainForm();
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