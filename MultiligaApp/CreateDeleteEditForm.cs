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
            switch(groupBox1.Text)
            {
                case "Utwórz nowe zawody":
                    _operation = " utworzono zawody!"; break;
                case "Edytuj zawody":
                    _operation = " edytowano zawody!"; break;
                case "Załóż konto":
                    {
                        _operation = " założone konto!";
                        using (var db = new multiligaEntities())
                        {
                            var user = db.Set<uzytkownik>();
                            var contestant = db.Set<zawodnik>();
                            user.Add(new uzytkownik { login = textBox5.Text.ToString(), haslo = textBox6.Text.ToString(), rola = "zawodnik" }); //konto z poziomu gui mogą zakładać tylko zawodnicy
                            contestant.Add(new zawodnik { imie_nazwisko = textBox2.Text.ToString() });
                            //TODO utworzyc tez rekord wplaty na tego zawodnika
                            db.SaveChanges();
                        }
                        break;
                    }                    
                case "Załóż drużynę zawody":
                    _operation = " założona drużyna!"; break;
                default:
                    break;
            }

            //TODO - do zrobienia - obsługa czy poprawnie czy błędnie, sprawdzając w bazie danych
            if (true)
            {
                MessageBox.Show("Poprawnie " + _operation, "Sukces");
            }
            else
            {
                MessageBox.Show("Nie " + _operation, "Niepowodzenie");
            }
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
