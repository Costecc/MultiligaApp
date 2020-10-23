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
    public partial class CreateDeleteEditForm : Form
    {
        public CreateDeleteEditForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string _operation = "usunięto zawody!";
            bool succesfulOperation = true;
            switch (groupBox1.Text)
            {
                case "Utwórz nowe zawody":
                    _operation = " utworzono zawody!";
                    break;
                case "Edytuj zawody":
                    _operation = " edytowano zawody!";
                    break;
                case "Załóż konto":
                    {
                        _operation = " założone konto!";
                        if (IsValidEmail(textBox5.Text.ToString()))
                        {
                            //TODO sprawdzic czy juz nie ma konta dla podanego maila
                            using (var db = new multiligaEntities())
                            {
                                var user = db.Set<uzytkownik>();
                                var contestant = db.Set<zawodnik>();
                                var newUser = new uzytkownik { login = textBox5.Text.ToString(), haslo = textBox6.Text.ToString(), rola = "zawodnik" }; //konto z poziomu gui mogą zakładać tylko zawodnicy
                                user.Add(newUser);
                                db.SaveChanges();
                                contestant.Add(new zawodnik { id_uzytkownik = newUser.id_uzytkownik, publiczne = 0, imie_nazwisko = textBox2.Text.ToString() });
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Zły format adresu email", "Niepowodzenie");
                            succesfulOperation = false;
                        }
                        break;
                    }
                case "Załóż drużynę zawody":
                    _operation = " założona drużyna!";
                    break;
                default:
                    break;
            }

            if (succesfulOperation == true)
            {
                MessageBox.Show("Poprawnie " + _operation, "Sukces");
                Close();
            }
            else
            {
                succesfulOperation = true;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void CreateDeleteEditForm_FormClosed(object sender, FormClosedEventArgs e)
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
