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
            IncorrectLoginLabel.Visible = false;
            if(Login.Text == "test" && Password.Text == "test")
            {
                this.Hide();
                MainForm mf = new MainForm();
                //TODO - sprawdzić w bazie co to za typ użytkownika, czy np. kapitan/opiekun zawodów etc.
                //na tej podstawie włączyć na enable odpowiednie funkcje w menu
                //na razie dałem na podstawie zmiennej user
                // 0 - mozliwosc wyszukiwania
                // 1 - organizator
                // 2 - kapitan
                // 3 - opiekun
                // 4 - zawodnik
                // default - mozliwosc logowania

                int user = 3;
                // jesli do set menu podany user > 4 to nie ma mozliwosci wyszukiwania
                mf.SetMenu(user);               
                mf.Show();
                
            }
            else
            {
                IncorrectLoginLabel.Visible = true;
            }
        }

        private void ForgetPassword_Click(object sender, EventArgs e)
        {
            AccountForm accountEditionForm = new AccountForm();
            accountEditionForm.SetMenu("Przypomnienie hasła", "", "Adres email", "");
            accountEditionForm.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}