namespace EventiApplication.WinUI.TipKarte
{
    partial class frmTipoviKarte
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
            this.lblNazivEventa = new System.Windows.Forms.Label();
            this.btnNoviTipKarte = new System.Windows.Forms.Button();
            this.btnIzbrisiTipKarte = new System.Windows.Forms.Button();
            this.dgvProdajaTip = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipKarte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CijenaTip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UkupnoKarataTip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojProdatihKarataTip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostojeSjedista = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIzmjeni = new System.Windows.Forms.Button();
            this.ckbBrProdKarata = new System.Windows.Forms.CheckBox();
            this.txtTipKarte = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPretraga = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdajaTip)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNazivEventa
            // 
            this.lblNazivEventa.AutoSize = true;
            this.lblNazivEventa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNazivEventa.Location = new System.Drawing.Point(12, 9);
            this.lblNazivEventa.Name = "lblNazivEventa";
            this.lblNazivEventa.Size = new System.Drawing.Size(62, 25);
            this.lblNazivEventa.TabIndex = 0;
            this.lblNazivEventa.Text = "Event";
            // 
            // btnNoviTipKarte
            // 
            this.btnNoviTipKarte.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnNoviTipKarte.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNoviTipKarte.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNoviTipKarte.Location = new System.Drawing.Point(12, 119);
            this.btnNoviTipKarte.Name = "btnNoviTipKarte";
            this.btnNoviTipKarte.Size = new System.Drawing.Size(140, 44);
            this.btnNoviTipKarte.TabIndex = 1;
            this.btnNoviTipKarte.Text = "Novi tip karte";
            this.btnNoviTipKarte.UseVisualStyleBackColor = false;
            this.btnNoviTipKarte.Click += new System.EventHandler(this.btnNoviTipKarte_Click);
            // 
            // btnIzbrisiTipKarte
            // 
            this.btnIzbrisiTipKarte.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnIzbrisiTipKarte.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIzbrisiTipKarte.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIzbrisiTipKarte.Location = new System.Drawing.Point(174, 119);
            this.btnIzbrisiTipKarte.Name = "btnIzbrisiTipKarte";
            this.btnIzbrisiTipKarte.Size = new System.Drawing.Size(152, 43);
            this.btnIzbrisiTipKarte.TabIndex = 2;
            this.btnIzbrisiTipKarte.Text = "Ukloni";
            this.btnIzbrisiTipKarte.UseVisualStyleBackColor = false;
            this.btnIzbrisiTipKarte.Click += new System.EventHandler(this.btnIzbrisiTipKarte_Click);
            // 
            // dgvProdajaTip
            // 
            this.dgvProdajaTip.AllowUserToAddRows = false;
            this.dgvProdajaTip.AllowUserToDeleteRows = false;
            this.dgvProdajaTip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdajaTip.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TipKarte,
            this.CijenaTip,
            this.UkupnoKarataTip,
            this.BrojProdatihKarataTip,
            this.PostojeSjedista});
            this.dgvProdajaTip.Location = new System.Drawing.Point(6, 25);
            this.dgvProdajaTip.Name = "dgvProdajaTip";
            this.dgvProdajaTip.ReadOnly = true;
            this.dgvProdajaTip.RowHeadersWidth = 62;
            this.dgvProdajaTip.RowTemplate.Height = 28;
            this.dgvProdajaTip.Size = new System.Drawing.Size(1011, 338);
            this.dgvProdajaTip.TabIndex = 3;
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
            // TipKarte
            // 
            this.TipKarte.DataPropertyName = "TipKarteNaziv";
            this.TipKarte.HeaderText = "Tip karte";
            this.TipKarte.MinimumWidth = 8;
            this.TipKarte.Name = "TipKarte";
            this.TipKarte.ReadOnly = true;
            this.TipKarte.Width = 150;
            // 
            // CijenaTip
            // 
            this.CijenaTip.DataPropertyName = "CijenaTip";
            this.CijenaTip.HeaderText = "Cijena (KM)";
            this.CijenaTip.MinimumWidth = 8;
            this.CijenaTip.Name = "CijenaTip";
            this.CijenaTip.ReadOnly = true;
            this.CijenaTip.Width = 150;
            // 
            // UkupnoKarataTip
            // 
            this.UkupnoKarataTip.DataPropertyName = "UkupnoKarataTip";
            this.UkupnoKarataTip.HeaderText = "Ukupno karata za prodaju";
            this.UkupnoKarataTip.MinimumWidth = 8;
            this.UkupnoKarataTip.Name = "UkupnoKarataTip";
            this.UkupnoKarataTip.ReadOnly = true;
            this.UkupnoKarataTip.Width = 150;
            // 
            // BrojProdatihKarataTip
            // 
            this.BrojProdatihKarataTip.DataPropertyName = "BrojProdatihKarataTip";
            this.BrojProdatihKarataTip.HeaderText = "Broj prodatih karata";
            this.BrojProdatihKarataTip.MinimumWidth = 8;
            this.BrojProdatihKarataTip.Name = "BrojProdatihKarataTip";
            this.BrojProdatihKarataTip.ReadOnly = true;
            this.BrojProdatihKarataTip.Width = 150;
            // 
            // PostojeSjedista
            // 
            this.PostojeSjedista.DataPropertyName = "PostojeSjedista";
            this.PostojeSjedista.HeaderText = "Postoje sjedista";
            this.PostojeSjedista.MinimumWidth = 8;
            this.PostojeSjedista.Name = "PostojeSjedista";
            this.PostojeSjedista.ReadOnly = true;
            this.PostojeSjedista.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvProdajaTip);
            this.groupBox1.Location = new System.Drawing.Point(2, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1023, 369);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipovi karata";
            // 
            // btnIzmjeni
            // 
            this.btnIzmjeni.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnIzmjeni.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIzmjeni.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIzmjeni.Location = new System.Drawing.Point(349, 119);
            this.btnIzmjeni.Name = "btnIzmjeni";
            this.btnIzmjeni.Size = new System.Drawing.Size(152, 43);
            this.btnIzmjeni.TabIndex = 5;
            this.btnIzmjeni.Text = "Izmjeni";
            this.btnIzmjeni.UseVisualStyleBackColor = false;
            this.btnIzmjeni.Click += new System.EventHandler(this.btnIzmjeni_Click);
            // 
            // ckbBrProdKarata
            // 
            this.ckbBrProdKarata.AutoSize = true;
            this.ckbBrProdKarata.Location = new System.Drawing.Point(349, 57);
            this.ckbBrProdKarata.Name = "ckbBrProdKarata";
            this.ckbBrProdKarata.Size = new System.Drawing.Size(200, 24);
            this.ckbBrProdKarata.TabIndex = 6;
            this.ckbBrProdKarata.Text = "Broj prodatih karata > 0";
            this.ckbBrProdKarata.UseVisualStyleBackColor = true;
            // 
            // txtTipKarte
            // 
            this.txtTipKarte.Location = new System.Drawing.Point(87, 55);
            this.txtTipKarte.Name = "txtTipKarte";
            this.txtTipKarte.Size = new System.Drawing.Size(237, 26);
            this.txtTipKarte.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "TipKarte";
            // 
            // btnPretraga
            // 
            this.btnPretraga.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPretraga.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPretraga.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPretraga.Location = new System.Drawing.Point(578, 46);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(140, 44);
            this.btnPretraga.TabIndex = 9;
            this.btnPretraga.Text = "Trazi";
            this.btnPretraga.UseVisualStyleBackColor = false;
            this.btnPretraga.Click += new System.EventHandler(this.btnPretraga_Click);
            // 
            // frmTipoviKarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 555);
            this.Controls.Add(this.btnPretraga);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTipKarte);
            this.Controls.Add(this.ckbBrProdKarata);
            this.Controls.Add(this.btnIzmjeni);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnIzbrisiTipKarte);
            this.Controls.Add(this.btnNoviTipKarte);
            this.Controls.Add(this.lblNazivEventa);
            this.Name = "frmTipoviKarte";
            this.Text = "Definisane prodaje karata ";
            this.Load += new System.EventHandler(this.frmTipoviKarte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdajaTip)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNazivEventa;
        private System.Windows.Forms.Button btnNoviTipKarte;
        private System.Windows.Forms.Button btnIzbrisiTipKarte;
        private System.Windows.Forms.DataGridView dgvProdajaTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnIzmjeni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipKarte;
        private System.Windows.Forms.DataGridViewTextBoxColumn CijenaTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn UkupnoKarataTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojProdatihKarataTip;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PostojeSjedista;
        private System.Windows.Forms.CheckBox ckbBrProdKarata;
        private System.Windows.Forms.TextBox txtTipKarte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPretraga;
    }
}