namespace EventiApplication.WinUI.TipKarte
{
    partial class frmNoviTipKarte
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
            this.txtCijena = new System.Windows.Forms.TextBox();
            this.cmbTipKarte = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ckbPostojeSjedista = new System.Windows.Forms.CheckBox();
            this.btnSnimi = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.nudUkupnoZaProdaju = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUkupnoZaProdaju)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tip";
            // 
            // txtCijena
            // 
            this.txtCijena.Location = new System.Drawing.Point(234, 100);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(289, 26);
            this.txtCijena.TabIndex = 1;
            this.txtCijena.Validating += new System.ComponentModel.CancelEventHandler(this.txtCijena_Validating);
            // 
            // cmbTipKarte
            // 
            this.cmbTipKarte.FormattingEnabled = true;
            this.cmbTipKarte.Location = new System.Drawing.Point(234, 46);
            this.cmbTipKarte.Name = "cmbTipKarte";
            this.cmbTipKarte.Size = new System.Drawing.Size(289, 28);
            this.cmbTipKarte.TabIndex = 2;
            this.cmbTipKarte.Validating += new System.ComponentModel.CancelEventHandler(this.cmbTipKarte_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cijena";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ukupno za prodaju";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Postoje sjedista";
            // 
            // ckbPostojeSjedista
            // 
            this.ckbPostojeSjedista.AutoSize = true;
            this.ckbPostojeSjedista.Location = new System.Drawing.Point(234, 204);
            this.ckbPostojeSjedista.Name = "ckbPostojeSjedista";
            this.ckbPostojeSjedista.Size = new System.Drawing.Size(56, 24);
            this.ckbPostojeSjedista.TabIndex = 7;
            this.ckbPostojeSjedista.Text = "Da";
            this.ckbPostojeSjedista.UseVisualStyleBackColor = true;
            // 
            // btnSnimi
            // 
            this.btnSnimi.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSnimi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSnimi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSnimi.Location = new System.Drawing.Point(375, 240);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(148, 40);
            this.btnSnimi.TabIndex = 8;
            this.btnSnimi.Text = "Snimi";
            this.btnSnimi.UseVisualStyleBackColor = false;
            this.btnSnimi.Click += new System.EventHandler(this.btnSnimi_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // nudUkupnoZaProdaju
            // 
            this.nudUkupnoZaProdaju.Location = new System.Drawing.Point(234, 146);
            this.nudUkupnoZaProdaju.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudUkupnoZaProdaju.Name = "nudUkupnoZaProdaju";
            this.nudUkupnoZaProdaju.Size = new System.Drawing.Size(289, 26);
            this.nudUkupnoZaProdaju.TabIndex = 9;
            this.nudUkupnoZaProdaju.Validating += new System.ComponentModel.CancelEventHandler(this.nudUkupnoZaProdaju_Validating);
            // 
            // frmNoviTipKarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 310);
            this.Controls.Add(this.nudUkupnoZaProdaju);
            this.Controls.Add(this.btnSnimi);
            this.Controls.Add(this.ckbPostojeSjedista);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTipKarte);
            this.Controls.Add(this.txtCijena);
            this.Controls.Add(this.label1);
            this.Name = "frmNoviTipKarte";
            this.Text = "Novi tip prodaje karte";
            this.Load += new System.EventHandler(this.frmNoviTipKarte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUkupnoZaProdaju)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCijena;
        private System.Windows.Forms.ComboBox cmbTipKarte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckbPostojeSjedista;
        private System.Windows.Forms.Button btnSnimi;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.NumericUpDown nudUkupnoZaProdaju;
    }
}