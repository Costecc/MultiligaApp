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
        //static private string currentEmail;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            IncorrectLoginLabel.Visible = false;
   
            using (var db = new multiligaEntities())
            {
                if (db.uzytkownik.Any(u => u.login == Login.Text.ToString() && u.haslo == Password.Text.ToString()))         //sprawdzam czy podany login i podane hasło są w bazie danych
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
                    SqlHelper.setCurrentEmail(Login.Text.ToString());                  

                    var currentUser = SqlHelper.getLoggedUser();

                    int user = 0;
                    if (currentUser.rola == "zawodnik")
                    {
                        user = 4;
                        //todo dla kapitana
                    }
                    else
                    {                       
                        var currentEmployee = SqlHelper.getLoggedEmployee();

                        if(currentEmployee.stanowisko == "organizator")
                        {
                            user = 1;
                        }
                        else if(currentEmployee.stanowisko == "opiekun zawodow")
                        {
                            user = 3;
                        }
                    }                    
                    // jesli do set menu podany user > 4 to nie ma mozliwosci wyszukiwania
                    mf.SetMenu(user);
                    mf.Show();                    
                }
                else
                {
                    IncorrectLoginLabel.Visible = true;
                }
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

        private void label1_Click(object sender, EventArgs e)
        {
            CreateDeleteEditForm createDeleteEditForm = new CreateDeleteEditForm();
            createDeleteEditForm.SetCreateForm("Załóż konto", "", "", "Imię i nazwisko", "", "Email", "\nHasło", "");
            createDeleteEditForm.Show();
        }

        //static public string getCurrentEmail()
        //{
        //    return currentEmail;
        //}

        //static public void setCurrentEmail(string email)
        //{
        //    currentEmail = email;
        //}

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
    }
}