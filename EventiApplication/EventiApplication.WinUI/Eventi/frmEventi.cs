using EventiApplication.Model;
using EventiApplication.Model.Request;
using EventiApplication.WinUI.TipKarte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagedList;
using EventiApplication.WinUI.Izvjestaji;

namespace EventiApplication.WinUI.Eventi
{
    public partial class frmEventi : Form
    {
        private readonly APIService _eventiService = new APIService("Event");
        private readonly APIService _kategorijeService = new APIService("Kategorija");
        private readonly APIService _gradService = new APIService("Grad");

        public IPagedList<Event> pagedList;
        public int pageNumber = 1;   

        public frmEventi()
        {
            InitializeComponent();
            dgvEventi.AutoGenerateColumns = false;
        }

        private  void frmEventi_Load(object sender, EventArgs e)
        {
            BindKategorije();
            BindGradovi();
        }

        private async void BindGradovi()
        {
            var gradovi = await _gradService.Get<List<Grad>>(null);
            gradovi.Insert(0, new Grad { Naziv = "Odaberite grad", Id = 0, });

            cmbGrad.DataSource = gradovi;
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.ValueMember = "Id";
        }

        private async void BindKategorije()
        {
            var kategorije = await _kategorijeService.Get<List<Kategorija>>(null);
            kategorije.Insert(0, new Model.Kategorija { Id = 0, Naziv = "Odaberite kategoriju" });

            cmbKategorije.DataSource = kategorije;
            cmbKategorije.DisplayMember = "Naziv";
            cmbKategorije.ValueMember = "Id";
        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            BindContent(pageNumber);
        }

        public async void BindContent(int pageNumber = 1)
        {
            pagedList = await GetEventsAsync(pageNumber);
            btnNext.Enabled = pagedList.HasNextPage;
            btnPrevious.Enabled = pagedList.HasPreviousPage;

            dgvEventi.DataSource = pagedList.ToList();

            lblPageNumbers.Text = string.Format("{0}/{1}", pageNumber, pagedList.PageCount);
        }

        private async Task<IPagedList<Event>> GetEventsAsync(int pageNumber=1, int pageSize = 3)
        {
            EventSearchRequest request = new EventSearchRequest();
            if (!string.IsNullOrWhiteSpace(txtNazivEventa.Text))
                request.Naziv = txtNazivEventa.Text;
            if (cmbKategorije.SelectedIndex != 0)
                request.KategorijaId = (cmbKategorije.SelectedItem as Kategorija).Id;
            if (cmbGrad.SelectedIndex != 0)
                request.GradId = (cmbGrad.SelectedItem as Grad).Id;
            request.IsOdobren = ckbOdobreni.Checked;  
            request.IsOtkazan = ckbOtkazani.Checked;
            request.Predstojeci = ckbPredstojeci.Checked;

            var eventi = await _eventiService.Get<List<Event>>(request);

            return eventi.ToPagedList(pageNumber, pageSize);
        }

        private void btnTipoviKarata_Click(object sender, EventArgs e)
        {
            if (dgvEventi.SelectedRows.Count > 0)
            {
                string id = dgvEventi.SelectedRows[0].Cells[0].Value.ToString();
                int eventId = int.Parse(id);
                frmTipoviKarte frm = new frmTipoviKarte(eventId);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            else
            {
               
               MessageBox.Show(Properties.Resources.selectRedEventa, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            if (dgvEventi.SelectedRows.Count > 0)
            {
                string id = dgvEventi.SelectedRows[0].Cells[0].Value.ToString();
                int eventId = int.Parse(id);

                frmNoviEvent frm = new frmNoviEvent(this,eventId);
                frm.MdiParent = this.MdiParent;
                frm.Show();
                
            }
            else
            {
                MessageBox.Show(Properties.Resources.selectRedEventa, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvEventi_MouseDoubleClick(object sender, MouseEventArgs e)
        {  
            if (dgvEventi.SelectedRows.Count > 0)
            {
                string id = dgvEventi.SelectedRows[0].Cells[0].Value.ToString();
                int eventId = int.Parse(id);

                frmNoviEvent frm = new frmNoviEvent(this, eventId);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            else 
            {
                MessageBox.Show(Properties.Resources.selectRedEventa, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnIzbrisi_Click(object sender, EventArgs e)
        {
            if (dgvEventi.SelectedRows.Count > 0)
            {
                string id = dgvEventi.SelectedRows[0].Cells[0].Value.ToString();
                int eventId = int.Parse(id);

                var result = await _eventiService.Delete<Model.Event>(eventId);

                if (result != null)
                {
                    MessageBox.Show(Properties.Resources.UspjesnaAkcija, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Properties.Resources.nemBrisanjeEventa, "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                BindContent();
            }
            else
            {
                MessageBox.Show(Properties.Resources.selectRedEventa, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pagedList.HasNextPage)
            {
                BindContent(++pageNumber);
            }
        }

        private  void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pagedList.HasPreviousPage)
            {
                int pgNum = --pageNumber;
                if (pgNum <= 0)
                    pgNum = 1;
                BindContent(pgNum);
            }
        }

        private void btnIzvjestaj_Click(object sender, EventArgs e)
        {
            if (dgvEventi.SelectedRows.Count > 0)
            {
                string id = dgvEventi.SelectedRows[0].Cells[0].Value.ToString();
                int eventId = int.Parse(id);

                frmEventIzvjestaj frm = new frmEventIzvjestaj(eventId);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            else
            {
                MessageBox.Show(Properties.Resources.selectRedEventa, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}

