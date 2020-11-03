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
        bool successfulOperation;
        public CreateDeleteEditForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string _operation = "";
            successfulOperation = true;
            switch(groupBox1.Text)
            {
                case "Usuń zawody":
                    {
                        _operation = "usunięto zawody!";
                        deleteCompetition();
                        break;
                    }
                case "Utwórz nowe zawody":
                    {
                        _operation = " utworzono zawody!";
                        createCompetition();
                        break;
                    }
                case "Edytuj zawody":
                    {
                        _operation = " edytowano zawody!";
                        updateCompetition();
                        break;
                    }
                case "Załóż konto":
                    {                     
                        _operation = " założone konto!";
                        createAccount();
                        break;
                    }
                case "Załóż drużynę":
                    {
                        _operation = " założona drużyna!";
                        createTeam();
                        break;
                    }
                default:
                    break;
            }

            if (successfulOperation == true)
            {
                MessageBox.Show("Poprawnie " + _operation, "Sukces");
                Close();
            }
            else
            {
                successfulOperation = true;
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

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CreateDeleteEditForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'multiligaDataSet1.pracownik' table. You can move, or remove it, as needed.
            this.pracownikTableAdapter.Fill(this.multiligaDataSet1.pracownik);
            // TODO: This line of code loads data into the 'multiligaDataSet.dyscyplina' table. You can move, or remove it, as needed.
            this.dyscyplinaTableAdapter.Fill(this.multiligaDataSet.dyscyplina);

        }

        private void FillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.pracownikTableAdapter.FillBy(this.multiligaDataSet1.pracownik);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void FillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.pracownikTableAdapter.FillBy1(this.multiligaDataSet1.pracownik);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void createAccount()
        {
            if (IsValidEmail(textBox5.Text.ToString()))
            {
                //TODO sprawdzic czy juz nie ma konta dla podanego maila
                using (var db = new multiligaEntities())
                {
                    var user = new uzytkownik { login = textBox5.Text.ToString(), haslo = textBox6.Text.ToString(), rola = "zawodnik" }; //konto z poziomu gui mogą zakładać tylko zawodnicy
                    db.uzytkownik.Add(user);
                    db.SaveChanges();
                    db.zawodnik.Add(new zawodnik { id_uzytkownik = user.id_uzytkownik, publiczne = 0, imie_nazwisko = textBox3.Text.ToString() });
                    db.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Zły format adresu email", "Niepowodzenie");
                successfulOperation = false;
            }
        }

        private void createCompetition()
        {
            using (var db = new multiligaEntities())
            {
                if (!raceNameTaken(textBox5.Text.ToString()))   //jeśli nazwa nie jest zajęta
                {
                    if (competitionScheduleCheck(Convert.ToInt32(numberOfRaces), textBox6.Text))
                    {
                        var currentEmployee = SqlHelper.getLoggedEmployee();
                        
                        var competition = new zawody { id_organizator = currentEmployee.id_pracownik, id_dyscyplina = int.Parse(comboBox1.SelectedValue.ToString()),
                            nazwa = textBox5.Text.ToString(), id_opiekun_zawodow = int.Parse(comboBox4.SelectedValue.ToString()) };
                        db.zawody.Add(competition);
                        db.SaveChanges();

                        var dates = new List<DateTime>();
                        dates = getCompetitionDates(textBox6.Text);
                       
                        for (int i = 0; i < dates.Count; ++i)
                        {
                            var race = new wyscig { miasto = textBox3.Text, id_zawody = competition.id_zawody, data = dates[i], id_trasa = 1 };
                            db.wyscig.Add(race);
                            db.SaveChanges();

                            if (checkQualifiersPossibility(Convert.ToInt32(numberOfRaces), comboBox7.Text) && i == 0)
                            {
                                competition.id_kwalifikacje = race.id_wyscig;
                                db.SaveChanges();
                            }
                        }
                        competition.data_poczatek = dates[0];
                        competition.data_koniec = dates[dates.Count - 1];
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Błąd przy wprowadzaniu harmonogramu wyścigu", "Niepowodzenie");
                        successfulOperation = false;
                    }
                }
                else
                {
                    MessageBox.Show("Podana nazwa wyścigu jest już zajęta", "Niepowodzenie");
                    successfulOperation = false;
                }
            }
        }

        private void deleteCompetition()
        {
            if(raceNameTaken(textBox5.Text.ToString()))
            {
                using (var db = new multiligaEntities())
                {                    
                    var competition = db.zawody.FirstOrDefault(z => z.nazwa == textBox5.Text.ToString());
                    if (SqlHelper.getLoggedEmployee().id_pracownik == competition.id_organizator)   //sprawdzenie uprawnien
                    {
                        db.zawody.Remove(competition);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Nie masz uprawnień do usunięcia tych zawodów", "Niepowodzenie");
                        successfulOperation = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Nie znaleziono zawodów o podanej nazwie", "Niepowodzenie");
                successfulOperation = false;
            }
        }

        private void updateCompetition()
        {
            if (raceNameTaken(textBox5.Text.ToString()))
            {
                using (var db = new multiligaEntities())
                {
                    var competition = db.zawody.FirstOrDefault(z => z.nazwa == textBox5.Text.ToString());

                    if (SqlHelper.getLoggedEmployee().id_pracownik == competition.id_organizator)   //sprawdzam uprawnienia
                    {
                        competition.id_dyscyplina = int.Parse(comboBox1.SelectedValue.ToString());
                        competition.id_opiekun_zawodow = int.Parse(comboBox4.SelectedValue.ToString());

                        if (textBox3.Text.Length > 0)   //sprawdzam czy wpisano jakies miasto
                        {
                            var races = db.wyscig.Where(w => w.id_zawody == competition.id_zawody);
                            foreach (var race in races)
                            {
                                race.miasto = textBox3.Text.ToString();
                            }
                            db.SaveChanges();
                        }

                        if (competitionScheduleCheck(Convert.ToInt32(numberOfRaces.Value), textBox6.Text))  //sprawdzam czy liczba wyscigow pokrywa sie z iloscia dat
                        {
                            var dates = new List<DateTime>();
                            dates = getCompetitionDates(textBox6.Text);

                            var races = db.wyscig.Where(w => w.id_zawody == competition.id_zawody);
                            int raceIndex = 0;
                            foreach (var race in races)
                            {
                                if (dates.Count <= raceIndex)
                                {
                                    db.wyscig.Remove(race);
                                }
                                else
                                {
                                    race.data = dates[raceIndex];
                                }
                                ++raceIndex;
                            }
                            if (dates.Count > races.Count())   //jesli po edycji jest więcej wyścigów niż poprzednio
                            {
                                var cityName = "";
                                if (textBox3.Text.Length == 0)  //sprawdzam czy przy edycji zostało podane nowe miasto
                                {
                                    cityName = races.FirstOrDefault<wyscig>().miasto;
                                }
                                else
                                {
                                    cityName = textBox3.Text;
                                }

                                for (int i = races.Count(); i < dates.Count; ++i)
                                {
                                    var race = new wyscig { miasto = cityName, id_zawody = competition.id_zawody, data = dates[i], id_trasa = 1 };
                                    db.wyscig.Add(race);
                                }
                            }

                            competition.data_poczatek = dates[0];
                            competition.data_koniec = dates[dates.Count - 1];
                            db.SaveChanges();

                        }

                    }
                    else
                    {
                        MessageBox.Show("Nie masz uprawnień do usunięcia tych zawodów", "Niepowodzenie");
                        successfulOperation = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Nie znaleziono zawodów o podanej nazwie", "Niepowodzenie");
                successfulOperation = false;
            }
        }

        private void createTeam()
        {
            if (textBox3.Text.Length > 0)
            {
                using (var db = new multiligaEntities())
                {
                    var team = new druzyna { nazwa = textBox3.Text, id_kapitan = SqlHelper.getLoggedContestant().id_zawodnik};
                    db.druzyna.Add(team);
                    var userTeam = new zawodnik_druzyna { id_druzyna = team.id_druzyna, id_zawodnik = SqlHelper.getLoggedContestant().id_zawodnik };
                    db.zawodnik_druzyna.Add(userTeam);
                    db.SaveChanges();

                }
            }
        }

        private bool competitionScheduleCheck(int numberOfRaces, string competitionSchedule)
        {
            int previousSemicolon = 0;
            int numberOfDates = 0;
            bool correctDates = true;
            DateTime dateValue;
            for(int i = 0; i < competitionSchedule.Length; ++i)
            {

                if(competitionSchedule[i] == ';' || i == competitionSchedule.Length - 1)
                {             
                    if(previousSemicolon != 0)   //żeby omijać średnik w przypadku wszystkich dat poza pierwszą
                    {
                        ++previousSemicolon;
                    }
                    if(i == competitionSchedule.Length - 1)     //zeby nie ucięło ostatniej cyfry w ostatniej dacie
                    {
                        ++i;
                    }                    

                    if (!DateTime.TryParse(competitionSchedule.Substring(previousSemicolon, i - previousSemicolon), out dateValue))
                    {
                        correctDates = false;
                        break;
                    }
                    else
                    {
                        ++numberOfDates;
                    }
                    previousSemicolon = i;
                }
            }
            return  ((numberOfDates == numberOfRaces) && correctDates);
        }

        private List<DateTime> getCompetitionDates(string competitionSchedule)
        {
            var dates = new List<DateTime>();
            int previousSemicolon = 0;
            for (int i = 0; i < competitionSchedule.Length; ++i)
            {

                if (competitionSchedule[i] == ';' || i == competitionSchedule.Length - 1)
                {
                    if (previousSemicolon != 0)   //żeby omijać średnik w przypadku wszystkich dat poza pierwszą
                    {
                        ++previousSemicolon;
                    }
                    if (i == competitionSchedule.Length - 1)     //zeby nie ucięło ostatniej cyfry w ostatniej dacie
                    {
                        ++i;
                    }
                    dates.Add(DateTime.Parse(competitionSchedule.Substring(previousSemicolon, i - previousSemicolon)));                    
                    previousSemicolon = i;
                }
            }
            return dates;
        }

        private bool checkQualifiersPossibility(int numberOfRaces, string info)
        {
            return (numberOfRaces > 1 && info == "kwalifikacje");
        }

        private bool raceNameTaken(string name)
        {
            using (var db = new multiligaEntities())
            {                
                return (db.zawody.Any(z => z.nazwa == name));
            }                    
        }
    }
}
