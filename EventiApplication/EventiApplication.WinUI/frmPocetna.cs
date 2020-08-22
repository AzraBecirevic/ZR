using EventiApplication.WinUI.Administratori;
using EventiApplication.WinUI.Eventi;
using EventiApplication.WinUI.Korisnici;
using EventiApplication.WinUI.Organizatori;
using EventiApplication.WinUI.ProstoriOdrzavanja;
using EventiApplication.WinUI.TipoviKarata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventiApplication.WinUI
{
    public partial class frmPocetna : Form
    {
        private int childFormNumber = 0;

        public frmPocetna()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEventi frm = new frmEventi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void noviEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNoviEvent frm = new frmNoviEvent(null, 0);  
            frm.MdiParent = this;
            frm.Show();
        }

        private void pretragaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProstorOdrzavanja frm = new frmProstorOdrzavanja();
            frm.MdiParent = this;
            frm.Show();
        }

        private void noviProstorOdržavanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNoviProstorOdrzavanja frm = new frmNoviProstorOdrzavanja(null,0);
            frm.MdiParent = this;
            frm.Show();
        }

        private void pretragaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmOrganizatori frm = new frmOrganizatori();
            frm.MdiParent = this;
            frm.Show();
        }

        private void noviOrganizatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNoviOrganizator frm = new frmNoviOrganizator(null);
            frm.MdiParent = this;
            frm.Show();
        }

        private void pretragaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmKorisnici frm = new frmKorisnici();
            frm.MdiParent = this;
            frm.Show();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdministrator frm = new FrmAdministrator();
            frm.MdiParent = this;
            frm.Show();
        }

        private void noviAdministratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNoviAdministrator frm = new frmNoviAdministrator();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pretragaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FrmAdministratori frm = new FrmAdministratori();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pretragaToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmTipoviKarata frm = new frmTipoviKarata();
            frm.MdiParent = this;
            frm.Show();
        }

        private void noviTipKarteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNoviTipKarte frm = new frmNoviTipKarte();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
