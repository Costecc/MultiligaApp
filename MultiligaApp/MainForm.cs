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

        private void mojeDrużynyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompetitionsTeamsForm competitionsTeamsForm = new CompetitionsTeamsForm();
            competitionsTeamsForm.SetWindow("druzyny");
            competitionsTeamsForm.Show();            
        }

        private void utwórzNoweToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDeleteEditForm createForm = new CreateDeleteEditForm();
            createForm.SetCreateForm("Utwórz nowe zawody", "Dyscyplina", "Liczba wyścigów", "Miasto", "Opiekun", "Nazwa", "Harmonogram", "Rodzaj wyścigu");
            createForm.Show();
        }

        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDeleteEditForm createForm = new CreateDeleteEditForm();
            createForm.SetCreateForm("Usuń zawody", "", "", "", "", "Nazwa", "", "");
            createForm.Show();
        }

        private void edytujZawodyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDeleteEditForm createForm = new CreateDeleteEditForm();
            createForm.SetCreateForm("Edytuj zawody", "Dyscyplina", "Liczba wyścigów", "Miasto", "Opiekun", "Nazwa", "Harmonogram", "Rodzaj wyścigu");
            createForm.Show();
        }

        private void załóżNowaDrużynęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDeleteEditForm createForm = new CreateDeleteEditForm();
            createForm.SetCreateForm("Załóż drużynę zawody", "Nazwa", "", "", "", "", "", "");
            createForm.Show();
        }

        private void wprowadźTrasęWyściguToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CreateDeleteEditForm createForm = new CreateDeleteEditForm();
            //createForm.SetCreateForm("Wprowadź trasę wyścigu", "Nazwa", "", "", "", "", "", "");
            //createForm.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
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
