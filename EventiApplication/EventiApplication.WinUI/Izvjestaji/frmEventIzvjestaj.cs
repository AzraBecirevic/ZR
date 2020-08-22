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
    public partial class frmEventIzvjestaj : Form
    {

        private readonly APIService _eventiService = new APIService("Event");
        private readonly APIService _prodajaTipService = new APIService("ProdajaTip");
        private readonly APIService _ocjeneService = new APIService("Ocjena");
        private readonly APIService _likeService = new APIService("Like");

        int eventId { get; set; }
        public Event Event { get; set; }
        public List<ProdajaTip> prodajaTipovi { get; set; }
        public List<Ocjena> Ocjene { get; set; }
        public List<Like> Likes { get; set; }


        public frmEventIzvjestaj(int id)
        {
            eventId = id;
            InitializeComponent();
        }

        private async void EventIzvjestaj_Load(object sender, EventArgs e)
        {
            Event = await _eventiService.GetById<Event>(eventId);

            ProdajaTipSearchRequest request = new ProdajaTipSearchRequest { EventId = eventId };

            prodajaTipovi = await _prodajaTipService.Get<List<ProdajaTip>>(request);

            OcjenaSearchRequest ocjenaSearch = new OcjenaSearchRequest { EventId = eventId };
            Ocjene = await _ocjeneService.Get<List<Ocjena>>(ocjenaSearch);

            LikeSearchRequest likeSearch = new LikeSearchRequest { EventId = eventId };
            Likes = await _likeService.Get<List<Like>>(likeSearch);


            EventBindingSource.DataSource = Event;
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Naziv", Event.Naziv));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Kategorija", Event.KategorijaNaziv));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Mjesto", Event.ProstorOdrzavanjaGradAdresa));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Naziv", Event.Naziv));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("DatumOdrzavanja", Event.DatumOdrzavanja.ToShortDateString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Vrijeme", Event.VrijemeOdrzavanja));

            ReportDataSource rds = new ReportDataSource("DataSet1", prodajaTipovi);
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            ReportDataSource rds2 = new ReportDataSource("DataSet2", Ocjene);
            this.reportViewer1.LocalReport.DataSources.Add(rds2);

            ReportDataSource rds3 = new ReportDataSource("DataSet3", Likes);
            this.reportViewer1.LocalReport.DataSources.Add(rds3);

            this.reportViewer1.RefreshReport();
        }
    }
}
