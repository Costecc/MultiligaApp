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
            if (_user > 4)
                wyszukajToolStripMenuItem.Visible = false;
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
            this.LogoutLabel = new System.Windows.Forms.LinkLabel();
            this.ądzajZawodamiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drużynyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mojeDrużynnyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mojeKontoToolStripMenuItem,
            this.wyszukajToolStripMenuItem,
            this.zawodyToolStripMenuItem,
            this.drużynyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(986, 28);
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
            this.zarzadzajZawodamiToolStripMenuItem.Name = "zarzadzajZawodamiToolStripMenuItem";
            this.zarzadzajZawodamiToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.zarzadzajZawodamiToolStripMenuItem.Text = "Zarzadzaj zawodami";
            this.zarzadzajZawodamiToolStripMenuItem.Click += new System.EventHandler(this.zarzadzajZawodamiToolStripMenuItem_Click);
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
            this.LogoutLabel.Location = new System.Drawing.Point(908, 4);
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
            this.mojeDrużynnyToolStripMenuItem.Name = "mojeDrużynnyToolStripMenuItem";
            this.mojeDrużynnyToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.mojeDrużynnyToolStripMenuItem.Text = "Moje drużyny";
            this.mojeDrużynnyToolStripMenuItem.Click += new System.EventHandler(this.mojeDrużynyToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 609);
            this.Controls.Add(this.LogoutLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Multiliga";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}

