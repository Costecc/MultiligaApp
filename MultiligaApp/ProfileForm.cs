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
    public partial class ProfileForm : Form
    {
        private int profileId;
        public ProfileForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InviteButton_Click(object sender, EventArgs e)
        {
            if(InviteButton.Text == "Zaproś do drużyny")
            {
                if (!ContestantDataUtility.isContestantAlreadyInTeam(profileId, Convert.ToInt32(comboBox1.SelectedValue))) //jeśli zaproszenie nie było wysyłane już wcześniej
                {                    
                    TeamDataUtility.createTeamInvitation(profileId, Convert.ToInt32(comboBox1.SelectedValue));
                    MessageBox.Show("Zaproszono do drużyny", "Zaproszenie wysłane");
                }
                else
                    MessageBox.Show("Zaproszenie zostało już wysłane wcześniej", "Informacja");
            }
            else
            {
                if (!TeamDataUtility.isTeamAlreadyInCompetition(profileId, Convert.ToInt32(comboBox1.SelectedValue)))
                {
                    CompetitionDataUtility.createCompetitionTeamInvitation(profileId, Convert.ToInt32(comboBox1.SelectedValue));
                    MessageBox.Show("Zaproszono do zawodów", "Zaproszenie wysłane");
                }                    
                else
                    MessageBox.Show("Zaproszenie zostało już wysłane wcześniej", "Informacja");
            }
        }

        private void ProfileForm_FormClosed(object sender, FormClosedEventArgs e)
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
        public void setProfileId(int id)
        {
            profileId = id;
        }
    }
}
