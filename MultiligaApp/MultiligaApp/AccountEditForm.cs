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
    public partial class AccountEditForm : Form
    {
        public AccountEditForm()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AccountForm accountEditionForm = new AccountForm();
            accountEditionForm.SetMenu("Zmiana hasła", "Aktualne hasło", "Nowe hasło", "Potwierdź nowe hasło");
            accountEditionForm.Show();
        }

        private void ImageChange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zmiany zostały zapisane", "Edycja konta");
            this.Close();

        }
    }
}
