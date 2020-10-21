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
                            var z = db.Set<pracownik>();
                            z.Add(new pracownik { id_pracownik = 2, stanowisko = "test", login = "ee", haslo = "e" });
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
