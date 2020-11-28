using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace MultiligaApp
{
    partial class ProfileForm
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

        public void SetProfile(int user, string groupBox, string inviteMessage, string label1, string label2, string label3, string label4, string label5, string label6, string label7)
        {
            this.ProfileView.Text = groupBox;
            this.label1.Text = label1;
            this.label2.Text = label2;
            this.label3.Text = label3;
            this.label4.Text = label4;
            this.label5.Text = label5;
            this.label6.Text = label6;
            this.label7.Text = label7;
            this.InviteButton.Text = inviteMessage;

            if (inviteMessage == "Zaproś do zawodów")
            {
                if (user == 3)  //tylko opiekun (user = 3) może dodać druzyne do zawodów
                    InviteButton.Visible = true;
            }
            else
            {
                if(user == 2)   //tylko kapitan (user = 2) może dodać zawodnika do drużyny
                    InviteButton.Visible = true;
            }

            MatchesView.Rows.Add("Motocross Lublin 1:0 Olsztyn");
            MatchesView.Rows.Add("XYZ 0:1 Motocross Lublin");
        }

        public void FillProfileDataContestant(string name, string email, List<string> teams, List<zawody> currentCompetitions, List<zawody> pastCompetitions, List<result> achievements, string aboutMe )
        {
            this.label8.Text = name;
            this.label9.Text = email;                     

            dataGridView1.DataSource = currentCompetitions.Select(x => new { Name = x.nazwa }).ToList();
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;

            dataGridView2.DataSource = pastCompetitions.Select(x => new { Name = x.nazwa }).ToList();
            dataGridView2.ClearSelection();
            dataGridView2.CurrentCell = null;

            dataGridView3.DataSource = teams.Select(x => new { Name = x }).ToList();
            dataGridView3.ClearSelection();
            dataGridView3.CurrentCell = null;

            dataGridView5.DataSource = achievements.Select(x => new { Zawody = x.competitionName + x.raceName, Miejsce = x.place }).ToList();
            dataGridView5.ClearSelection();
            dataGridView5.CurrentCell = null;

            this.textBox1.Text = aboutMe;
        }

        public void FillProfileDataTeam(string name, string captain, List<string> disciplines, List<zawody> currentCompetitions, List<zawody> pastCompetitions, List<result> achievements, string aboutMe)
        {
            this.label8.Text = name;
            this.label9.Text = captain;

            dataGridView1.DataSource = currentCompetitions.Select(x => new { Name = x.nazwa }).ToList();
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;

            dataGridView2.DataSource = pastCompetitions.Select(x => new { Name = x.nazwa }).ToList();
            dataGridView2.ClearSelection();
            dataGridView2.CurrentCell = null;


            dataGridView3.DataSource = disciplines.Select(x => new { Name = x }).ToList();
            dataGridView3.ClearSelection();
            dataGridView3.CurrentCell = null;

            dataGridView5.DataSource = achievements.Select(x => new { Zawody = (x.competitionName + x.raceName), Miejsce = x.place }).ToList();
            dataGridView5.ClearSelection();
            dataGridView5.CurrentCell = null;

            this.textBox1.Text = aboutMe;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ProfileView = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MatchesView = new System.Windows.Forms.DataGridView();
            this.MatchColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.InviteButton = new System.Windows.Forms.Button();
            this.ProfileView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MatchesView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProfileView
            // 
            this.ProfileView.Controls.Add(this.textBox1);
            this.ProfileView.Controls.Add(this.dataGridView5);
            this.ProfileView.Controls.Add(this.dataGridView3);
            this.ProfileView.Controls.Add(this.dataGridView2);
            this.ProfileView.Controls.Add(this.label5);
            this.ProfileView.Controls.Add(this.dataGridView1);
            this.ProfileView.Controls.Add(this.label9);
            this.ProfileView.Controls.Add(this.label8);
            this.ProfileView.Controls.Add(this.label7);
            this.ProfileView.Controls.Add(this.label6);
            this.ProfileView.Controls.Add(this.label4);
            this.ProfileView.Controls.Add(this.label3);
            this.ProfileView.Controls.Add(this.label2);
            this.ProfileView.Controls.Add(this.label1);
            this.ProfileView.Controls.Add(this.pictureBox1);
            this.ProfileView.Location = new System.Drawing.Point(13, 13);
            this.ProfileView.Name = "ProfileView";
            this.ProfileView.Size = new System.Drawing.Size(582, 637);
            this.ProfileView.TabIndex = 0;
            this.ProfileView.TabStop = false;
            this.ProfileView.Text = "Profil";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(173, 556);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(326, 72);
            this.textBox1.TabIndex = 23;
            // 
            // dataGridView5
            // 
            this.dataGridView5.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Location = new System.Drawing.Point(175, 399);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.ReadOnly = true;
            this.dataGridView5.RowHeadersVisible = false;
            this.dataGridView5.RowHeadersWidth = 51;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView5.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView5.RowTemplate.Height = 24;
            this.dataGridView5.Size = new System.Drawing.Size(326, 117);
            this.dataGridView5.TabIndex = 22;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.ColumnHeadersVisible = false;
            this.dataGridView3.Location = new System.Drawing.Point(175, 99);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView3.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(326, 75);
            this.dataGridView3.TabIndex = 20;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ColumnHeadersVisible = false;
            this.dataGridView2.Location = new System.Drawing.Point(175, 296);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(326, 75);
            this.dataGridView2.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(172, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "label5";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(175, 198);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(326, 75);
            this.dataGridView1.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(352, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(352, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(170, 536);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "label6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MultiligaApp.Properties.Resources.pobrane1;
            this.pictureBox1.InitialImage = global::MultiligaApp.Properties.Resources.Free_Download_Motocross_Ktm_Image_620x388__1_1;
            this.pictureBox1.Location = new System.Drawing.Point(6, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MatchesView);
            this.groupBox1.Location = new System.Drawing.Point(13, 647);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 146);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wyniki";
            // 
            // MatchesView
            // 
            this.MatchesView.AllowUserToAddRows = false;
            this.MatchesView.AllowUserToDeleteRows = false;
            this.MatchesView.AllowUserToOrderColumns = true;
            this.MatchesView.AllowUserToResizeColumns = false;
            this.MatchesView.AllowUserToResizeRows = false;
            this.MatchesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatchesView.ColumnHeadersVisible = false;
            this.MatchesView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MatchColumn});
            this.MatchesView.Location = new System.Drawing.Point(7, 22);
            this.MatchesView.Name = "MatchesView";
            this.MatchesView.RowHeadersVisible = false;
            this.MatchesView.RowHeadersWidth = 51;
            this.MatchesView.RowTemplate.Height = 24;
            this.MatchesView.Size = new System.Drawing.Size(230, 118);
            this.MatchesView.TabIndex = 0;
            // 
            // MatchColumn
            // 
            this.MatchColumn.HeaderText = "Mecze";
            this.MatchColumn.MinimumWidth = 6;
            this.MatchColumn.Name = "MatchColumn";
            this.MatchColumn.Width = 220;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CancelButton);
            this.groupBox2.Controls.Add(this.InviteButton);
            this.groupBox2.Location = new System.Drawing.Point(270, 647);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 146);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // CancelButton
            // 
            this.CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelButton.Location = new System.Drawing.Point(16, 95);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(226, 36);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Powrót";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // InviteButton
            // 
            this.InviteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InviteButton.Location = new System.Drawing.Point(16, 53);
            this.InviteButton.Name = "InviteButton";
            this.InviteButton.Size = new System.Drawing.Size(226, 36);
            this.InviteButton.TabIndex = 0;
            this.InviteButton.Text = "button1";
            this.InviteButton.UseVisualStyleBackColor = true;
            this.InviteButton.Visible = false;
            this.InviteButton.Click += new System.EventHandler(this.InviteButton_Click);
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 805);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ProfileView);
            this.Name = "ProfileForm";
            this.Text = "Profil";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProfileForm_FormClosed);
            this.ProfileView.ResumeLayout(false);
            this.ProfileView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MatchesView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ProfileView;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button InviteButton;
        private System.Windows.Forms.DataGridView MatchesView;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchColumn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Label label5;
        private DataGridView dataGridView3;
        private DataGridView dataGridView5;
        private TextBox textBox1;
    }
}