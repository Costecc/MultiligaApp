namespace MultiligaApp
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private int _user;

        public void SetMenu(int user)
        {
            _user = user;
            //jeśli użytkownik ma tylko możliwość logowania, nie może wyszukiwać
            if (_user > 4)
            {
                wyszukajToolStripMenuItem.Visible = false; 
            }

            //organizator ma prawo do zarządzania zawodami - ustawienie przycisku jako widocznego
            if(_user == 1)
                zarzadzajZawodamiToolStripMenuItem.Visible = true;

            //zawodnik ma prawo do zakłądania drużyny
            if (_user == 4)
                załóżNowaDrużynęToolStripMenuItem.Visible = true;
        }
        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mojeKontoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmieńHasłoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.przypomnijHasłoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edytujKontoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuńKontoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyszukajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drużynaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graczToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zawodyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mojeZawodyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zarzadzajZawodamiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajNoweZawodyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usunZawodyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edytujZawodyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.drużynyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mojeDrużynnyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.załóżNowaDrużynęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyścigiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wprowadźTrasęWyściguToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utwórzNoweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuńToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edytujZawodyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogoutLabel = new System.Windows.Forms.LinkLabel();
            this.ądzajZawodamiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Current = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.Current.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mojeKontoToolStripMenuItem,
            this.wyszukajToolStripMenuItem,
            this.zawodyToolStripMenuItem,
            this.drużynyToolStripMenuItem,
            this.wyścigiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(839, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mojeKontoToolStripMenuItem
            // 
            this.mojeKontoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zmieńHasłoToolStripMenuItem,
            this.przypomnijHasłoToolStripMenuItem,
            this.edytujKontoToolStripMenuItem,
            this.usuńKontoToolStripMenuItem});
            this.mojeKontoToolStripMenuItem.Name = "mojeKontoToolStripMenuItem";
            this.mojeKontoToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.mojeKontoToolStripMenuItem.Text = "Moje konto";
            // 
            // zmieńHasłoToolStripMenuItem
            // 
            this.zmieńHasłoToolStripMenuItem.Name = "zmieńHasłoToolStripMenuItem";
            this.zmieńHasłoToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.zmieńHasłoToolStripMenuItem.Text = "Zmień hasło";
            this.zmieńHasłoToolStripMenuItem.Click += new System.EventHandler(this.zmieńHasłoToolStripMenuItem_Click);
            // 
            // przypomnijHasłoToolStripMenuItem
            // 
            this.przypomnijHasłoToolStripMenuItem.Name = "przypomnijHasłoToolStripMenuItem";
            this.przypomnijHasłoToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.przypomnijHasłoToolStripMenuItem.Text = "Przypomnij hasło";
            this.przypomnijHasłoToolStripMenuItem.Click += new System.EventHandler(this.przypomnijHasłoToolStripMenuItem_Click);
            // 
            // edytujKontoToolStripMenuItem
            // 
            this.edytujKontoToolStripMenuItem.Name = "edytujKontoToolStripMenuItem";
            this.edytujKontoToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.edytujKontoToolStripMenuItem.Text = "Edytuj konto";
            this.edytujKontoToolStripMenuItem.Click += new System.EventHandler(this.edytujKontoToolStripMenuItem_Click);
            // 
            // usuńKontoToolStripMenuItem
            // 
            this.usuńKontoToolStripMenuItem.Name = "usuńKontoToolStripMenuItem";
            this.usuńKontoToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.usuńKontoToolStripMenuItem.Text = "Usuń konto";
            this.usuńKontoToolStripMenuItem.Click += new System.EventHandler(this.usuńKontoToolStripMenuItem_Click);
            // 
            // wyszukajToolStripMenuItem
            // 
            this.wyszukajToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drużynaToolStripMenuItem,
            this.graczToolStripMenuItem});
            this.wyszukajToolStripMenuItem.Name = "wyszukajToolStripMenuItem";
            this.wyszukajToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.wyszukajToolStripMenuItem.Text = "Wyszukaj";
            // 
            // drużynaToolStripMenuItem
            // 
            this.drużynaToolStripMenuItem.Name = "drużynaToolStripMenuItem";
            this.drużynaToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.drużynaToolStripMenuItem.Text = "Drużyna";
            this.drużynaToolStripMenuItem.Click += new System.EventHandler(this.drużynaToolStripMenuItem_Click);
            // 
            // graczToolStripMenuItem
            // 
            this.graczToolStripMenuItem.Name = "graczToolStripMenuItem";
            this.graczToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.graczToolStripMenuItem.Text = "Gracz";
            this.graczToolStripMenuItem.Click += new System.EventHandler(this.graczToolStripMenuItem_Click);
            // 
            // zawodyToolStripMenuItem
            // 
            this.zawodyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mojeZawodyToolStripMenuItem,
            this.zarzadzajZawodamiToolStripMenuItem});
            this.zawodyToolStripMenuItem.Name = "zawodyToolStripMenuItem";
            this.zawodyToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.zawodyToolStripMenuItem.Text = "Zawody";
            // 
            // mojeZawodyToolStripMenuItem
            // 
            this.mojeZawodyToolStripMenuItem.Name = "mojeZawodyToolStripMenuItem";
            this.mojeZawodyToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.mojeZawodyToolStripMenuItem.Text = "Moje zawody";
            this.mojeZawodyToolStripMenuItem.Click += new System.EventHandler(this.mojeZawodyToolStripMenuItem_Click);
            // 
            // zarzadzajZawodamiToolStripMenuItem
            // 
            this.zarzadzajZawodamiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajNoweZawodyToolStripMenuItem,
            this.usunZawodyToolStripMenuItem,
            this.edytujZawodyToolStripMenuItem1});
            this.zarzadzajZawodamiToolStripMenuItem.Name = "zarzadzajZawodamiToolStripMenuItem";
            this.zarzadzajZawodamiToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.zarzadzajZawodamiToolStripMenuItem.Text = "Zarzadzaj zawodami";
            this.zarzadzajZawodamiToolStripMenuItem.Visible = false;
            // 
            // dodajNoweZawodyToolStripMenuItem
            // 
            this.dodajNoweZawodyToolStripMenuItem.Name = "dodajNoweZawodyToolStripMenuItem";
            this.dodajNoweZawodyToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.dodajNoweZawodyToolStripMenuItem.Text = "Utwórz nowe zawody";
            this.dodajNoweZawodyToolStripMenuItem.Click += new System.EventHandler(this.utwórzNoweToolStripMenuItem_Click);
            // 
            // usunZawodyToolStripMenuItem
            // 
            this.usunZawodyToolStripMenuItem.Name = "usunZawodyToolStripMenuItem";
            this.usunZawodyToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.usunZawodyToolStripMenuItem.Text = "Usun zawody";
            this.usunZawodyToolStripMenuItem.Click += new System.EventHandler(this.usuńToolStripMenuItem_Click);
            // 
            // edytujZawodyToolStripMenuItem1
            // 
            this.edytujZawodyToolStripMenuItem1.Name = "edytujZawodyToolStripMenuItem1";
            this.edytujZawodyToolStripMenuItem1.Size = new System.Drawing.Size(226, 26);
            this.edytujZawodyToolStripMenuItem1.Text = "Edytuj zawody";
            this.edytujZawodyToolStripMenuItem1.Click += new System.EventHandler(this.edytujZawodyToolStripMenuItem_Click);
            // 
            // drużynyToolStripMenuItem
            // 
            this.drużynyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mojeDrużynnyToolStripMenuItem});
            this.drużynyToolStripMenuItem.Name = "drużynyToolStripMenuItem";
            this.drużynyToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.drużynyToolStripMenuItem.Text = "Drużyny";
            // 
            // mojeDrużynnyToolStripMenuItem
            // 
            this.mojeDrużynnyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.załóżNowaDrużynęToolStripMenuItem});
            this.mojeDrużynnyToolStripMenuItem.Name = "mojeDrużynnyToolStripMenuItem";
            this.mojeDrużynnyToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.mojeDrużynnyToolStripMenuItem.Text = "Moje drużyny";
            this.mojeDrużynnyToolStripMenuItem.Click += new System.EventHandler(this.mojeDrużynyToolStripMenuItem_Click);
            // 
            // załóżNowaDrużynęToolStripMenuItem
            // 
            this.załóżNowaDrużynęToolStripMenuItem.Name = "załóżNowaDrużynęToolStripMenuItem";
            this.załóżNowaDrużynęToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.załóżNowaDrużynęToolStripMenuItem.Text = "Załóż nowa drużynę";
            this.załóżNowaDrużynęToolStripMenuItem.Visible = false;
            this.załóżNowaDrużynęToolStripMenuItem.Click += new System.EventHandler(this.załóżNowaDrużynęToolStripMenuItem_Click);
            // 
            // wyścigiToolStripMenuItem
            // 
            this.wyścigiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wprowadźTrasęWyściguToolStripMenuItem});
            this.wyścigiToolStripMenuItem.Name = "wyścigiToolStripMenuItem";
            this.wyścigiToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.wyścigiToolStripMenuItem.Text = "Wyścigi";
            this.wyścigiToolStripMenuItem.Visible = false;
            // 
            // wprowadźTrasęWyściguToolStripMenuItem
            // 
            this.wprowadźTrasęWyściguToolStripMenuItem.Name = "wprowadźTrasęWyściguToolStripMenuItem";
            this.wprowadźTrasęWyściguToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.wprowadźTrasęWyściguToolStripMenuItem.Text = "Wprowadź trasę wyścigu";
            this.wprowadźTrasęWyściguToolStripMenuItem.Click += new System.EventHandler(this.wprowadźTrasęWyściguToolStripMenuItem_Click);
            // 
            // utwórzNoweToolStripMenuItem
            // 
            this.utwórzNoweToolStripMenuItem.Name = "utwórzNoweToolStripMenuItem";
            this.utwórzNoweToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.utwórzNoweToolStripMenuItem.Text = "Utwórz nowe zawody";
            this.utwórzNoweToolStripMenuItem.Click += new System.EventHandler(this.utwórzNoweToolStripMenuItem_Click);
            // 
            // usuńToolStripMenuItem
            // 
            this.usuńToolStripMenuItem.Name = "usuńToolStripMenuItem";
            this.usuńToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.usuńToolStripMenuItem.Text = "Usuń zawody";
            this.usuńToolStripMenuItem.Click += new System.EventHandler(this.usuńToolStripMenuItem_Click);
            // 
            // edytujZawodyToolStripMenuItem
            // 
            this.edytujZawodyToolStripMenuItem.Name = "edytujZawodyToolStripMenuItem";
            this.edytujZawodyToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.edytujZawodyToolStripMenuItem.Text = "Edytuj zawody";
            this.edytujZawodyToolStripMenuItem.Click += new System.EventHandler(this.edytujZawodyToolStripMenuItem_Click);
            // 
            // LogoutLabel
            // 
            this.LogoutLabel.ActiveLinkColor = System.Drawing.Color.Black;
            this.LogoutLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoutLabel.AutoSize = true;
            this.LogoutLabel.BackColor = System.Drawing.Color.White;
            this.LogoutLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoutLabel.DisabledLinkColor = System.Drawing.Color.White;
            this.LogoutLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LogoutLabel.LinkColor = System.Drawing.Color.Black;
            this.LogoutLabel.Location = new System.Drawing.Point(761, 4);
            this.LogoutLabel.Name = "LogoutLabel";
            this.LogoutLabel.Size = new System.Drawing.Size(64, 20);
            this.LogoutLabel.TabIndex = 1;
            this.LogoutLabel.TabStop = true;
            this.LogoutLabel.Text = "Wyloguj";
            this.LogoutLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LogoutLabel_LinkClicked);
            // 
            // ądzajZawodamiToolStripMenuItem
            // 
            this.ądzajZawodamiToolStripMenuItem.Name = "ądzajZawodamiToolStripMenuItem";
            this.ądzajZawodamiToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // Current
            // 
            this.Current.Controls.Add(this.groupBox4);
            this.Current.Controls.Add(this.groupBox3);
            this.Current.Controls.Add(this.groupBox5);
            this.Current.Controls.Add(this.groupBox2);
            this.Current.Location = new System.Drawing.Point(25, 48);
            this.Current.Name = "Current";
            this.Current.Size = new System.Drawing.Size(787, 526);
            this.Current.TabIndex = 2;
            this.Current.TabStop = false;
            this.Current.Text = "Aktualności";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(404, 275);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(356, 221);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(404, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(356, 221);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(26, 275);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(356, 221);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(26, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 221);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 591);
            this.Controls.Add(this.Current);
            this.Controls.Add(this.LogoutLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Multiliga";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Current.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mojeKontoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmieńHasłoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem przypomnijHasłoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edytujKontoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuńKontoToolStripMenuItem;
        private System.Windows.Forms.LinkLabel LogoutLabel;
        private System.Windows.Forms.ToolStripMenuItem wyszukajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drużynaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graczToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zawodyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mojeZawodyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ądzajZawodamiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zarzadzajZawodamiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drużynyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mojeDrużynnyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utwórzNoweToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuńToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edytujZawodyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem załóżNowaDrużynęToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajNoweZawodyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usunZawodyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edytujZawodyToolStripMenuItem1;
        private System.Windows.Forms.GroupBox Current;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem wyścigiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wprowadźTrasęWyściguToolStripMenuItem;
    }
}

