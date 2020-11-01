namespace MultiligaApp
{
    partial class AccountEditForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.EditBox = new System.Windows.Forms.GroupBox();
            this.ImageChange = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.WinsText = new System.Windows.Forms.TextBox();
            this.WeightText = new System.Windows.Forms.TextBox();
            this.HeightText = new System.Windows.Forms.TextBox();
            this.PermissionsCheckBox = new System.Windows.Forms.CheckBox();
            this.EmailText = new System.Windows.Forms.TextBox();
            this.AccountWinsLabel = new System.Windows.Forms.Label();
            this.AccountWeightLabel = new System.Windows.Forms.Label();
            this.AccountHeightLabel = new System.Windows.Forms.Label();
            this.AccountPhotoLabel = new System.Windows.Forms.Label();
            this.AccountPasswordLabel = new System.Windows.Forms.Label();
            this.AccountEmailLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditBox
            // 
            this.EditBox.Controls.Add(this.ImageChange);
            this.EditBox.Controls.Add(this.linkLabel1);
            this.EditBox.Controls.Add(this.CancelButton);
            this.EditBox.Controls.Add(this.SaveButton);
            this.EditBox.Controls.Add(this.WinsText);
            this.EditBox.Controls.Add(this.WeightText);
            this.EditBox.Controls.Add(this.HeightText);
            this.EditBox.Controls.Add(this.PermissionsCheckBox);
            this.EditBox.Controls.Add(this.EmailText);
            this.EditBox.Controls.Add(this.AccountWinsLabel);
            this.EditBox.Controls.Add(this.AccountWeightLabel);
            this.EditBox.Controls.Add(this.AccountHeightLabel);
            this.EditBox.Controls.Add(this.AccountPhotoLabel);
            this.EditBox.Controls.Add(this.AccountPasswordLabel);
            this.EditBox.Controls.Add(this.AccountEmailLabel);
            this.EditBox.Location = new System.Drawing.Point(13, 13);
            this.EditBox.Name = "EditBox";
            this.EditBox.Size = new System.Drawing.Size(291, 333);
            this.EditBox.TabIndex = 0;
            this.EditBox.TabStop = false;
            this.EditBox.Text = "Edycja konta";
            // 
            // ImageChange
            // 
            this.ImageChange.AutoSize = true;
            this.ImageChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImageChange.LinkColor = System.Drawing.Color.Black;
            this.ImageChange.Location = new System.Drawing.Point(128, 90);
            this.ImageChange.Name = "ImageChange";
            this.ImageChange.Size = new System.Drawing.Size(155, 17);
            this.ImageChange.TabIndex = 17;
            this.ImageChange.TabStop = true;
            this.ImageChange.Text = "Zmień zdjęcie profilowe";
            this.ImageChange.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ImageChange_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(128, 62);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(85, 17);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Zmień hasło";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // CancelButton
            // 
            this.CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelButton.Location = new System.Drawing.Point(19, 284);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(254, 39);
            this.CancelButton.TabIndex = 15;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.Location = new System.Drawing.Point(19, 239);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(254, 39);
            this.SaveButton.TabIndex = 14;
            this.SaveButton.Text = "Zatwierdź";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // WinsText
            // 
            this.WinsText.Location = new System.Drawing.Point(128, 174);
            this.WinsText.Name = "WinsText";
            this.WinsText.Size = new System.Drawing.Size(145, 22);
            this.WinsText.TabIndex = 13;
            // 
            // WeightText
            // 
            this.WeightText.Location = new System.Drawing.Point(128, 147);
            this.WeightText.Name = "WeightText";
            this.WeightText.Size = new System.Drawing.Size(145, 22);
            this.WeightText.TabIndex = 12;
            // 
            // HeightText
            // 
            this.HeightText.Location = new System.Drawing.Point(128, 119);
            this.HeightText.Name = "HeightText";
            this.HeightText.Size = new System.Drawing.Size(145, 22);
            this.HeightText.TabIndex = 11;
            // 
            // PermissionsCheckBox
            // 
            this.PermissionsCheckBox.AutoSize = true;
            this.PermissionsCheckBox.Location = new System.Drawing.Point(19, 202);
            this.PermissionsCheckBox.Name = "PermissionsCheckBox";
            this.PermissionsCheckBox.Size = new System.Drawing.Size(236, 21);
            this.PermissionsCheckBox.TabIndex = 8;
            this.PermissionsCheckBox.Text = "Zgoda na wyświetlanie informacji";
            this.PermissionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // EmailText
            // 
            this.EmailText.Location = new System.Drawing.Point(128, 33);
            this.EmailText.Name = "EmailText";
            this.EmailText.Size = new System.Drawing.Size(145, 22);
            this.EmailText.TabIndex = 7;
            // 
            // AccountWinsLabel
            // 
            this.AccountWinsLabel.AutoSize = true;
            this.AccountWinsLabel.Location = new System.Drawing.Point(16, 174);
            this.AccountWinsLabel.Name = "AccountWinsLabel";
            this.AccountWinsLabel.Size = new System.Drawing.Size(82, 17);
            this.AccountWinsLabel.TabIndex = 5;
            this.AccountWinsLabel.Text = "Osiągnięcia";
            // 
            // AccountWeightLabel
            // 
            this.AccountWeightLabel.AutoSize = true;
            this.AccountWeightLabel.Location = new System.Drawing.Point(16, 145);
            this.AccountWeightLabel.Name = "AccountWeightLabel";
            this.AccountWeightLabel.Size = new System.Drawing.Size(45, 17);
            this.AccountWeightLabel.TabIndex = 4;
            this.AccountWeightLabel.Text = "Waga";
            // 
            // AccountHeightLabel
            // 
            this.AccountHeightLabel.AutoSize = true;
            this.AccountHeightLabel.Location = new System.Drawing.Point(16, 119);
            this.AccountHeightLabel.Name = "AccountHeightLabel";
            this.AccountHeightLabel.Size = new System.Drawing.Size(52, 17);
            this.AccountHeightLabel.TabIndex = 3;
            this.AccountHeightLabel.Text = "Wzrost";
            // 
            // AccountPhotoLabel
            // 
            this.AccountPhotoLabel.AutoSize = true;
            this.AccountPhotoLabel.Location = new System.Drawing.Point(16, 90);
            this.AccountPhotoLabel.Name = "AccountPhotoLabel";
            this.AccountPhotoLabel.Size = new System.Drawing.Size(54, 17);
            this.AccountPhotoLabel.TabIndex = 2;
            this.AccountPhotoLabel.Text = "Zdjęcie";
            // 
            // AccountPasswordLabel
            // 
            this.AccountPasswordLabel.AutoSize = true;
            this.AccountPasswordLabel.Location = new System.Drawing.Point(16, 61);
            this.AccountPasswordLabel.Name = "AccountPasswordLabel";
            this.AccountPasswordLabel.Size = new System.Drawing.Size(44, 17);
            this.AccountPasswordLabel.TabIndex = 1;
            this.AccountPasswordLabel.Text = "Hasło";
            // 
            // AccountEmailLabel
            // 
            this.AccountEmailLabel.AutoSize = true;
            this.AccountEmailLabel.Location = new System.Drawing.Point(16, 33);
            this.AccountEmailLabel.Name = "AccountEmailLabel";
            this.AccountEmailLabel.Size = new System.Drawing.Size(42, 17);
            this.AccountEmailLabel.TabIndex = 0;
            this.AccountEmailLabel.Text = "Email";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // AccountEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 361);
            this.Controls.Add(this.EditBox);
            this.Name = "AccountEditForm";
            this.Text = "Edycja konta";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AccountEditForm_FormClosed);
            this.EditBox.ResumeLayout(false);
            this.EditBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox EditBox;
        private System.Windows.Forms.CheckBox PermissionsCheckBox;
        private System.Windows.Forms.TextBox EmailText;
        private System.Windows.Forms.Label AccountWinsLabel;
        private System.Windows.Forms.Label AccountWeightLabel;
        private System.Windows.Forms.Label AccountHeightLabel;
        private System.Windows.Forms.Label AccountPhotoLabel;
        private System.Windows.Forms.Label AccountPasswordLabel;
        private System.Windows.Forms.Label AccountEmailLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.LinkLabel ImageChange;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox WinsText;
        private System.Windows.Forms.TextBox WeightText;
        private System.Windows.Forms.TextBox HeightText;
    }
}