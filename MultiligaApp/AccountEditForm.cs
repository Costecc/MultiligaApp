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
    public partial class AccountEditForm : Form
    {
        public AccountEditForm()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AccountForm accountEditionForm = new AccountForm();
            accountEditionForm.SetMenu("Zmiana hasła", "Aktualne hasło", "Nowe hasło", "Potwierdź nowe hasło");
            accountEditionForm.Show();
        }

        private void ImageChange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AccountForm accountEditionForm = new AccountForm();            
            accountEditionForm.SetMenu("Zmiana hasła", "", "Podaj link do zdjęcia na swoim dysku", "");           
            accountEditionForm.Show();           
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string _operation = "";
            using (var db = new multiligaEntities())
            {
                var currEmail = SqlHelper.getCurrentEmail();
                var user = db.uzytkownik.FirstOrDefault(uz => uz.login == currEmail);
                var contestant = db.zawodnik.FirstOrDefault(zaw => zaw.id_uzytkownik == user.id_uzytkownik);
                
                if (IsValidEmail(EmailText.Text.ToString()))
                {
                    user.login = EmailText.Text.ToString();
                    SqlHelper.setCurrentEmail(EmailText.Text.ToString());
                    _operation += "\n- email";
                }
                else if(EmailText.Text.Length > 0)
                {
                    MessageBox.Show("Zły format adresu email", "Niepowodzenie");
                }

                if (isNumber(HeightText.Text.ToString()))
                {
                    contestant.wzrost = int.Parse(HeightText.Text.ToString());
                    _operation += "\n- wzrost";
                }
                else if(HeightText.Text.Length > 0)
                {
                    MessageBox.Show("Błąd w podanym wzroście", "Niepowodzenie");
                }

                if (isNumber(WeightText.Text.ToString()))
                {
                    contestant.waga = int.Parse(WeightText.Text.ToString());
                    _operation += "\n- waga";
                }
                else if(WeightText.Text.Length > 0)
                {
                    MessageBox.Show("Błąd w podanej wadze", "Niepowodzenie");
                }

                if (AboutMe.Text.ToString().Length > 0)
                {
                    contestant.o_sobie = AboutMe.Text.ToString();
                    _operation += "\n- osiagniecia";
                }

                var praviousPermissions = contestant.publiczne;
                contestant.publiczne = Convert.ToInt16(PermissionsCheckBox.Checked);
                if(praviousPermissions != Convert.ToInt16(PermissionsCheckBox.Checked))
                {
                    _operation += "\n- ustawienia prywatności";
                }
                db.SaveChanges();
            }

            if (_operation.Length == 0)
            {
                MessageBox.Show("Nie edytowano żadnych danych", "Brak zmian");
            }
            else
            {
                MessageBox.Show("Z powodzeniem edytowano: " + _operation, "Powodzenie");
            }
            this.Close();

        }

        private void AccountEditForm_FormClosed(object sender, FormClosedEventArgs e)
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

        bool isNumber(string numString)
        {
            int number = 0;
            return (numString.Length > 0 && int.TryParse(numString, out number));
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
