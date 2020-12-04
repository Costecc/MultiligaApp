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
    public partial class AccountForm : TemplateForm
    {
        public AccountForm(TemplateForm form) : base(form)
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.groupBox1.Text == "Przypomnienie hasła")
            {
                LoggedUserUtility.remindPassword(textBox2.Text);
            }
            else if (this.groupBox1.Text == "Zmiana hasła")
            {
                LoggedUserUtility.changePassword(this, textBox1.Text, textBox2.Text, textBox3.Text);
            }
            else if (this.groupBox1.Text == "Usuwanie konta")
            {
                LoggedUserUtility.deleteAccount(this, textBox2.Text);
            }
        }
        public void setSaveButtonText(string text)
        {
            SaveButton.Text = text;
        }
    }
}
