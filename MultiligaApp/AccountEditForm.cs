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
    public partial class AccountEditForm : TemplateForm
    {
        public AccountEditForm(TemplateForm form) : base(form)
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AccountForm accountEditionForm = new AccountForm(this);
            accountEditionForm.SetMenu("Zmiana hasła", "Aktualne hasło", "Nowe hasło", "Potwierdź nowe hasło");
            accountEditionForm.Show();
        }

        private void ImageChange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AccountForm accountEditionForm = new AccountForm(this);
            accountEditionForm.SetMenu("Zmiana hasła", "", "Podaj link do zdjęcia na swoim dysku", "");
            accountEditionForm.Show();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            LoggedUserUtility.editAccount(this, EmailText.Text, HeightText.Text, WeightText.Text, AboutMe.Text, PermissionsCheckBox.Checked);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
