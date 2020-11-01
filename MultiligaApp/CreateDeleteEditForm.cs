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
            string _operation = "usunięto zawody!";
            successfulOperation = true;
            switch(groupBox1.Text)
            {
                case "Utwórz nowe zawody":
                    {
                        _operation = " utworzono zawody!";
                        createCompetition();
                        break;
                    }
                case "Edytuj zawody":
                    _operation = " edytowano zawody!";
                    break;
                case "Załóż konto":
                    {                     
                        _operation = " założone konto!";
                        createAccount();
                        break;
                    }
                case "Załóż drużynę zawody":
                    _operation = " założona drużyna!";
                    break;
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

        private void createAccount()
        {
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
                successfulOperation = false;
            }
        }

        private void createCompetition()
        {
            using (var db = new multiligaEntities())
            {
                if(competitionScheduleCheck(int.Parse(textBox2.Text), textBox6.Text))
                {
                    var currEmail = LoginForm.getCurrentEmail();
                    var competition = db.Set<zawody>();
                    var currentUser = db.uzytkownik.FirstOrDefault(uz => uz.login == currEmail);
                    var currentEmployee = db.pracownik.FirstOrDefault(pr => pr.id_uzytkownik == currentUser.id_uzytkownik);

                    var newCompetition = new zawody {id_organizator = currentEmployee.id_pracownik, id_dyscyplina = int.Parse(comboBox1.SelectedValue.ToString()), nazwa = textBox5.Text.ToString(), id_opiekun_zawodow = int.Parse(comboBox4.SelectedValue.ToString()) };
                    competition.Add(newCompetition);
                    db.SaveChanges();

                    var dates = new List<DateTime>();
                    dates = getCompetitionDates(textBox6.Text);

                    var race = db.Set<wyscig>();                    
                    for(int i = 0; i < dates.Count; ++i)
                    {                        
                        var newRace = new wyscig { miasto = TextBox3.Text, id_zawody = newCompetition.id_zawody, data = dates[i], id_trasa = 1 };
                        race.Add(newRace);                    
                        db.SaveChanges();

                        if (checkQualifiersPossibility(int.Parse(textBox2.Text), comboBox7.Text) && i == 0)
                        {
                            newCompetition.id_kwalifikacje = newRace.id_wyscig;
                            db.SaveChanges();
                        }
                    }
                    newCompetition.data_poczatek = dates[0];
                    newCompetition.data_koniec = dates[dates.Count - 1];
                    db.SaveChanges();
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
    }
}
