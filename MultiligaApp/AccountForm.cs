using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace MultiligaApp
{
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.groupBox1.Text == "Przypomnienie hasła")
            {
                try
                {
                    using (var db = new multiligaEntities())
                    {
                        if (db.uzytkownik.Any(u => u.login == textBox2.Text.ToString()))         //sprawdzam czy podany login i podane hasło są w bazie danych
                        {
                            var query = from uz in db.uzytkownik
                                        where uz.login == textBox2.Text.ToString()
                                        select uz;

                            string recipientName;
                            if(query.FirstOrDefault<uzytkownik>().rola == "zawodnik")
                            {
                                var nameQuery = from z in db.zawodnik
                                                where z.id_uzytkownik == query.FirstOrDefault<uzytkownik>().id_uzytkownik
                                                select z;
                                recipientName = nameQuery.FirstOrDefault<zawodnik>().imie_nazwisko;

                            }
                            else
                            {
                                var nameQuery = from p in db.pracownik
                                                where p.id_uzytkownik == query.FirstOrDefault<uzytkownik>().id_uzytkownik
                                                select p;
                                recipientName = nameQuery.FirstOrDefault<pracownik>().imie + ' ' + nameQuery.FirstOrDefault<pracownik>().nazwisko;
                            }
                            var fromAddress = new MailAddress("multiligapp@gmail.com", "Multiliga App");
                            var toAddress = new MailAddress(textBox2.Text.ToString(), recipientName); 
                            const string fromPassword = "1a4g5D3s";
                            const string subject = "Przypomnienie hasła";
                            string body = "Twoje hasło to: " + query.FirstOrDefault<uzytkownik>().haslo;

                            var smtp = new SmtpClient
                            {
                                Host = "smtp.gmail.com",
                                Port = 587,
                                EnableSsl = true,
                                DeliveryMethod = SmtpDeliveryMethod.Network,
                                UseDefaultCredentials = false,
                                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                            };
                            using (var message = new MailMessage(fromAddress, toAddress)
                            {
                                Subject = subject,
                                Body = body
                            })
                            {
                                smtp.Send(message);
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Zły format adresu email", "Niepowodzenie");
                }
            }
            else if(this.groupBox1.Text == "Zmiana hasła")
            {
                string currEmail = SqlHelper.getCurrentEmail();                
                using (var db = new multiligaEntities())
                {
                    var user = db.uzytkownik.FirstOrDefault(uz => uz.login == currEmail && uz.haslo == textBox1.Text.ToString());
                    if (user != null)
                    {
                        if (textBox2.Text.ToString() == textBox3.Text.ToString())
                        {
                            user.haslo = textBox2.Text.ToString();
                            db.SaveChanges();
                            MessageBox.Show("Poprawnie zmieniono hasło", "Sukces");
                            Close();
                        }
                        else
                        {                            
                            MessageBox.Show("Błąd przy potwierdzaniu nowego hasła", "Niepowodzenie");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Podano niepoprawne hasło", "Niepowodzenie");
                    }
                }
            }
            else if (this.groupBox1.Text == "Usuwanie konta")
            {
                using (var db = new multiligaEntities())
                {
                    string currEmail = SqlHelper.getCurrentEmail();
                    try
                    {
                        var user = db.uzytkownik.FirstOrDefault(uz => uz.login == currEmail && uz.haslo == textBox2.Text.ToString());
                        var contestant = db.zawodnik.FirstOrDefault(uz => uz.id_uzytkownik == user.id_uzytkownik);
                        db.uzytkownik.Remove(user);
                        db.zawodnik.Remove(contestant);
                        db.SaveChanges();

                        this.Close();
                        LoginForm lf = new LoginForm();
                        lf.Show();

                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            if (Application.OpenForms[i].Text == "Multiliga")
                            {
                                Application.OpenForms[i].Close();
                                break;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Błędne hasło", "Niepowodzenie");
                    }
                }     
            }
        }

        private void AccountForm_FormClosed(object sender, FormClosedEventArgs e)
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
