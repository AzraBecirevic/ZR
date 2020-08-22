using EventiApplication.Model;
using EventiApplication.Model.Request;
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

namespace EventiApplication.WinUI.Korisnici
{
    public partial class frmKorisnici : Form
    {
        private readonly APIService _korisniciService = new APIService("Korisnik");

        private IPagedList<Korisnik> pagedList;
        public int pageNumber = 1;

        public frmKorisnici()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
            dgvKorisnici.AutoGenerateColumns = false;
        }

        private void btnTrazi_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            BindContent(pageNumber);  //pageNumber
        }

        public async void BindContent(int pageNumber=1)
        {
            pagedList = await BindKorisnici(pageNumber);

            btnNext.Enabled = pagedList.HasNextPage;
            btnPrevious.Enabled = pagedList.HasPreviousPage;

            dgvKorisnici.DataSource = pagedList.ToList();

            lblPageNumbers.Text = string.Format("{0}/{1}", pageNumber, pagedList.PageCount);
        }
        private async Task<IPagedList<Korisnik>> BindKorisnici(int pageNumber =1, int pageSize =2)
        {
            KorisnikSearchRequest request = new KorisnikSearchRequest
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text 
            };

            var result = await _korisniciService.Get<List<Korisnik>>(request);

            return result.ToPagedList(pageNumber, pageSize);

        }

    private void btnDetalji_Click(object sender, EventArgs e)
        {
            if (dgvKorisnici.SelectedRows.Count > 0)
            {
                string id = dgvKorisnici.SelectedRows[0].Cells[0].Value.ToString();
                int korisnikId = int.Parse(id);
                frmKorisniciDetalji frm = new frmKorisniciDetalji(korisnikId, this);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            else
            {
                MessageBox.Show(Properties.Resources.selectRedKorisnika, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dgvKorisnici.SelectedRows.Count > 0)
            {
                string id = dgvKorisnici.SelectedRows[0].Cells[0].Value.ToString();
                int korisnikId = int.Parse(id);
                frmKorisniciIzvjestaj frm = new frmKorisniciIzvjestaj(korisnikId);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            else
            {
                MessageBox.Show(Properties.Resources.selectRedKorisnika, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
