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

        public void FillProfileData(string label8, string label9, string label10, string label11, string label12, string label13, string label14)
        {
            this.label8.Text = label8;
            this.label9.Text = label9;
            this.label10.Text = label10;
            this.label11.Text = label11;
            this.label12.Text = label12;
            this.label13.Text = label13;
            this.label14.Text = label14;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProfileView = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MatchesView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProfileView
            // 
            this.ProfileView.Controls.Add(this.label14);
            this.ProfileView.Controls.Add(this.label13);
            this.ProfileView.Controls.Add(this.label12);
            this.ProfileView.Controls.Add(this.label11);
            this.ProfileView.Controls.Add(this.label10);
            this.ProfileView.Controls.Add(this.label9);
            this.ProfileView.Controls.Add(this.label8);
            this.ProfileView.Controls.Add(this.label7);
            this.ProfileView.Controls.Add(this.label6);
            this.ProfileView.Controls.Add(this.label5);
            this.ProfileView.Controls.Add(this.label4);
            this.ProfileView.Controls.Add(this.label3);
            this.ProfileView.Controls.Add(this.label2);
            this.ProfileView.Controls.Add(this.label1);
            this.ProfileView.Controls.Add(this.pictureBox1);
            this.ProfileView.Location = new System.Drawing.Point(10, 11);
            this.ProfileView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ProfileView.Name = "ProfileView";
            this.ProfileView.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ProfileView.Size = new System.Drawing.Size(390, 176);
            this.ProfileView.TabIndex = 0;
            this.ProfileView.TabStop = false;
            this.ProfileView.Text = "Profil";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(264, 150);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "label14";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(264, 128);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "label13";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(264, 106);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "label12";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(264, 85);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "label11";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(264, 64);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 41);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(264, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(129, 150);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(129, 128);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 106);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MultiligaApp.Properties.Resources.pobrane1;
            this.pictureBox1.InitialImage = global::MultiligaApp.Properties.Resources.Free_Download_Motocross_Ktm_Image_620x388__1_1;
            this.pictureBox1.Location = new System.Drawing.Point(4, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 122);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MatchesView);
            this.groupBox1.Location = new System.Drawing.Point(14, 193);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(188, 119);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rozegrane mecze";
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
            this.MatchesView.Location = new System.Drawing.Point(5, 18);
            this.MatchesView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MatchesView.Name = "MatchesView";
            this.MatchesView.RowHeadersVisible = false;
            this.MatchesView.RowTemplate.Height = 24;
            this.MatchesView.Size = new System.Drawing.Size(172, 96);
            this.MatchesView.TabIndex = 0;
            // 
            // MatchColumn
            // 
            this.MatchColumn.HeaderText = "Mecze";
            this.MatchColumn.Name = "MatchColumn";
            this.MatchColumn.Width = 220;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CancelButton);
            this.groupBox2.Controls.Add(this.InviteButton);
            this.groupBox2.Location = new System.Drawing.Point(207, 193);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(193, 119);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // CancelButton
            // 
            this.CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelButton.Location = new System.Drawing.Point(12, 77);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(170, 29);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Powrót";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // InviteButton
            // 
            this.InviteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InviteButton.Location = new System.Drawing.Point(12, 43);
            this.InviteButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InviteButton.Name = "InviteButton";
            this.InviteButton.Size = new System.Drawing.Size(170, 29);
            this.InviteButton.TabIndex = 0;
            this.InviteButton.Text = "button1";
            this.InviteButton.UseVisualStyleBackColor = true;
            this.InviteButton.Visible = false;
            this.InviteButton.Click += new System.EventHandler(this.InviteButton_Click);
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 321);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ProfileView);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ProfileForm";
            this.Text = "Profil";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProfileForm_FormClosed);
            this.ProfileView.ResumeLayout(false);
            this.ProfileView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MatchesView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ProfileView;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
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
    }
}