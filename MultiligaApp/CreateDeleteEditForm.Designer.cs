using System.Collections.Generic;

namespace MultiligaApp
{
    partial class CreateDeleteEditForm
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

        public void SetCreateForm(string groupBox, string label1, string label2, string label3, string label4, string label5, string label6, string label7)
        {
            this.groupBox1.Text = groupBox;
            this.label1.Text = label1;
            this.label2.Text = label2;
            this.label3.Text = label3;
            this.label4.Text = label4;
            this.label5.Text = label5;
            this.label6.Text = label6;
            this.label7.Text = label7;

            if (label1 == "")
            {
                this.label1.Visible = false;
                this.comboBox1.Visible = false;
            }
            if (label2 == "")
            {
                this.label2.Visible = false;
                this.numberOfRaces.Visible = false;
            }
            if (label3 == "")
            {
                this.label3.Visible = false;
                this.textBox3.Visible = false;
            }
            if (label4 == "")
            {
                this.label4.Visible = false;
                this.comboBox4.Visible = false;
            }
            if (label5 == "")
            {
                this.label5.Visible = false;
                this.textBox5.Visible = false;
            }
            if (label6 == "")
            {
                this.label6.Visible = false;
                this.textBox6.Visible = false;
            }
            if (label7 == "")
            {
                this.label7.Visible = false;
                this.comboBox7.Visible = false;
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numberOfRaces = new System.Windows.Forms.NumericUpDown();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.pracownikBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.multiligaDataSet1 = new MultiligaApp.multiligaDataSet1();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dyscyplinaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.multiligaDataSet = new MultiligaApp.multiligaDataSet();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.dyscyplinaTableAdapter = new MultiligaApp.multiligaDataSetTableAdapters.dyscyplinaTableAdapter();
            this.pracownikTableAdapter = new MultiligaApp.multiligaDataSet1TableAdapters.pracownikTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfRaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownikBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiligaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dyscyplinaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiligaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numberOfRaces);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.comboBox7);
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CancelButton);
            this.groupBox1.Controls.Add(this.SaveButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(284, 373);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // numberOfRaces
            // 
            this.numberOfRaces.Location = new System.Drawing.Point(132, 60);
            this.numberOfRaces.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfRaces.Name = "numberOfRaces";
            this.numberOfRaces.Size = new System.Drawing.Size(132, 22);
            this.numberOfRaces.TabIndex = 48;
            this.numberOfRaces.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(12, 223);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(252, 22);
            this.textBox6.TabIndex = 47;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(132, 155);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(132, 22);
            this.textBox5.TabIndex = 46;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(132, 90);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(132, 22);
            this.textBox3.TabIndex = 45;
            // 
            // comboBox7
            // 
            this.comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Items.AddRange(new object[] {
            "kwalifikacje",
            "zapisy otwarte"});
            this.comboBox7.Location = new System.Drawing.Point(133, 252);
            this.comboBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(132, 24);
            this.comboBox7.TabIndex = 44;
            this.comboBox7.SelectedIndex = 1;
            // 
            // comboBox4
            // 
            this.comboBox4.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.pracownikBindingSource, "id_pracownik", true));
            this.comboBox4.DataSource = this.pracownikBindingSource;
            this.comboBox4.DisplayMember = "nazwisko";
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(132, 122);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(132, 24);
            this.comboBox4.TabIndex = 41;
            this.comboBox4.ValueMember = "id_pracownik";
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.ComboBox4_SelectedIndexChanged);
            // 
            // pracownikBindingSource
            // 
            this.pracownikBindingSource.DataMember = "pracownik";
            this.pracownikBindingSource.DataSource = this.multiligaDataSet1;
            this.pracownikBindingSource.Filter = "stanowisko = \'opiekun\'";
            // 
            // multiligaDataSet1
            // 
            this.multiligaDataSet1.DataSetName = "multiligaDataSet1";
            this.multiligaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dyscyplinaBindingSource, "id_dyscyplina", true));
            this.comboBox1.DataSource = this.dyscyplinaBindingSource;
            this.comboBox1.DisplayMember = "nazwa";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(132, 32);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(132, 24);
            this.comboBox1.TabIndex = 38;
            this.comboBox1.ValueMember = "id_dyscyplina";
            // 
            // dyscyplinaBindingSource
            // 
            this.dyscyplinaBindingSource.DataMember = "dyscyplina";
            this.dyscyplinaBindingSource.DataSource = this.multiligaDataSet;
            // 
            // multiligaDataSet
            // 
            this.multiligaDataSet.DataSetName = "multiligaDataSet";
            this.multiligaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 37;
            this.label7.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 182);
            this.label6.MaximumSize = new System.Drawing.Size(267, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 36;
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 35;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 34;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "label1";
            // 
            // CancelButton
            // 
            this.CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelButton.Location = new System.Drawing.Point(12, 327);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(253, 39);
            this.CancelButton.TabIndex = 30;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.Location = new System.Drawing.Point(12, 283);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(253, 39);
            this.SaveButton.TabIndex = 29;
            this.SaveButton.Text = "Zatwierdź";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // dyscyplinaTableAdapter
            // 
            this.dyscyplinaTableAdapter.ClearBeforeFill = true;
            // 
            // pracownikTableAdapter
            // 
            this.pracownikTableAdapter.ClearBeforeFill = true;
            // 
            // CreateDeleteEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 400);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CreateDeleteEditForm";
            this.Load += new System.EventHandler(this.CreateDeleteEditForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfRaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownikBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiligaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dyscyplinaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiligaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private multiligaDataSet multiligaDataSet;
        private System.Windows.Forms.BindingSource dyscyplinaBindingSource;
        private multiligaDataSetTableAdapters.dyscyplinaTableAdapter dyscyplinaTableAdapter;
        private multiligaDataSet1 multiligaDataSet1;
        private System.Windows.Forms.BindingSource pracownikBindingSource;
        private multiligaDataSet1TableAdapters.pracownikTableAdapter pracownikTableAdapter;
        private System.Windows.Forms.NumericUpDown numberOfRaces;
    }
}