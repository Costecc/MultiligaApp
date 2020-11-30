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
        bool successfulOperation;
        private int modifiedRaceId;
        public int ModifiedRaceId
        {
            get { return modifiedRaceId; }
            set { modifiedRaceId = value; }
        }
        public CreateDeleteEditForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string _operation = "";
            successfulOperation = true;
            switch(groupBox1.Text)
            {
                case "Usuń zawody":
                    {
                        _operation = "usunięto zawody!";
                        CompetitionDataUtility.deleteCompetition(textBox5.Text, ref successfulOperation);
                        break;
                    }
                case "Utwórz nowe zawody":
                    {
                        _operation = " utworzono zawody!";
                        CompetitionDataUtility.createCompetition(int.Parse(comboBox1.SelectedValue.ToString()), Convert.ToInt32(numberOfRaces.Value), 
                            textBox3.Text, int.Parse(comboBox4.SelectedValue.ToString()), textBox5.Text, textBox6.Text, comboBox7.Text, ref successfulOperation);
                        break;
                    }
                case "Edytuj zawody":
                    {
                        _operation = " edytowano zawody!";
                        CompetitionDataUtility.updateCompetition(int.Parse(comboBox1.SelectedValue.ToString()), Convert.ToInt32(numberOfRaces.Value),
                            textBox3.Text, int.Parse(comboBox4.SelectedValue.ToString()), textBox5.Text, textBox6.Text, comboBox7.Text, ref successfulOperation);
                        break;
                    }
                case "Załóż konto":
                    {                     
                        _operation = " założone konto!";
                        LoggedUserUtility.createAccount(textBox5.Text, textBox6.Text, textBox3.Text, ref successfulOperation);
                        break;
                    }
                case "Załóż drużynę":
                    {
                        _operation = " założona drużyna!";
                        TeamDataUtility.createTeam(textBox3.Text);
                        break;
                    }
                case "Podaj trasę wyścigów":
                    {
                        _operation = " dodana trasa!";
                        CompetitionDataUtility.addRaceTrack(Convert.ToInt32(comboBox4.SelectedValue), ModifiedRaceId, ref successfulOperation);                 
                        break;
                    }
                default:
                    break;
            }

            if (successfulOperation == true)
            {
                MessageBox.Show("Poprawnie " + _operation, "Sukces");
                Close();
            }
            else
            {
                successfulOperation = true;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void CreateDeleteEditForm_FormClosed(object sender, FormClosedEventArgs e)
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

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CreateDeleteEditForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'multiligaDataSet1.pracownik' table. You can move, or remove it, as needed.
            this.pracownikTableAdapter.Fill(this.multiligaDataSet1.pracownik);
            // TODO: This line of code loads data into the 'multiligaDataSet.dyscyplina' table. You can move, or remove it, as needed.
            this.dyscyplinaTableAdapter.Fill(this.multiligaDataSet.dyscyplina);

        }

        private void FillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.pracownikTableAdapter.FillBy(this.multiligaDataSet1.pracownik);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void FillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.pracownikTableAdapter.FillBy1(this.multiligaDataSet1.pracownik);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        } 
        
        public void dropDownTracks()
        {
            var tracks = CompetitionDataUtility.getAvailableTracks(ModifiedRaceId);
            comboBox4.DataSource = tracks;
            comboBox4.ValueMember = "id_trasa";
            comboBox4.DisplayMember = "nazwa";
            
        }
    }
}
