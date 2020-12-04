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
    public partial class AccountForm : Form
    {
        public AccountForm()
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
            else if(this.groupBox1.Text == "Zmiana hasła")
            { 
                LoggedUserUtility.changePassword(this, textBox1.Text, textBox2.Text, textBox3.Text);
            }
            else if (this.groupBox1.Text == "Usuwanie konta")
            {
                LoggedUserUtility.deleteAccount(this, textBox2.Text);
            }
        }

        private void AccountForm_FormClosed(object sender, FormClosedEventArgs e)
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

        public void setSaveButtonText(string text)
        {
            SaveButton.Text = text;
        }
    }
}
