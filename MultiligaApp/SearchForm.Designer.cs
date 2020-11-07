using System.Windows.Forms;
using System;
namespace MultiligaApp
{
    partial class SearchForm
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

        private int _user;

        public void SetSearchingMenu(int user, string groupBox, string label1, string label2, string label3, string label4, string label5)
        {
            _user = user;
            this.SearchMenu.Text = groupBox;
            this.label1.Text = label1;
            this.label2.Text = label2;
            this.label3.Text = label3;
            this.label4.Text = label4;
            this.label5.Text = label5;

            if (label1 == "")
            {
                this.label1.Visible = false;
                this.textBox1.Visible = false;
            }
            if (label2 == "")
            {
                this.label2.Visible = false;
                this.textBox2.Visible = false;
            }
            if (label5 == "")
            {
                this.label5.Visible = false;
                this.textBox5.Visible = false;
            }

            //ResultView.Rows.Add("Motocross Lublin");
            //ResultView.Rows.Add("Janusz Kamiński");
            //ResultView.Rows.Add("Janusz Nowak");
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchMenu = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchResults = new System.Windows.Forms.GroupBox();
            this.ResultView = new System.Windows.Forms.DataGridView();
            this.SearchMenu.SuspendLayout();
            this.SearchResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultView)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchMenu
            // 
            this.SearchMenu.Controls.Add(this.button2);
            this.SearchMenu.Controls.Add(this.textBox5);
            this.SearchMenu.Controls.Add(this.textBox4);
            this.SearchMenu.Controls.Add(this.SearchButton);
            this.SearchMenu.Controls.Add(this.textBox3);
            this.SearchMenu.Controls.Add(this.textBox1);
            this.SearchMenu.Controls.Add(this.textBox2);
            this.SearchMenu.Controls.Add(this.label5);
            this.SearchMenu.Controls.Add(this.label3);
            this.SearchMenu.Controls.Add(this.label2);
            this.SearchMenu.Controls.Add(this.label4);
            this.SearchMenu.Controls.Add(this.label1);
            this.SearchMenu.Location = new System.Drawing.Point(13, 13);
            this.SearchMenu.Name = "SearchMenu";
            this.SearchMenu.Size = new System.Drawing.Size(317, 304);
            this.SearchMenu.TabIndex = 0;
            this.SearchMenu.TabStop = false;
            this.SearchMenu.Text = "Parametry wyszukiwania";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(6, 245);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 39);
            this.button2.TabIndex = 11;
            this.button2.Text = "Powrót";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(116, 151);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(187, 22);
            this.textBox5.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(116, 123);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(187, 22);
            this.textBox4.TabIndex = 9;
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchButton.Location = new System.Drawing.Point(154, 245);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(149, 39);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "Szukaj";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(116, 92);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(187, 22);
            this.textBox3.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 22);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(116, 61);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(187, 22);
            this.textBox2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "label5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // SearchResults
            // 
            this.SearchResults.Controls.Add(this.ResultView);
            this.SearchResults.Location = new System.Drawing.Point(336, 12);
            this.SearchResults.Name = "SearchResults";
            this.SearchResults.Size = new System.Drawing.Size(259, 305);
            this.SearchResults.TabIndex = 1;
            this.SearchResults.TabStop = false;
            this.SearchResults.Text = "Wyniki wyszukiwania";
            // 
            // ResultView
            // 
            this.ResultView.AllowUserToAddRows = false;
            this.ResultView.AllowUserToDeleteRows = false;
            this.ResultView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultView.ColumnHeadersVisible = false;
            this.ResultView.Location = new System.Drawing.Point(10, 34);
            this.ResultView.Name = "ResultView";
            this.ResultView.RowHeadersVisible = false;
            this.ResultView.RowHeadersWidth = 51;
            this.ResultView.RowTemplate.Height = 24;
            this.ResultView.Size = new System.Drawing.Size(240, 250);
            this.ResultView.TabIndex = 0;
            this.ResultView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultView_CellClick);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 330);
            this.Controls.Add(this.SearchResults);
            this.Controls.Add(this.SearchMenu);
            this.Name = "SearchForm";
            this.Text = "Wyszukiwanie";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SearchForm_FormClosed);
            this.Load += new System.EventHandler(this.SearchingForm_Load);
            this.SearchMenu.ResumeLayout(false);
            this.SearchMenu.PerformLayout();
            this.SearchResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SearchMenu;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.GroupBox SearchResults;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView ResultView;

        private void ResultView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxCell IDcell = (DataGridViewTextBoxCell)ResultView.Rows[e.RowIndex].Cells[0];      //cells[0] -> bierzemy dane z kolumny ID
            ProfileForm profileForm = new ProfileForm();

            if(SearchMenu.Text == "Wyszukiwanie gracza")
            {
                //TODO               
                profileForm.SetProfile(_user, "Profil zawodnika", "Zaproś do drużyny", "Imię i nazwisko", "Email", "Drużyna", "Aktualne zawody", "Ukończone zawody", "Osiągnięcia", "O sobie");
            }
            else if(SearchMenu.Text == "Wyszukiwanie drużyny")
            {
                profileForm.SetProfile(_user, "Profil drużyny", "Zaproś do zawodów", "Nazwa", "Dyscyplina", "Kapitan", "O druzynie", "Aktualne rozgrywki", "Poprzednie rozgrywki", "Osiągnięcia");
            }

            //TODO
            //Tutaj uzupełnić pozostałe pola - z bazy danych. Na razie tylko imie i nazwisko
            //profileForm.FillProfileData(cell.Value.ToString(), "j.kaminski9508@wp.pl", "Motocross Lublin", "I Liga Motocross", "II Liga, I Liga", "Puchar Polski (2016)", "Fan szybkiej jazdy");
            //profileForm.FillProfileData(IDcell.Value.ToString(), "Motocross", "Andrzej Nowak", "I Liga", "II Liga", "Puchar Polski (2016)", "");

            SqlHelper.showContestantProfile(profileForm, _user, Convert.ToInt32(IDcell.Value));
            profileForm.Show();
        }
    }
}