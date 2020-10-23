using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

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
                            if (query.FirstOrDefault<uzytkownik>().rola == "zawodnik")
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

        }
    }
}
