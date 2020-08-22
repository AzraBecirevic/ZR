using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EventiApplication.Model.Request;
using PagedList;

namespace EventiApplication.WinUI.ProstoriOdrzavanja
{
    public partial class frmProstorOdrzavanja : Form
    {
        private readonly APIService _prostorOdrzavanjaService = new APIService("ProstorOdrzavanja");

        private IPagedList<Model.ProstorOdrzavanja> pagedList;
        public int pageNumber = 1;
     
        public frmProstorOdrzavanja()
        {
            InitializeComponent();
            dgvProstoriOdrzavanja.AutoGenerateColumns = false;
        }

        private void frmProstorOdrzavanja_Load(object sender, EventArgs e)
        {
           // pageNumber = 1;
            //BindContent(pageNumber);
          
        }
        
        public async void BindContent(int pageNumber=1)
        {
            pagedList = await BindProstoriOdrzavanja(pageNumber);

            btnNext.Enabled = pagedList.HasNextPage;
            btnPrevious.Enabled = pagedList.HasPreviousPage;

            dgvProstoriOdrzavanja.DataSource = pagedList.ToList();

            lblPageNumbers.Text = string.Format("{0}/{1}", pageNumber, pagedList.Count);
        }

        private async Task<IPagedList<Model.ProstorOdrzavanja>> BindProstoriOdrzavanja(int pageNumber=1 , int pageSize=2)
        {
            
            ProstorOdrzavanjaSearchRequest request = new ProstorOdrzavanjaSearchRequest { Naziv = txtNazivPretraga.Text };
            var prostoriOdrzavanja = await _prostorOdrzavanjaService.Get<List<Model.ProstorOdrzavanja>>(request);

            return prostoriOdrzavanja.ToPagedList(pageNumber, pageSize);
           
        }

        private async void btnIzbrisi_Click(object sender, EventArgs e)
        {
            if (dgvProstoriOdrzavanja.SelectedRows.Count > 0)
            {
                string id = dgvProstoriOdrzavanja.SelectedRows[0].Cells[0].Value.ToString();
                int prostorOdrId = int.Parse(id);

                var result = await _prostorOdrzavanjaService.Delete<Model.ProstorOdrzavanja>(prostorOdrId);

                if (result != null)
                {
                    MessageBox.Show(Properties.Resources.UspjesnaAkcija, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindContent(pageNumber);
                }
                else
                    MessageBox.Show(Properties.Resources.nemBrisanjeProstoraOdr, "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                BindContent(pageNumber);
            }
            else
            {
                MessageBox.Show(Properties.Resources.selectRedProstoraOdrzavanja, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        
        private void btnIzmjeni_Click(object sender, EventArgs e)
        {
            if (dgvProstoriOdrzavanja.SelectedRows.Count > 0)
            {
                string id = dgvProstoriOdrzavanja.SelectedRows[0].Cells[0].Value.ToString();
                int idProstora = int.Parse(id);
                frmNoviProstorOdrzavanja frm = new frmNoviProstorOdrzavanja(this, idProstora);
                frm.MdiParent = this.MdiParent;
                frm.Show();
                //if (frm.ShowDialog() == DialogResult.Cancel)
                //    BindContent(pageNumber);
            }
            else
            {
                MessageBox.Show(Properties.Resources.selectRedProstoraOdrzavanja, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pagedList.HasNextPage)
            {
                BindContent(++pageNumber);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pagedList.HasPreviousPage)
            {
                int pgNum = --pageNumber;
                if (pgNum <= 0)
                    pgNum = 1;
                BindContent(pgNum);
            }
        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            BindContent(pageNumber);
        }
    }
}
