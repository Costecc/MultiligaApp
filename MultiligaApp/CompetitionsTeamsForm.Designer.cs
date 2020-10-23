using System.Windows.Forms;

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

        public void SetWindow(string kind)
        {
            if(kind == "zawody")
            {
                CompetitionBox.Text = "Lista zawodów";
                ConfirmButton.Visible = false;
            }
            else if(kind == "druzyny")
            {
                CompetitionBox.Text = "Lista drużyn";
                ConfirmButton.Visible = false;
            }
            else
            {
                CompetitionBox.Text = "Lista wyścigów";
                ConfirmButton.Visible = false;
            }

            //TODO testowe dane zamienić na prawdziwe z bazy
            //CompetitionView.Rows.Add("Zawody 1", "Lista wyścigów");
            //CompetitionView.Rows.Add("Zawody 2", "Lista wyścigów");

            CompetitionView.Rows.Add("Liga szachowa Puławy", "Akceptuj");
            CompetitionView.Rows.Add("Klub tenisowy Lublin", "");
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
            this.MatchColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InviteColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.CompetitionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompetitionView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CompetitionBox
            // 
            this.CompetitionBox.Controls.Add(this.CompetitionView);
            this.CompetitionBox.Location = new System.Drawing.Point(10, 11);
            this.CompetitionBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CompetitionBox.Name = "CompetitionBox";
            this.CompetitionBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CompetitionBox.Size = new System.Drawing.Size(229, 260);
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
            this.MatchColumn,
            this.InviteColumn});
            this.CompetitionView.Location = new System.Drawing.Point(5, 25);
            this.CompetitionView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CompetitionView.Name = "CompetitionView";
            this.CompetitionView.RowHeadersVisible = false;
            this.CompetitionView.RowTemplate.Height = 24;
            this.CompetitionView.Size = new System.Drawing.Size(216, 222);
            this.CompetitionView.TabIndex = 1;
            this.CompetitionView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultView_CellClick);
            // 
            // MatchColumn
            // 
            this.MatchColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MatchColumn.HeaderText = "Mecze";
            this.MatchColumn.Name = "MatchColumn";
            this.MatchColumn.ReadOnly = true;
            this.MatchColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MatchColumn.Width = 120;
            // 
            // InviteColumn
            // 
            this.InviteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InviteColumn.HeaderText = "Zaproszenia";
            this.InviteColumn.Name = "InviteColumn";
            this.InviteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.InviteColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.InviteColumn.Width = 115;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ConfirmButton);
            this.groupBox2.Controls.Add(this.ReturnButton);
            this.groupBox2.Location = new System.Drawing.Point(10, 276);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(229, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(116, 18);
            this.ConfirmButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(106, 28);
            this.ConfirmButton.TabIndex = 1;
            this.ConfirmButton.Text = "Zatwierdź";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(5, 18);
            this.ReturnButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(106, 28);
            this.ReturnButton.TabIndex = 0;
            this.ReturnButton.Text = "Powrót";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // CompetitionsTeamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 340);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CompetitionBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchColumn;
        private System.Windows.Forms.DataGridViewLinkColumn InviteColumn;

        private void ResultView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = (DataGridViewCell)CompetitionView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if(CompetitionBox.Text == "Lista zawodów")
            {
                CompetitionsTeamsForm competitionsTeamsForm = new CompetitionsTeamsForm();
                competitionsTeamsForm.SetWindow("wyścigi");
                competitionsTeamsForm.CompetitionView.Rows.Clear();
                competitionsTeamsForm.CompetitionView.Rows.Add("Wyścigi nr 1", "Dodaj trasę");
                competitionsTeamsForm.CompetitionView.Rows.Add("Wyścigi nr 2", "Dodaj trasę");
                //competitionsTeamsForm.CompetitionView.Rows.Add("Wyścigi nr 1", "");
                //competitionsTeamsForm.CompetitionView.Rows.Add("Wyścigi nr 2", "");
                competitionsTeamsForm.ConfirmButton.Visible = false;
                competitionsTeamsForm.Show();
            }
            else if(CompetitionBox.Text == "Lista wyścigów")
            {
                CreateDeleteEditForm createDeleteEditForm = new CreateDeleteEditForm();
                createDeleteEditForm.SetCreateForm("Podaj trasę wyścigów", "", "", "", "Trasa", "", "", "");
                createDeleteEditForm.Show();
            }
            else if (CompetitionBox.Text == "Lista drużyn")
            {
                MessageBox.Show("Zaakceptowano zaproszenie", "Akceptacja zaproszenia");
            }
        }
    }
}