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
        static private string currentEmail;
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

                    var userQuery = from uz in db.uzytkownik
                                    where uz.login == Login.Text.ToString() && uz.haslo == Password.Text.ToString()
                                    select uz;
                    var role = userQuery.FirstOrDefault<uzytkownik>().rola;
                    var userId = userQuery.FirstOrDefault<uzytkownik>().id_uzytkownik;

                    int user = 0;
                    if (role == "zawodnik")
                    {
                        user = 4;
                        //todo dla kapitana
                    }
                    else
                    {
                        var employeeQuery = from pr in db.pracownik
                                            where pr.id_pracownik == userId
                                            select pr;
                        var employeeRole = employeeQuery.FirstOrDefault<pracownik>().stanowisko;

                        if (employeeRole == "organizator")
                        {
                            user = 1;
                        }
                        else if (employeeRole == "opiekun zawodow")
                        {
                            user = 3;
                        }
                    }
                    currentEmail = Login.Text.ToString();
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
            createDeleteEditForm.SetCreateForm("Załóż konto", "", "Imię i nazwisko", "", "", "Email", "Hasło", "");
            createDeleteEditForm.Show();
        }

        static public string getCurrentEmail()
        {
            return currentEmail;
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
    }
}