using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventiApplication.WinUI.TipoviKarata
{
    public partial class frmTipoviKarata : Form
    {
        private readonly APIService _tipKarteService = new APIService("TipKarte");
        public frmTipoviKarata()
        {
            InitializeComponent();
            dgvTipoviKarata.AutoGenerateColumns = false;
        }

        private void frmTipoviKarata_Load(object sender, EventArgs e)
        {
            BindTipoveKarata();
        }

        private async void BindTipoveKarata()
        {
            var tipoviKarata = await _tipKarteService.Get<List<Model.TipKarte>>(null);
            dgvTipoviKarata.DataSource = tipoviKarata;
        }

        private async void btnIzbrisi_Click(object sender, EventArgs e)
        {
            if (dgvTipoviKarata.SelectedRows.Count > 0)
            {
                string id = dgvTipoviKarata.SelectedRows[0].Cells[0].Value.ToString();
                int tipKarteId = int.Parse(id);

                var result =await _tipKarteService.Delete<Model.TipKarte>(tipKarteId);
                if (result != null )
                {
                    MessageBox.Show(Properties.Resources.UspjesnaAkcija, "Info");
                }
                else
                {
                    MessageBox.Show(Properties.Resources.nemBrisanjeTipaKarte);
                }

                BindTipoveKarata();
            }
            else
            {
                MessageBox.Show(Properties.Resources.selectTipKarte, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnPrikazi_Click(object sender, EventArgs e)
        {
            BindTipoveKarata();
        }
    }
}
