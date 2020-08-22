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

namespace EventiApplication.WinUI.Organizatori
{
    public partial class frmOrganizatori : Form
    {
        private readonly APIService _service = new APIService("Organizator");

        private IPagedList<Organizator> pagedList;
        public int pageNumber = 1;

        public frmOrganizatori()
        {
            InitializeComponent();
            dgvOrganizatori.AutoGenerateColumns = false;
            this.AutoValidate = AutoValidate.Disable;
        }

        private  void btnTrazi_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            BindContent(pageNumber);  
        }

        public async void BindContent(int pageNumber = 1)
        {
            pagedList = await BindOrganizatori(pageNumber);

            btnNext.Enabled = pagedList.HasNextPage;
            btnPrevious.Enabled = pagedList.HasPreviousPage;

            dgvOrganizatori.DataSource = pagedList.ToList();

            lblPageNumbers.Text = string.Format("{0}/{1}", pageNumber, pagedList.PageCount);

        }

        private async Task<IPagedList<Organizator>> BindOrganizatori(int pageNumber=1, int pageSize=3)
        {
            OrganizatorSearchRequest request = new OrganizatorSearchRequest { Naziv = txtPretraga.Text };

            var result = await _service.Get<List<Organizator>>(request);

            return result.ToPagedList(pageNumber, pageSize);

        }

        private async void btnIzbrisi_Click(object sender, EventArgs e)
        {
            if (dgvOrganizatori.SelectedRows.Count > 0)
            {
                string id = dgvOrganizatori.SelectedRows[0].Cells[0].Value.ToString();
                int organizatorId = int.Parse(id);

                var result = await _service.Delete<Model.Organizator>(organizatorId);

                if (result != null)
                {
                    MessageBox.Show(Properties.Resources.UspjesnaAkcija, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Properties.Resources.nemBrisanjeOrg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                BindContent(pageNumber);
            }
            else
            {
                MessageBox.Show(Properties.Resources.selectRedOrganizatora, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnIzmijeni_Click(object sender, EventArgs e)
        {
            if (dgvOrganizatori.SelectedRows.Count > 0)
            {
                string id = dgvOrganizatori.SelectedRows[0].Cells[0].Value.ToString();
                int orgId = int.Parse(id);

                frmNoviOrganizator frm = new frmNoviOrganizator(this,orgId);
                frm.MdiParent = this.MdiParent;
                frm.Show();
               
            }
            else
            {
                MessageBox.Show(Properties.Resources.selectRedOrganizatora, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvOrganizatori.SelectedRows.Count > 0)
            {
                string id = dgvOrganizatori.SelectedRows[0].Cells[0].Value.ToString();
                int orgId = int.Parse(id);
                frmOrganizatorIzvjestaj frm = new frmOrganizatorIzvjestaj(orgId);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            else
            {
                MessageBox.Show(Properties.Resources.selectRedOrganizatora, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
