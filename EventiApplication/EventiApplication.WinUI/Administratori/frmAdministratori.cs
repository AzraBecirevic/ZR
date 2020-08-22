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

namespace EventiApplication.WinUI.Administratori
{
    public partial class FrmAdministratori : Form
    {
        private readonly APIService _administratorService = new APIService("Administrator");
       

        AdministratorSearchRequest request = null;

        private IPagedList<Administrator> pagedList;
        int pageNumber = 1;
        int pageSize = 1;

        public FrmAdministratori()
        {
            InitializeComponent();
            dgvAdministratori.AutoGenerateColumns = false;
        }

        private void btnTrazi_Click(object sender, EventArgs e)
        {
            request = new AdministratorSearchRequest { Username = txtUsername.Text };
            pageNumber = 1;
            BindContent(pageNumber, request);
        }

        private async void BindContent(int pageNumber, AdministratorSearchRequest request)
        {
            pagedList = await BindAdministratori(request, pageNumber, pageSize);

            btnNext.Enabled = pagedList.HasNextPage;
            btnPrevious.Enabled = pagedList.HasPreviousPage;

            dgvAdministratori.DataSource = pagedList.ToList();

            lblPageNumbers.Text = string.Format("{0}/{1}", pageNumber, pagedList.PageCount);
        }
        private async Task<IPagedList<Administrator>> BindAdministratori(AdministratorSearchRequest request,int pageNumber =1, int pageSize=2)
        {

            var administratori = await _administratorService.Get<List<Administrator>>(request);

            return administratori.ToPagedList(pageNumber, pageSize);
         
        }

        private void frmAdministratori_Load(object sender, EventArgs e)
        {
            pageNumber = 1;
            BindContent(pageNumber, null);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pagedList.HasNextPage)
            {
                BindContent(++pageNumber, request);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pagedList.HasPreviousPage)
            {
                BindContent(--pageNumber, request);
            }
        }
    }
}
