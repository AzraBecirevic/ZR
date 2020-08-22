namespace EventiApplication.WinUI.TipoviKarata
{
    partial class frmTipoviKarata
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
            this.dgvTipoviKarata = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIzbrisi = new System.Windows.Forms.Button();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoviKarata)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTipoviKarata);
            this.groupBox1.Location = new System.Drawing.Point(3, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 353);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipovi karata";
            // 
            // dgvTipoviKarata
            // 
            this.dgvTipoviKarata.AllowUserToAddRows = false;
            this.dgvTipoviKarata.AllowUserToDeleteRows = false;
            this.dgvTipoviKarata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipoviKarata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Naziv});
            this.dgvTipoviKarata.Location = new System.Drawing.Point(9, 35);
            this.dgvTipoviKarata.Name = "dgvTipoviKarata";
            this.dgvTipoviKarata.ReadOnly = true;
            this.dgvTipoviKarata.RowHeadersWidth = 62;
            this.dgvTipoviKarata.RowTemplate.Height = 28;
            this.dgvTipoviKarata.Size = new System.Drawing.Size(779, 308);
            this.dgvTipoviKarata.TabIndex = 0;
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
            // btnIzbrisi
            // 
            this.btnIzbrisi.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnIzbrisi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIzbrisi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIzbrisi.Location = new System.Drawing.Point(126, 27);
            this.btnIzbrisi.Name = "btnIzbrisi";
            this.btnIzbrisi.Size = new System.Drawing.Size(90, 37);
            this.btnIzbrisi.TabIndex = 1;
            this.btnIzbrisi.Text = "Izbrisi";
            this.btnIzbrisi.UseVisualStyleBackColor = false;
            this.btnIzbrisi.Click += new System.EventHandler(this.btnIzbrisi_Click);
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPrikazi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrikazi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrikazi.Location = new System.Drawing.Point(12, 27);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(90, 37);
            this.btnPrikazi.TabIndex = 2;
            this.btnPrikazi.Text = "Prikazi";
            this.btnPrikazi.UseVisualStyleBackColor = false;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // frmTipoviKarata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.btnIzbrisi);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTipoviKarata";
            this.Text = "frmTipoviKarata";
            this.Load += new System.EventHandler(this.frmTipoviKarata_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoviKarata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTipoviKarata;
        private System.Windows.Forms.Button btnIzbrisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.Button btnPrikazi;
    }
}