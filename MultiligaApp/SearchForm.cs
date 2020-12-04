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
    public partial class SearchForm : TemplateForm
    {
        public SearchForm(TemplateForm form) : base(form)
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            //TODO - WYSZUKAĆ W BAZIE CZY ZNALEZIONO przynajmniej jedną DRUŻYNĘ
            //jeśli nie to komunikat że nie znaleziono
            if (SearchMenu.Text == "Wyszukiwanie gracza")
            {
                var contestants = ContestantDataUtility.selectContestants(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                ResultView.DataSource = contestants.Select(x => new { ID = x.FirstOrDefault().id_zawodnik, Name = x.FirstOrDefault().imie_nazwisko }).ToList();
                ResultView.Columns["ID"].Visible = false;
                ResultView.ClearSelection();
                ResultView.CurrentCell = null;
            }
            if (SearchMenu.Text == "Wyszukiwanie drużyny")
            {
                var teams = TeamDataUtility.selectTeams(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                ResultView.DataSource = teams.Select(x => new { ID = x.FirstOrDefault().id_druzyna, Name = x.FirstOrDefault().nazwa }).ToList();
                ResultView.Columns["ID"].Visible = false;
                ResultView.ClearSelection();
                ResultView.CurrentCell = null;
            }
        }       
    }
}
