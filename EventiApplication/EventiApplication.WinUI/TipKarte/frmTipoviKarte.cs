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

namespace EventiApplication.WinUI.TipKarte
{
    public partial class frmTipoviKarte : Form
    {
        private readonly APIService _service = new APIService("ProdajaTip");
        private readonly APIService _eventiService = new APIService("Event");

        private int EventId { get; set; }
        public frmTipoviKarte(int id)
        {
            InitializeComponent();
            EventId = id;
            dgvProdajaTip.AutoGenerateColumns = false;
        }

        private async void frmTipoviKarte_Load(object sender, EventArgs e)
        {
            var Event = await _eventiService.GetById<Event>(EventId);
            lblNazivEventa.Text = Event?.Naziv;   //provjera je li null
            
         //   BindProdajeTipovaKarata();
        }

        public async  void BindProdajeTipovaKarata()
        {
            // ProdajaTipSearchRequest request = new ProdajaTipSearchRequest { EventId = this.EventId };

            ProdajaTipSearchRequest request = new ProdajaTipSearchRequest
            {
                EventId = this.EventId,
                IsProdajaVecaOd0 = ckbBrProdKarata.Checked,
                TipKarteNaziv = txtTipKarte.Text
            };
            var prodajeTipoveKarata = await _service.Get<List<ProdajaTip>>(request);

            dgvProdajaTip.DataSource = prodajeTipoveKarata;
        }

        private void btnNoviTipKarte_Click(object sender, EventArgs e)
        {
            frmNoviTipKarte frm = new frmNoviTipKarte(this.EventId, this);
            frm.MdiParent = this.MdiParent;

            frm.Show();

        }


        private async void btnIzbrisiTipKarte_Click(object sender, EventArgs e)
        {
            if (dgvProdajaTip.SelectedRows.Count > 0)
            {
                string id = dgvProdajaTip.SelectedRows[0].Cells[0].Value.ToString();

                int prodajaTipId = int.Parse(id);
                var result = await _service.Delete<Model.ProdajaTip>(prodajaTipId);

                if (result != null)
                    MessageBox.Show(Properties.Resources.UspjesnaAkcija, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(Properties.Resources.nemBrisanjeProdaje, "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                BindProdajeTipovaKarata();
            }
            else
            {
                MessageBox.Show(Properties.Resources.selectTipProdaje, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void btnIzmjeni_Click(object sender, EventArgs e)
        {
            if (dgvProdajaTip.SelectedRows.Count > 0)
            {
                string id = dgvProdajaTip.SelectedRows[0].Cells[0].Value.ToString();
                int idProdaje = int.Parse(id);
                frmNoviTipKarte frm = new frmNoviTipKarte(EventId,this, idProdaje);

                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    BindProdajeTipovaKarata();
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.selectTipProdaje, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
           
            BindProdajeTipovaKarata();
        }
    }
}
