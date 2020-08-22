namespace EventiApplication.WinUI.ProstoriOdrzavanja
{
    partial class frmProstorOdrzavanja
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
            this.dgvProstoriOdrzavanja = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIzbrisi = new System.Windows.Forms.Button();
            this.btnIzmjeni = new System.Windows.Forms.Button();
            this.lblPageNumbers = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtNazivPretraga = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPretraga = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProstoriOdrzavanja)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvProstoriOdrzavanja);
            this.groupBox1.Location = new System.Drawing.Point(11, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(835, 305);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prostori održavanja";
            // 
            // dgvProstoriOdrzavanja
            // 
            this.dgvProstoriOdrzavanja.AllowUserToAddRows = false;
            this.dgvProstoriOdrzavanja.AllowUserToDeleteRows = false;
            this.dgvProstoriOdrzavanja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProstoriOdrzavanja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Naziv,
            this.Adresa});
            this.dgvProstoriOdrzavanja.Location = new System.Drawing.Point(6, 25);
            this.dgvProstoriOdrzavanja.Name = "dgvProstoriOdrzavanja";
            this.dgvProstoriOdrzavanja.ReadOnly = true;
            this.dgvProstoriOdrzavanja.RowHeadersWidth = 62;
            this.dgvProstoriOdrzavanja.RowTemplate.Height = 28;
            this.dgvProstoriOdrzavanja.Size = new System.Drawing.Size(821, 274);
            this.dgvProstoriOdrzavanja.TabIndex = 0;
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
            // Adresa
            // 
            this.Adresa.DataPropertyName = "Adresa";
            this.Adresa.HeaderText = "Adresa";
            this.Adresa.MinimumWidth = 8;
            this.Adresa.Name = "Adresa";
            this.Adresa.ReadOnly = true;
            this.Adresa.Width = 150;
            // 
            // btnIzbrisi
            // 
            this.btnIzbrisi.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnIzbrisi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIzbrisi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIzbrisi.Location = new System.Drawing.Point(17, 91);
            this.btnIzbrisi.Name = "btnIzbrisi";
            this.btnIzbrisi.Size = new System.Drawing.Size(102, 38);
            this.btnIzbrisi.TabIndex = 1;
            this.btnIzbrisi.Text = "Ukloni";
            this.btnIzbrisi.UseVisualStyleBackColor = false;
            this.btnIzbrisi.Click += new System.EventHandler(this.btnIzbrisi_Click);
            // 
            // btnIzmjeni
            // 
            this.btnIzmjeni.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnIzmjeni.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIzmjeni.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIzmjeni.Location = new System.Drawing.Point(146, 91);
            this.btnIzmjeni.Name = "btnIzmjeni";
            this.btnIzmjeni.Size = new System.Drawing.Size(138, 38);
            this.btnIzmjeni.TabIndex = 2;
            this.btnIzmjeni.Text = "Detalji | Izmjena";
            this.btnIzmjeni.UseVisualStyleBackColor = false;
            this.btnIzmjeni.Click += new System.EventHandler(this.btnIzmjeni_Click);
            // 
            // lblPageNumbers
            // 
            this.lblPageNumbers.AutoSize = true;
            this.lblPageNumbers.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblPageNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageNumbers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPageNumbers.Location = new System.Drawing.Point(396, 471);
            this.lblPageNumbers.Name = "lblPageNumbers";
            this.lblPageNumbers.Size = new System.Drawing.Size(46, 22);
            this.lblPageNumbers.TabIndex = 26;
            this.lblPageNumbers.Text = "      ";
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPrevious.Enabled = false;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrevious.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrevious.Location = new System.Drawing.Point(261, 465);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(120, 36);
            this.btnPrevious.TabIndex = 25;
            this.btnPrevious.Text = "<<";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnNext.Enabled = false;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Location = new System.Drawing.Point(459, 465);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(120, 36);
            this.btnNext.TabIndex = 24;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtNazivPretraga
            // 
            this.txtNazivPretraga.Location = new System.Drawing.Point(80, 32);
            this.txtNazivPretraga.Name = "txtNazivPretraga";
            this.txtNazivPretraga.Size = new System.Drawing.Size(287, 26);
            this.txtNazivPretraga.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Naziv";
            // 
            // btnPretraga
            // 
            this.btnPretraga.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPretraga.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPretraga.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPretraga.Location = new System.Drawing.Point(387, 26);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(102, 38);
            this.btnPretraga.TabIndex = 29;
            this.btnPretraga.Text = "Traži";
            this.btnPretraga.UseVisualStyleBackColor = false;
            this.btnPretraga.Click += new System.EventHandler(this.btnPretraga_Click);
            // 
            // frmProstorOdrzavanja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 516);
            this.Controls.Add(this.btnPretraga);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNazivPretraga);
            this.Controls.Add(this.lblPageNumbers);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnIzmjeni);
            this.Controls.Add(this.btnIzbrisi);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmProstorOdrzavanja";
            this.Text = "Prostori održavanja";
            this.Load += new System.EventHandler(this.frmProstorOdrzavanja_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProstoriOdrzavanja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvProstoriOdrzavanja;
        private System.Windows.Forms.Button btnIzbrisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adresa;
        private System.Windows.Forms.Button btnIzmjeni;
        private System.Windows.Forms.Label lblPageNumbers;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtNazivPretraga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPretraga;
    }
}