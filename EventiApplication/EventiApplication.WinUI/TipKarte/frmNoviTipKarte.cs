using EventiApplication.Model;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventiApplication.WinUI.TipKarte
{
    public partial class frmNoviTipKarte : Form
    {
        private readonly APIService _tipKarteService = new APIService("TipKarte");
        private readonly APIService _prodajaTipService = new APIService("ProdajaTip");


        private int eventId;
        int prodajaId;

        frmTipoviKarte frm = null;

        

        public frmNoviTipKarte(int id, frmTipoviKarte form, int prodId = 0)
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
            eventId = id;
            prodajaId = prodId;
            frm = form;
        }

        private void frmNoviTipKarte_Load(object sender, EventArgs e)
        {
           
            if (prodajaId != 0)
                BindProdajaTip();
            else
                BindTipoviKarata();
            
        }

    private async void BindProdajaTip()
        {
            ProdajaTip prodajaTip =await _prodajaTipService.GetById<ProdajaTip>(prodajaId);
            if (prodajaTip != null)
            {
                txtCijena.Text = prodajaTip.CijenaTip.ToString();
                nudUkupnoZaProdaju.Value = prodajaTip.UkupnoKarataTip;
                ckbPostojeSjedista.Checked = prodajaTip.PostojeSjedista;

                var tipoviKarata = await _tipKarteService.Get<List<Model.TipKarte>>(null);
                tipoviKarata.Insert(0, new Model.TipKarte { Id = 0, Naziv = "Odaberite tip karte" });
                cmbTipKarte.DataSource = tipoviKarata;
                cmbTipKarte.DisplayMember = "Naziv";
                cmbTipKarte.ValueMember = "Id";
                cmbTipKarte.SelectedItem = tipoviKarata.Where(t => t.Id == prodajaTip.TipKarteId).FirstOrDefault();
            }
        }

        private async void BindTipoviKarata()
        {
            var tipoviKarata = await _tipKarteService.Get<List<Model.TipKarte>>(null);
            tipoviKarata.Insert(0, new Model.TipKarte { Id = 0, Naziv = "Odaberite tip karte" });
            cmbTipKarte.DataSource = tipoviKarata;
            cmbTipKarte.DisplayMember = "Naziv";
            cmbTipKarte.ValueMember = "Id";
        }

        private void cmbTipKarte_Validating(object sender, CancelEventArgs e)
        {
            if (cmbTipKarte.SelectedIndex == 0)
            {
                errorProvider1.SetError(cmbTipKarte, Properties.Resources.valErrObavezanIzbor);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cmbTipKarte,null);
            }
        }

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"[a-zA-Z]+");
            if (string.IsNullOrWhiteSpace(txtCijena.Text))
            {
                errorProvider1.SetError(txtCijena, Properties.Resources.valErrRequired);
                e.Cancel = true;
            }
            else if (regex.IsMatch(txtCijena.Text))
            {
                errorProvider1.SetError(txtCijena, Properties.Resources.valErrSamoBrojevi);
                e.Cancel = true;
            }
            else if (float.Parse(txtCijena.Text) <= 0)
            {
                errorProvider1.SetError(txtCijena, Properties.Resources.valErrVeceOd0);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCijena, null);
            }
        }

      

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                ProdajaTipInsertRequest request = new ProdajaTipInsertRequest
                {
                    CijenaTip = float.Parse(txtCijena.Text),
                    EventId = this.eventId,
                    PostojeSjedista = ckbPostojeSjedista.Checked,
                    TipKarteId = (cmbTipKarte.SelectedItem as Model.TipKarte).Id,
                    UkupnoKarataTip = (int)nudUkupnoZaProdaju.Value
                };
                if (prodajaId == 0)
                {
                    try
                    {
                        var result = await _prodajaTipService.Insert<Model.ProdajaTip>(request);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Problem prilikom definisanja tipa prodaje");
                    }
                }
                else
                {
                    try
                    {
                        var result = await _prodajaTipService.Update<Model.ProdajaTip>(prodajaId,request);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Problem prilikom izmjene tipa prodaje");
                    }
                }
                
                 MessageBox.Show(Properties.Resources.UspjesnaAkcija, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();  //dodato zbog mdiproblema sa novitipkarte i show dialog
                frm.BindProdajeTipovaKarata();
            }
        }

        private void nudUkupnoZaProdaju_Validating(object sender, CancelEventArgs e)
        {
            if (nudUkupnoZaProdaju.Value <= 0)
            {
                errorProvider1.SetError(nudUkupnoZaProdaju, Properties.Resources.valErrVeceOd0);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(nudUkupnoZaProdaju, null);
            }
        }
    }
}
