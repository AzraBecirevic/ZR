using EventiApplication.Model;
using EventiApplication.Model.Request;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventiApplication.WinUI.Izvjestaji
{
    public partial class frmOrganizatorIzvjestaj : Form
    {
        private readonly APIService _organizatorService = new APIService("Organizator");
        private readonly APIService _eventiService = new APIService("Event");
        private readonly APIService _prodajaTipService = new APIService("ProdajaTip");

        public Organizator organizator { get; set; }
        public List<Event> eventi { get; set; }

        public List<EventIzvjestaj> eventIzvjestaji { get; set; } = new List<EventIzvjestaj>();

        public List<ProdajaTip> prodajaTipovi { get; set; } = new List<ProdajaTip>();

        int OrgId = 0;
        public frmOrganizatorIzvjestaj(int orgId)
        {
            OrgId = orgId;
            InitializeComponent();
        }

        private async void frmOrganizatorIzvjestaj_Load(object sender, EventArgs e)
        {
            organizator = await _organizatorService.GetById<Organizator>(OrgId);
            EventSearchRequest request = new EventSearchRequest { OrganizatorId = OrgId };
            eventi =await _eventiService.Get<List<Event>>(request);

            foreach(var item in eventi)
            {
                eventIzvjestaji.Add(new EventIzvjestaj
                {
                    Naziv = item.Naziv,
                    DatumOdrzavanja = item.DatumOdrzavanja.ToShortDateString(),
                    KategorijaNaziv = item.KategorijaNaziv,
                    Mjesto = item.ProstorOdrzavanjaGradAdresa,
                    VrijemeOdrzavanja = item.VrijemeOdrzavanja
                });
            }

            foreach(var item in eventi)
            {
                ProdajaTipSearchRequest searchRequest = new ProdajaTipSearchRequest { EventId = item.Id };
                var vraceniProdajaTipovi = await _prodajaTipService.Get<List<ProdajaTip>>(searchRequest);
                prodajaTipovi.AddRange(vraceniProdajaTipovi);
            }

            ReportDataSource rdsEvent = new ReportDataSource("DataSet1", eventIzvjestaji);
            this.reportViewer1.LocalReport.DataSources.Add(rdsEvent);

            ReportDataSource rdsPrTipovi = new ReportDataSource("DataSet2", prodajaTipovi);
            this.reportViewer1.LocalReport.DataSources.Add(rdsPrTipovi);

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("OrganizatorNaziv", organizator.Naziv));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Telefon", organizator.Telefon));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Email", organizator.Email));


            this.reportViewer1.RefreshReport();
        }
    }
}
