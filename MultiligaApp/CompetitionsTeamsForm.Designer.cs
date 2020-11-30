using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System;
namespace MultiligaApp
{
    partial class CompetitionsTeamsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        internal void SetWindow(string kind, int competitionId = 0)
        {
            var type = LoggedUserUtility.getCurrentUserType();
            
            if(kind == "zawody")
            {
                CompetitionBox.Text = "Lista zawodów";
                ConfirmButton.Visible = false;
                if (type == LoggedUserUtility.userType.contestant || type == LoggedUserUtility.userType.captain)
                {   //wyswietlanie zawodow na które zaproszony jest zawodnik
                    List<zawody> competitions = ContestantDataUtility.getContestantsCurrentCompetitions(LoggedUserUtility.getLoggedContestant().id_zawodnik, true);
                    CompetitionView.DataSource = competitions.Select(x => new { Nazwa = x.nazwa, competitionId = x.id_zawody }).ToList();
                    CompetitionView.Columns["competitionId"].Visible = false;                   
                }
                else if(type == LoggedUserUtility.userType.supervisor || type == LoggedUserUtility.userType.organiser)
                {   //wyswietlanie zawodow zarzadzanych przez organizatora/opiekuna                    
                    List<zawody> competitions = LoggedUserUtility.getEmployeesCompetitions(LoggedUserUtility.getLoggedEmployee().id_pracownik);
                    var competitionsAccept = competitions.Select(x => new { Nazwa = x.nazwa, Akcja = "Akceptuj" }).ToList();
                    CompetitionView.DataSource = competitions.Select(x => new { Nazwa = x.nazwa, competitionId = x.id_zawody }).ToList();
                }
            }
            else if(kind == "druzyny")  //done
            {
                CompetitionBox.Text = "Lista drużyn";
                ConfirmButton.Visible = false;

                fillWithInvitations(CompetitionView, LoggedUserUtility.getLoggedContestant().id_zawodnik);
            }
            else
            {                
                CompetitionBox.Text = "Lista wyścigów";

                ConfirmButton.Visible = false;
                if (type == LoggedUserUtility.userType.contestant || type == LoggedUserUtility.userType.captain)  //wyswietlanie wyscigow w ktorych bierze udzial/jest zaproszony zawodnik
                {
                    
                    //TODO filtrowanie zaproszen, ktore jeszcze nie sa zaakceptowane
                    var races = CompetitionDataUtility.getRacesInCompetition(competitionId);

                    CompetitionView.DataSource = races.AsEnumerable().Select((x, index) => new { Nazwa = "Wyścig nr. " + (index + 1), competitionId = x.id_zawody, Akcja = "Akceptuj"  }).ToList();
                    //TODO po kliknieciu zaakceptowane update _zawodnik_wyscig
                }
                else if (type == LoggedUserUtility.userType.supervisor || type == LoggedUserUtility.userType.organiser) // wyscigi ktorymi zarzadzaja organizator/opiekun
                {
                    var races = CompetitionDataUtility.getRacesInCompetition(competitionId);
                    CompetitionView.DataSource = races.AsEnumerable().Select((x, index) => new { Nazwa = "Wyścig nr. " + (index + 1), competitionId = x.id_zawody }).ToList();
                    //po kliknieciu przejscie do edycji trasy wyscigu
                }
            }
            CompetitionView.ClearSelection();
            CompetitionView.CurrentCell = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CompetitionBox = new System.Windows.Forms.GroupBox();
            this.CompetitionView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.Nazwa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InviteColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.CompetitionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompetitionView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CompetitionBox
            // 
            this.CompetitionBox.Controls.Add(this.CompetitionView);
            this.CompetitionBox.Location = new System.Drawing.Point(13, 13);
            this.CompetitionBox.Name = "CompetitionBox";
            this.CompetitionBox.Size = new System.Drawing.Size(305, 320);
            this.CompetitionBox.TabIndex = 0;
            this.CompetitionBox.TabStop = false;
            this.CompetitionBox.Text = "groupBox1";
            // 
            // CompetitionView
            // 
            this.CompetitionView.AllowUserToAddRows = false;
            this.CompetitionView.AllowUserToDeleteRows = false;
            this.CompetitionView.AllowUserToOrderColumns = true;
            this.CompetitionView.AllowUserToResizeColumns = false;
            this.CompetitionView.AllowUserToResizeRows = false;
            this.CompetitionView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompetitionView.ColumnHeadersVisible = false;
            this.CompetitionView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nazwa,
            this.teamId,
            this.Id,
            this.InviteColumn});
            this.CompetitionView.Location = new System.Drawing.Point(7, 31);
            this.CompetitionView.Name = "CompetitionView";
            this.CompetitionView.RowHeadersVisible = false;
            this.CompetitionView.RowHeadersWidth = 51;
            this.CompetitionView.RowTemplate.Height = 24;
            this.CompetitionView.Size = new System.Drawing.Size(288, 273);
            this.CompetitionView.TabIndex = 1;
            this.CompetitionView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultView_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ConfirmButton);
            this.groupBox2.Controls.Add(this.ReturnButton);
            this.groupBox2.Location = new System.Drawing.Point(13, 340);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 68);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(154, 22);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(141, 35);
            this.ConfirmButton.TabIndex = 1;
            this.ConfirmButton.Text = "Zatwierdź";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(7, 22);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(141, 35);
            this.ReturnButton.TabIndex = 0;
            this.ReturnButton.Text = "Powrót";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // Nazwa
            // 
            this.Nazwa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Nazwa.DataPropertyName = "Nazwa";
            this.Nazwa.HeaderText = "Nazwa";
            this.Nazwa.MinimumWidth = 6;
            this.Nazwa.Name = "Nazwa";
            this.Nazwa.ReadOnly = true;
            this.Nazwa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Nazwa.Width = 120;
            // 
            // teamId
            // 
            this.teamId.DataPropertyName = "teamId";
            this.teamId.HeaderText = "teamId";
            this.teamId.MinimumWidth = 6;
            this.teamId.Name = "teamId";
            this.teamId.Visible = false;
            this.teamId.Width = 125;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "competitionId";
            this.Id.HeaderText = "competitionId";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // InviteColumn
            // 
            this.InviteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InviteColumn.DataPropertyName = "Akcja";
            this.InviteColumn.HeaderText = "Zaproszenia";
            this.InviteColumn.MinimumWidth = 6;
            this.InviteColumn.Name = "InviteColumn";
            this.InviteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.InviteColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.InviteColumn.Width = 115;
            // 
            // CompetitionsTeamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 419);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CompetitionBox);
            this.Name = "CompetitionsTeamsForm";
            this.Text = "Multiliga";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CompetitionsTeamsForm_FormClosed);
            this.CompetitionBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompetitionView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox CompetitionBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.DataGridView CompetitionView;

        private void ResultView_CellClick(object sender, DataGridViewCellEventArgs e)       //kiedy klikam komorke w gridview moich zawodow/druzyn
        {
            var loggedUserType = LoggedUserUtility.getCurrentUserType();
            var loggedContestant = LoggedUserUtility.getLoggedContestant();
            if (CompetitionBox.Text == "Lista zawodów")
            {
                DataGridViewTextBoxCell IDcell = (DataGridViewTextBoxCell)CompetitionView.Rows[e.RowIndex].Cells[2];      //cells[2] -> bierzemy dane z kolumny ID
                competitionId = Convert.ToInt32(IDcell.Value);

                
                CompetitionsTeamsForm competitionsTeamsForm = new CompetitionsTeamsForm();
                competitionsTeamsForm.SetWindow("wyścigi", competitionId);

                competitionsTeamsForm.ConfirmButton.Visible = false;
                competitionsTeamsForm.Show();
            }
            else if(CompetitionBox.Text == "Lista wyścigów")
            {
                //na podstawie competitionId otworz wyscigi     
                if (loggedUserType == LoggedUserUtility.userType.organiser || loggedUserType == LoggedUserUtility.userType.supervisor)
                {
                    CreateDeleteEditForm createDeleteEditForm = new CreateDeleteEditForm();
                    createDeleteEditForm.SetCreateForm("Podaj trasę wyścigów", "", "", "", "Trasa", "", "", "");
                    createDeleteEditForm.Show();
                }
            }
            else if (CompetitionBox.Text == "Lista drużyn")
            {
                DataGridViewCell clickedCell = (DataGridViewCell)CompetitionView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DataGridViewTextBoxCell teamIdCell = (DataGridViewTextBoxCell)CompetitionView.Rows[e.RowIndex].Cells[3];   //teamId w 3 kolumnie
                if (clickedCell.Value == "Akceptuj")
                {
                    ContestantDataUtility.acceptTeamInvitation(loggedContestant.id_zawodnik, Convert.ToInt32(teamIdCell.Value));
                    fillWithInvitations(CompetitionView, loggedContestant.id_zawodnik);
                }
                
            }
        }


        private void fillWithInvitations(DataGridView gridView, int contestantId)
        {
            var invitations = ContestantDataUtility.getContestantsTeamInvitations(contestantId);
            gridView.DataSource = invitations.Select(x => new { Nazwa = x.Item1.nazwa, Akcja = x.Item2, teamId = x.Item1.id_druzyna }).ToList();
        }

        private DataGridViewTextBoxColumn Nazwa;
        private DataGridViewTextBoxColumn teamId;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewLinkColumn InviteColumn;
    }
}