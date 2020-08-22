namespace EventiApplication.WinUI.Eventi
{
    partial class frmNoviEvent
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtVrijeme = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProstorOdrzavanja = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDatumOdrzavanja = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbKategorije = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbOrganizator = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSlika = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDodajSliku = new System.Windows.Forms.Button();
            this.btnSnimiEvent = new System.Windows.Forms.Button();
            this.txtOpis = new System.Windows.Forms.RichTextBox();
            this.ckbOdobren = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ckbOtkazan = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(189, 29);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(332, 26);
            this.txtNaziv.TabIndex = 1;
            this.txtNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.txtNaziv_Validating);
            // 
            // txtVrijeme
            // 
            this.txtVrijeme.Location = new System.Drawing.Point(189, 176);
            this.txtVrijeme.Name = "txtVrijeme";
            this.txtVrijeme.Size = new System.Drawing.Size(332, 26);
            this.txtVrijeme.TabIndex = 3;
            this.txtVrijeme.Validating += new System.ComponentModel.CancelEventHandler(this.txtVrijeme_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prostor održavanja";
            // 
            // cmbProstorOdrzavanja
            // 
            this.cmbProstorOdrzavanja.FormattingEnabled = true;
            this.cmbProstorOdrzavanja.Location = new System.Drawing.Point(189, 78);
            this.cmbProstorOdrzavanja.Name = "cmbProstorOdrzavanja";
            this.cmbProstorOdrzavanja.Size = new System.Drawing.Size(332, 28);
            this.cmbProstorOdrzavanja.TabIndex = 4;
            this.cmbProstorOdrzavanja.Validating += new System.ComponentModel.CancelEventHandler(this.cmbProstorOdrzavanja_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Datum održavanja";
            // 
            // dtpDatumOdrzavanja
            // 
            this.dtpDatumOdrzavanja.Location = new System.Drawing.Point(189, 126);
            this.dtpDatumOdrzavanja.Name = "dtpDatumOdrzavanja";
            this.dtpDatumOdrzavanja.Size = new System.Drawing.Size(332, 26);
            this.dtpDatumOdrzavanja.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Vrijeme";
            // 
            // cmbKategorije
            // 
            this.cmbKategorije.FormattingEnabled = true;
            this.cmbKategorije.Location = new System.Drawing.Point(189, 222);
            this.cmbKategorije.Name = "cmbKategorije";
            this.cmbKategorije.Size = new System.Drawing.Size(332, 28);
            this.cmbKategorije.TabIndex = 9;
            this.cmbKategorije.Validating += new System.ComponentModel.CancelEventHandler(this.cmbKategorije_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kategorija";
            // 
            // cmbOrganizator
            // 
            this.cmbOrganizator.FormattingEnabled = true;
            this.cmbOrganizator.Location = new System.Drawing.Point(189, 267);
            this.cmbOrganizator.Name = "cmbOrganizator";
            this.cmbOrganizator.Size = new System.Drawing.Size(332, 28);
            this.cmbOrganizator.TabIndex = 11;
            this.cmbOrganizator.Validating += new System.ComponentModel.CancelEventHandler(this.cmbOrganizator_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Organizator";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 324);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Opis";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 446);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Slika";
            // 
            // txtSlika
            // 
            this.txtSlika.Location = new System.Drawing.Point(189, 443);
            this.txtSlika.Name = "txtSlika";
            this.txtSlika.Size = new System.Drawing.Size(243, 26);
            this.txtSlika.TabIndex = 14;
            this.txtSlika.Validating += new System.ComponentModel.CancelEventHandler(this.txtSlika_Validating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(583, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 245);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // btnDodajSliku
            // 
            this.btnDodajSliku.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDodajSliku.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDodajSliku.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDodajSliku.Location = new System.Drawing.Point(446, 437);
            this.btnDodajSliku.Name = "btnDodajSliku";
            this.btnDodajSliku.Size = new System.Drawing.Size(75, 39);
            this.btnDodajSliku.TabIndex = 17;
            this.btnDodajSliku.Text = "Izaberi";
            this.btnDodajSliku.UseVisualStyleBackColor = false;
            this.btnDodajSliku.Click += new System.EventHandler(this.btnDodajSliku_Click);
            // 
            // btnSnimiEvent
            // 
            this.btnSnimiEvent.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSnimiEvent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSnimiEvent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSnimiEvent.Location = new System.Drawing.Point(671, 392);
            this.btnSnimiEvent.Name = "btnSnimiEvent";
            this.btnSnimiEvent.Size = new System.Drawing.Size(148, 46);
            this.btnSnimiEvent.TabIndex = 18;
            this.btnSnimiEvent.Text = "Snimi";
            this.btnSnimiEvent.UseVisualStyleBackColor = false;
            this.btnSnimiEvent.Click += new System.EventHandler(this.btnSnimiEvent_Click);
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(189, 311);
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(332, 112);
            this.txtOpis.TabIndex = 19;
            this.txtOpis.Text = "";
            // 
            // ckbOdobren
            // 
            this.ckbOdobren.AutoSize = true;
            this.ckbOdobren.Location = new System.Drawing.Point(189, 486);
            this.ckbOdobren.Name = "ckbOdobren";
            this.ckbOdobren.Size = new System.Drawing.Size(97, 24);
            this.ckbOdobren.TabIndex = 20;
            this.ckbOdobren.Text = "Odobren";
            this.ckbOdobren.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ckbOtkazan
            // 
            this.ckbOtkazan.AutoSize = true;
            this.ckbOtkazan.Location = new System.Drawing.Point(325, 486);
            this.ckbOtkazan.Name = "ckbOtkazan";
            this.ckbOtkazan.Size = new System.Drawing.Size(95, 24);
            this.ckbOtkazan.TabIndex = 21;
            this.ckbOtkazan.Text = "Otkazan";
            this.ckbOtkazan.UseVisualStyleBackColor = true;
            this.ckbOtkazan.Visible = false;
            // 
            // frmNoviEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 541);
            this.Controls.Add(this.ckbOtkazan);
            this.Controls.Add(this.ckbOdobren);
            this.Controls.Add(this.txtOpis);
            this.Controls.Add(this.btnSnimiEvent);
            this.Controls.Add(this.btnDodajSliku);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSlika);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbOrganizator);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbKategorije);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDatumOdrzavanja);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbProstorOdrzavanja);
            this.Controls.Add(this.txtVrijeme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.label1);
            this.Name = "frmNoviEvent";
            this.Text = "Event";
            this.Load += new System.EventHandler(this.frmNoviEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.TextBox txtVrijeme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProstorOdrzavanja;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDatumOdrzavanja;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbKategorije;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbOrganizator;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSlika;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDodajSliku;
        private System.Windows.Forms.Button btnSnimiEvent;
        private System.Windows.Forms.RichTextBox txtOpis;
        private System.Windows.Forms.CheckBox ckbOdobren;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox ckbOtkazan;
    }
}