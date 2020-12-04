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
    public partial class ProfileForm : TemplateForm
    {
        private int profileId;
        public ProfileForm(TemplateForm form) : base(form)
        {
            InitializeComponent();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void InviteButton_Click(object sender, EventArgs e)
        {
            if (InviteButton.Text == "Zaproś do drużyny")
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
        public void setProfileId(int id)
        {
            profileId = id;
        }
    }
}
