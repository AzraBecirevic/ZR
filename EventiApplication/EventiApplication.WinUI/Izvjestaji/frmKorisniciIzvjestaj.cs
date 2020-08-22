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
    public partial class frmKorisniciIzvjestaj : Form
    {
        private readonly APIService _korisnikService = new APIService("Korisnik");
        private readonly APIService _kupovinaService = new APIService("Kupovina");

        public Korisnik Korisnik { get; set; }
        public List<Kupovina> kupovine { get; set; }

        int KorisnikId =0;
        public frmKorisniciIzvjestaj(int id)
        {
            KorisnikId = id;
            InitializeComponent();
        }

        private async void frmKorisniciIzvjestaj_Load(object sender, EventArgs e)
        {
            this.Korisnik = await _korisnikService.GetById<Korisnik>(KorisnikId);

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Ime", Korisnik.Ime));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Prezime", Korisnik.Prezime));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("KorisnickoIme", Korisnik.Username));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Email", Korisnik.Email));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Telefon", Korisnik.Telefon));

            KupovinaSearchRequest request = new KupovinaSearchRequest { KorisnikId = this.KorisnikId };

            kupovine = await _kupovinaService.Get<List<Kupovina>>(request);

            ReportDataSource rdsKupovina = new ReportDataSource("DataSet2", kupovine);
            this.reportViewer1.LocalReport.DataSources.Add(rdsKupovina);

            this.reportViewer1.RefreshReport();
        }
    }
}
