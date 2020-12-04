using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Net.Mail;
using System.Net;

namespace MultiligaApp
{

    class LoggedUserUtility : Utility
    {
        static private string currentEmail;
        static private userType currentType;
        public enum userType
        {
            lurker, organiser, captain, supervisor, contestant
        }
        static public string getCurrentEmail()
        {
            return currentEmail;
        }
        static public void setCurrentEmail(string email)
        {
            currentEmail = email;
        }

        static public uzytkownik getLoggedUser()
        {
            var currEmail = getCurrentEmail();
            var currentUser = db.uzytkownik.FirstOrDefault(uz => uz.login == currEmail);

            return currentUser;
        }
        static public void setCurrentUserType(userType type)
        {
            currentType = type;
        }

        static public userType getCurrentUserType()
        {
            return currentType;
        }


        static public zawodnik getLoggedContestant()
        {
            var currentUser = getLoggedUser();
            var currentContestant = db.zawodnik.FirstOrDefault(zaw => zaw.id_uzytkownik == currentUser.id_uzytkownik);

            return currentContestant;

        }
        static public pracownik getLoggedEmployee()
        {

            var currentUser = getLoggedUser();
            var currentEmployee = db.pracownik.FirstOrDefault(pr => pr.id_uzytkownik == currentUser.id_uzytkownik);
            return currentEmployee;

        }

        static public void logIn(LoginForm form, string login, string password)
        {
            //form.IncorrectLoginLabel.Visible = false;
            form.setIncorrectLoginLabel(false);

            if (db.uzytkownik.Any(u => u.login == login.ToString() && u.haslo == password.ToString()))         //sprawdzam czy podany login i podane hasło są w bazie danych
            {
                form.Hide();
                MainForm mf = new MainForm(form);
                // 0 - mozliwosc wyszukiwania
                // 1 - organizator
                // 2 - kapitan
                // 3 - opiekun
                // 4 - zawodnik
                // default - mozliwosc logowania
                LoggedUserUtility.setCurrentEmail(login.ToString());


                var currentUser = LoggedUserUtility.getLoggedUser();

                var user = LoggedUserUtility.userType.lurker;
                if (currentUser.rola == "zawodnik")
                {
                    user = LoggedUserUtility.userType.contestant;
                    //TODO kapitan, sprawdzic czy w tabeli druzyna jest jako kapitan
                    if (ContestantDataUtility.checkIfCaptain(LoggedUserUtility.getLoggedContestant().id_zawodnik))
                    {
                        user = LoggedUserUtility.userType.captain;
                    }
                }
                else
                {
                    var currentEmployee = LoggedUserUtility.getLoggedEmployee();

                    if (currentEmployee.stanowisko == "organizator")
                    {
                        user = LoggedUserUtility.userType.organiser;
                    }
                    else if (currentEmployee.stanowisko == "opiekun")
                    {
                        user = LoggedUserUtility.userType.supervisor;
                    }
                }
                // jesli do set menu podany user > 4 to nie ma mozliwosci wyszukiwania
                LoggedUserUtility.setCurrentUserType(user);
                mf.SetMenu(user);
                mf.Show();
            }
            else
            {
                form.setIncorrectLoginLabel(true);
            }
        }

