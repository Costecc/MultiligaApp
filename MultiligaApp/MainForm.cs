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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void LogoutLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Close();
        }

        private void zmieńHasłoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO - dodać komunikaty np. niezgodne hasła, hasło nie może być to samo jak było itd
            AccountForm accountEditionForm = new AccountForm();
            accountEditionForm.SetMenu("Zmiana hasła", "Aktualne hasło", "Nowe hasło", "Potwierdź nowe hasło");
            accountEditionForm.Show();
        }

        private void przypomnijHasłoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountForm accountEditionForm = new AccountForm();
            accountEditionForm.SetMenu("Przypomnienie hasła", "", "Adres email", "");
            accountEditionForm.Show();
        }

        private void edytujKontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountEditForm accountEditionForm = new AccountEditForm();
            accountEditionForm.Show();
        }

        private void usuńKontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountForm accountEditionForm = new AccountForm();
            accountEditionForm.SetMenu("Usuwanie konta", "", "Hasło", "");
            accountEditionForm.Show();
        }

        private void drużynaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.SetSearchingMenu(_user, "Wyszukiwanie drużyny", "Nazwa", "Liga", "Miasto", "Poziom ligi", "Dyscyplina");
            searchForm.Show();
        }

        private void graczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.SetSearchingMenu(_user, "Wyszukiwanie gracza", "Imię i nazwisko", "Liga", "Dyscyplina", "Drużyna", "");
            searchForm.Show();
        }
        
        private void mojeZawodyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompetitionsTeamsForm competitionsTeamsForm = new CompetitionsTeamsForm();
            competitionsTeamsForm.SetWindow("zawody");
            competitionsTeamsForm.Show();
        }

        private void zarzadzajZawodamiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mojeDrużynyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompetitionsTeamsForm competitionsTeamsForm = new CompetitionsTeamsForm();
            competitionsTeamsForm.SetWindow("druzyny");
            competitionsTeamsForm.Show();            
        }
    }
}
