namespace EventiApplication.WinUI.Eventi
{
    partial class frmEventi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvEventi = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kategorija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumOdrzavanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProstorOdrzavanjaGradAdresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNazivEventa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKategorije = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbOdobreni = new System.Windows.Forms.CheckBox();
            this.ckbOtkazani = new System.Windows.Forms.CheckBox();
            this.ckbPredstojeci = new System.Windows.Forms.CheckBox();
            this.btnPretraga = new System.Windows.Forms.Button();
            this.btnTipoviKarata = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDetalji = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGrad = new System.Windows.Forms.ComboBox();
            this.btnIzbrisi = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblPageNumbers = new System.Windows.Forms.Label();
            this.btnIzvjestaj = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvEventi);
            this.groupBox1.Location = new System.Drawing.Point(7, 225);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1015, 325);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eventi";
            // 
            // dgvEventi
            // 
            this.dgvEventi.AllowUserToAddRows = false;
            this.dgvEventi.AllowUserToDeleteRows = false;
            this.dgvEventi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Naziv,
            this.Kategorija,
            this.DatumOdrzavanja,
            this.ProstorOdrzavanjaGradAdresa});
            this.dgvEventi.Location = new System.Drawing.Point(5, 25);
            this.dgvEventi.Name = "dgvEventi";
            this.dgvEventi.ReadOnly = true;
            this.dgvEventi.RowHeadersWidth = 62;
            this.dgvEventi.RowTemplate.Height = 28;
            this.dgvEventi.Size = new System.Drawing.Size(1000, 300);
            this.dgvEventi.TabIndex = 0;
            this.dgvEventi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvEventi_MouseDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 150;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.MinimumWidth = 8;
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            this.Naziv.Width = 150;
            // 
            // Kategorija
            // 
            this.Kategorija.DataPropertyName = "KategorijaNaziv";
            this.Kategorija.HeaderText = "Kategorija";
            this.Kategorija.MinimumWidth = 8;
            this.Kategorija.Name = "Kategorija";
            this.Kategorija.ReadOnly = true;
            this.Kategorija.Width = 150;
            // 
            // DatumOdrzavanja
            // 
            this.DatumOdrzavanja.DataPropertyName = "DatumOdrzavanja";
            this.DatumOdrzavanja.HeaderText = "Datum održavanja";
            this.DatumOdrzavanja.MinimumWidth = 8;
            this.DatumOdrzavanja.Name = "DatumOdrzavanja";
            this.DatumOdrzavanja.ReadOnly = true;
            this.DatumOdrzavanja.Width = 150;
            // 
            // ProstorOdrzavanjaGradAdresa
            // 
            this.ProstorOdrzavanjaGradAdresa.DataPropertyName = "ProstorOdrzavanjaGradAdresa";
            this.ProstorOdrzavanjaGradAdresa.HeaderText = "Mjesto održavanja";
            this.ProstorOdrzavanjaGradAdresa.MinimumWidth = 8;
            this.ProstorOdrzavanjaGradAdresa.Name = "ProstorOdrzavanjaGradAdresa";
            this.ProstorOdrzavanjaGradAdresa.ReadOnly = true;
            this.ProstorOdrzavanjaGradAdresa.Width = 150;
            // 
            // txtNazivEventa
            // 
            this.txtNazivEventa.Location = new System.Drawing.Point(117, 29);
            this.txtNazivEventa.Name = "txtNazivEventa";
            this.txtNazivEventa.Size = new System.Drawing.Size(287, 26);
            this.txtNazivEventa.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Naziv eventa";
            // 
            // cmbKategorije
            // 
            this.cmbKategorije.FormattingEnabled = true;
            this.cmbKategorije.Location = new System.Drawing.Point(117, 65);
            this.cmbKategorije.Name = "cmbKategorije";
            this.cmbKategorije.Size = new System.Drawing.Size(287, 28);
            this.cmbKategorije.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kategorija";
            // 
            // ckbOdobreni
            // 
            this.ckbOdobreni.AutoSize = true;
            this.ckbOdobreni.Location = new System.Drawing.Point(483, 31);
            this.ckbOdobreni.Name = "ckbOdobreni";
            this.ckbOdobreni.Size = new System.Drawing.Size(100, 24);
            this.ckbOdobreni.TabIndex = 5;
            this.ckbOdobreni.Text = "Odobreni";
            this.ckbOdobreni.UseVisualStyleBackColor = true;
            // 
            // ckbOtkazani
            // 
            this.ckbOtkazani.AutoSize = true;
            this.ckbOtkazani.Location = new System.Drawing.Point(483, 69);
            this.ckbOtkazani.Name = "ckbOtkazani";
            this.ckbOtkazani.Size = new System.Drawing.Size(98, 24);
            this.ckbOtkazani.TabIndex = 6;
            this.ckbOtkazani.Text = "Otkazani";
            this.ckbOtkazani.UseVisualStyleBackColor = true;
            // 
            // ckbPredstojeci
            // 
            this.ckbPredstojeci.AutoSize = true;
            this.ckbPredstojeci.Location = new System.Drawing.Point(483, 106);
            this.ckbPredstojeci.Name = "ckbPredstojeci";
            this.ckbPredstojeci.Size = new System.Drawing.Size(270, 24);
            this.ckbPredstojeci.TabIndex = 7;
            this.ckbPredstojeci.Text = "Predstojeći (*najavljeni i odobreni)";
            this.ckbPredstojeci.UseVisualStyleBackColor = true;
            // 
            // btnPretraga
            // 
            this.btnPretraga.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPretraga.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPretraga.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPretraga.Location = new System.Drawing.Point(892, 84);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(87, 46);
            this.btnPretraga.TabIndex = 8;
            this.btnPretraga.Text = "Traži";
            this.btnPretraga.UseVisualStyleBackColor = false;
            this.btnPretraga.Click += new System.EventHandler(this.btnPretraga_Click);
            // 
            // btnTipoviKarata
            // 
            this.btnTipoviKarata.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnTipoviKarata.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTipoviKarata.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTipoviKarata.Location = new System.Drawing.Point(12, 159);
            this.btnTipoviKarata.Name = "btnTipoviKarata";
            this.btnTipoviKarata.Size = new System.Drawing.Size(177, 36);
            this.btnTipoviKarata.TabIndex = 9;
            this.btnTipoviKarata.Text = "Tipovi karata";
            this.btnTipoviKarata.UseVisualStyleBackColor = false;
            this.btnTipoviKarata.Click += new System.EventHandler(this.btnTipoviKarata_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(394, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "*Dupli klik na event za pregled detalja ili izmjenu eventa";
            // 
            // btnDetalji
            // 
            this.btnDetalji.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDetalji.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetalji.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDetalji.Location = new System.Drawing.Point(209, 159);
            this.btnDetalji.Name = "btnDetalji";
            this.btnDetalji.Size = new System.Drawing.Size(175, 36);
            this.btnDetalji.TabIndex = 11;
            this.btnDetalji.Text = "Detaljnije";
            this.btnDetalji.UseVisualStyleBackColor = false;
            this.btnDetalji.Click += new System.EventHandler(this.btnDetalji_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Grad";
            // 
            // cmbGrad
            // 
            this.cmbGrad.FormattingEnabled = true;
            this.cmbGrad.Location = new System.Drawing.Point(117, 102);
            this.cmbGrad.Name = "cmbGrad";
            this.cmbGrad.Size = new System.Drawing.Size(287, 28);
            this.cmbGrad.TabIndex = 12;
            // 
            // btnIzbrisi
            // 
            this.btnIzbrisi.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnIzbrisi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIzbrisi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIzbrisi.Location = new System.Drawing.Point(406, 159);
            this.btnIzbrisi.Name = "btnIzbrisi";
            this.btnIzbrisi.Size = new System.Drawing.Size(175, 36);
            this.btnIzbrisi.TabIndex = 14;
            this.btnIzbrisi.Text = "Izbriši";
            this.btnIzbrisi.UseVisualStyleBackColor = false;
            this.btnIzbrisi.Click += new System.EventHandler(this.btnIzbrisi_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnNext.Enabled = false;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Location = new System.Drawing.Point(551, 556);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(120, 36);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPrevious.Enabled = false;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrevious.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrevious.Location = new System.Drawing.Point(353, 556);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(120, 36);
            this.btnPrevious.TabIndex = 16;
            this.btnPrevious.Text = "<<";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblPageNumbers
            // 
            this.lblPageNumbers.AutoSize = true;
            this.lblPageNumbers.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblPageNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageNumbers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPageNumbers.Location = new System.Drawing.Point(488, 562);
            this.lblPageNumbers.Name = "lblPageNumbers";
            this.lblPageNumbers.Size = new System.Drawing.Size(46, 22);
            this.lblPageNumbers.TabIndex = 17;
            this.lblPageNumbers.Text = "      ";
            // 
            // btnIzvjestaj
            // 
            this.btnIzvjestaj.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnIzvjestaj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIzvjestaj.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIzvjestaj.Location = new System.Drawing.Point(599, 159);
            this.btnIzvjestaj.Name = "btnIzvjestaj";
            this.btnIzvjestaj.Size = new System.Drawing.Size(175, 36);
            this.btnIzvjestaj.TabIndex = 18;
            this.btnIzvjestaj.Text = "Izvještaj";
            this.btnIzvjestaj.UseVisualStyleBackColor = false;
            this.btnIzvjestaj.Click += new System.EventHandler(this.btnIzvjestaj_Click);
            // 
            // frmEventi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 604);
            this.Controls.Add(this.btnIzvjestaj);
            this.Controls.Add(this.lblPageNumbers);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnIzbrisi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbGrad);
            this.Controls.Add(this.btnDetalji);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTipoviKarata);
            this.Controls.Add(this.btnPretraga);
            this.Controls.Add(this.ckbPredstojeci);
            this.Controls.Add(this.ckbOtkazani);
            this.Controls.Add(this.ckbOdobreni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbKategorije);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNazivEventa);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEventi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eventi";
            this.Load += new System.EventHandler(this.frmEventi_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNazivEventa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKategorije;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbOdobreni;
        private System.Windows.Forms.CheckBox ckbOtkazani;
        private System.Windows.Forms.CheckBox ckbPredstojeci;
        private System.Windows.Forms.DataGridView dgvEventi;
        private System.Windows.Forms.Button btnPretraga;
        private System.Windows.Forms.Button btnTipoviKarata;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kategorija;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumOdrzavanja;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProstorOdrzavanjaGradAdresa;
        private System.Windows.Forms.Button btnDetalji;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbGrad;
        private System.Windows.Forms.Button btnIzbrisi;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblPageNumbers;
        private System.Windows.Forms.Button btnIzvjestaj;
    }
}