        static public void changePassword(AccountForm form, string oldPassword, string newPassword, string newPasswordConfirm)
        {
            string currEmail = getCurrentEmail();

            var user = db.uzytkownik.FirstOrDefault(uz => uz.login == currEmail && uz.haslo == oldPassword);
            if (user != null)
            {
                if (newPassword == newPasswordConfirm)
                {
                    user.haslo = newPassword;
                    db.SaveChanges();
                    MessageBox.Show("Poprawnie zmieniono hasło", "Sukces");
                    form.Close();
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

        static public void deleteAccount(AccountForm form, string password)
        {
            string currEmail = LoggedUserUtility.getCurrentEmail();
            try
            {
                var user = db.uzytkownik.FirstOrDefault(uz => uz.login == currEmail && uz.haslo == password);
                var contestant = db.zawodnik.FirstOrDefault(uz => uz.id_uzytkownik == user.id_uzytkownik);
                db.uzytkownik.Remove(user);
                db.zawodnik.Remove(contestant);
                db.SaveChanges();

                form.Close();
                LoginForm lf = new LoginForm(null);
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
        static public void createAccount(string email, string password, string name, ref bool successfulOperation)
        {
            if (IsValidEmail(email))
            {
                if (!IsEmailTaken(email))
                {
                    var user = new uzytkownik { login = email, haslo = password, rola = "zawodnik" }; //konto z poziomu gui mogą zakładać tylko zawodnicy
                    db.uzytkownik.Add(user);
                    db.SaveChanges();
                    db.zawodnik.Add(new zawodnik { id_uzytkownik = user.id_uzytkownik, publiczne = 0, imie_nazwisko = name });
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Podany email jest już zajęty", "Niepowodzenie");
                    successfulOperation = false;
                }
            }
            else
            {
                MessageBox.Show("Zły format adresu email", "Niepowodzenie");
                successfulOperation = false;
            }
        }
        static public void editAccount(AccountEditForm form, string email, string height, string weight, string aboutMe, bool permissionsChecked)
        {
            string _operation = "";

            var currEmail = LoggedUserUtility.getCurrentEmail();
            var user = db.uzytkownik.FirstOrDefault(uz => uz.login == currEmail);
            var contestant = db.zawodnik.FirstOrDefault(zaw => zaw.id_uzytkownik == user.id_uzytkownik);

            if (IsValidEmail(email))
            {
                user.login = email;
                LoggedUserUtility.setCurrentEmail(email);
                _operation += "\n- email";
            }
            else if (email.Length > 0)
            {
                MessageBox.Show("Zły format adresu email", "Niepowodzenie");
            }

            if (isNumber(height))
            {
                contestant.wzrost = int.Parse(height);
                _operation += "\n- wzrost";
            }
            else if (height.Length > 0)
            {
                MessageBox.Show("Błąd w podanym wzroście", "Niepowodzenie");
            }

            if (isNumber(weight))
            {
                contestant.waga = int.Parse(weight);
                _operation += "\n- waga";
            }
            else if (weight.Length > 0)
            {
                MessageBox.Show("Błąd w podanej wadze", "Niepowodzenie");
            }

            if (aboutMe.Length > 0)
            {
                contestant.o_sobie = aboutMe;
                _operation += "\n- osiagniecia";
            }

            var previousPermissions = contestant.publiczne;
            contestant.publiczne = Convert.ToInt16(permissionsChecked);
            if (previousPermissions != Convert.ToInt16(permissionsChecked))
            {
                _operation += "\n- ustawienia prywatności";
            }
            db.SaveChanges();


            if (_operation.Length == 0)
            {
                MessageBox.Show("Nie edytowano żadnych danych", "Brak zmian");
            }
            else
            {
                MessageBox.Show("Z powodzeniem edytowano: " + _operation, "Powodzenie");
            }
            form.Close();
        }

        static public bool IsValidEmail(string email)
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

        static public bool IsEmailTaken(string email)
        {
            return db.uzytkownik.Any(u => u.login == email);
        }

        static public bool isNumber(string numString)
        {
            int number = 0;
            return (numString.Length > 0 && int.TryParse(numString, out number));
        }

        static public void remindPassword(string email)
        {
            try
            {
                if (db.uzytkownik.Any(u => u.login == email))         //sprawdzam czy podany login i podane hasło są w bazie danych
                {
                    var query = from uz in db.uzytkownik
                                where uz.login == email
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
                    var toAddress = new MailAddress(email, recipientName);
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
                MessageBox.Show("Email został wysłany na wskazany adres", "Powodzenie");
            }
            catch
            {
                MessageBox.Show("Zły format adresu email", "Niepowodzenie");
            }
        }

        static public List<zawody> getEmployeesCompetitions(int employeeId)
        {
            var usersCompetitions = db.zawody.Where(z => z.id_organizator == employeeId || z.id_opiekun_zawodow == employeeId).ToList();
            return usersCompetitions;
        }

    }
}
