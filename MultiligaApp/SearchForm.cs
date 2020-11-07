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
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchingForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO - WYSZUKAĆ W BAZIE CZY ZNALEZIONO przynajmniej jedną DRUŻYNĘ
            //jeśli nie to komunikat że nie znaleziono
            if(SearchMenu.Text == "Wyszukiwanie gracza")
            {
                    var contestants = SqlHelper.selectContestants(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                    ResultView.DataSource = contestants.Select(x => new { ID = x.FirstOrDefault().id_zawodnik, Name = x.FirstOrDefault().imie_nazwisko }).ToList();
                    ResultView.Columns["ID"].Visible = false;
                    ResultView.ClearSelection();
                    ResultView.CurrentCell = null;
            }
            if(false)
            {
                MessageBox.Show("Nie znaleziono rekordu o danych parametrach!", "Brak wyników");
            }
        }

        private void SearchForm_FormClosed(object sender, FormClosedEventArgs e)
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
