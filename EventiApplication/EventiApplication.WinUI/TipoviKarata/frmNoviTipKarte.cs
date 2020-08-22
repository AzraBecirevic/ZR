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

namespace EventiApplication.WinUI.TipoviKarata
{
    public partial class frmNoviTipKarte : Form
    {
        private readonly APIService _tipKarteService = new APIService("TipKarte");
        public frmNoviTipKarte()
        {
            InitializeComponent();
        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            TipKarteInsertRequest request = new TipKarteInsertRequest { Naziv = txtNaziv.Text };
            var result = await _tipKarteService.Insert<Model.TipKarte>(request);
            if (result != null)
            {
                MessageBox.Show(Properties.Resources.UspjesnaAkcija, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
