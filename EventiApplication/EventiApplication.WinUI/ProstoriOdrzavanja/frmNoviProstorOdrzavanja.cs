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

namespace EventiApplication.WinUI.ProstoriOdrzavanja
{
    public partial class frmNoviProstorOdrzavanja : Form
    {
        private readonly APIService _prostorOdrzavanjaService = new APIService("ProstorOdrzavanja");
        private readonly APIService _tipProstoraService = new APIService("TipProstoraOdrzavanja");
        private readonly APIService _gradService = new APIService("Grad");

        int ProstorId = 0;
        ProstorOdrzavanja vraceniProstor = null;
        frmProstorOdrzavanja frmProstorOdrzavanja = null;
        public frmNoviProstorOdrzavanja(frmProstorOdrzavanja frm, int id)
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
            ProstorId = id;
            frmProstorOdrzavanja = frm;
        }

        private void frmNoviProstorOdrzavanja_Load(object sender, EventArgs e)
        {
            BindTipoviProstoraOdrzavanja();
            BindGradovi();
            if (ProstorId != 0)
                BindProstor();
        }

        private async void BindProstor()
        {
            vraceniProstor =await _prostorOdrzavanjaService.GetById<ProstorOdrzavanja>(ProstorId);
            if (vraceniProstor != null)
            {
                var gradovi = await _gradService.Get<List<Model.Grad>>(null);
                gradovi.Insert(0, new Model.Grad { Naziv = "Odaberite grad", Id = 0, });

                cmbGrad.DataSource = gradovi;
                cmbGrad.DisplayMember = "Naziv";
                cmbGrad.ValueMember = "Id";

                cmbGrad.SelectedItem = gradovi.Where(g => g.Id == vraceniProstor.GradId).FirstOrDefault();


                var tipoviProstoraOdrzavanja = await _tipProstoraService.Get<List<Model.TipProstoraOdrzavanja>>(null);
                tipoviProstoraOdrzavanja.Insert(0, new Model.TipProstoraOdrzavanja { Id = 0, Naziv = "Odaberite tip prostora odrzavanja" });

                cmbTipProstoraOdrzavanja.DataSource = tipoviProstoraOdrzavanja;
                cmbTipProstoraOdrzavanja.DisplayMember = "Naziv";
                cmbTipProstoraOdrzavanja.ValueMember = "Id";

                cmbTipProstoraOdrzavanja.SelectedItem = tipoviProstoraOdrzavanja.Where(t => t.Id == vraceniProstor.TipProstoraOdrzavanjaId).FirstOrDefault();
                /* foreach (var item in cmbGrad.Items)
                 {
                     if ((item as Grad).Id == vraceniProstor.GradId)
                     {

                         cmbGrad.SelectedItem = item;
                         break;
                     }
                 }

                foreach (var item in cmbTipProstoraOdrzavanja.Items)
                {
                    if ((item as TipProstoraOdrzavanja).Id == vraceniProstor.TipProstoraOdrzavanjaId)
                    {
                        cmbTipProstoraOdrzavanja.SelectedItem = item;
                        break;
                    }
                }*/

                txtNaziv.Text = vraceniProstor.Naziv;
                txtAdresa.Text = vraceniProstor.Adresa;

            }
        }

        private async void BindGradovi()
        {
            var gradovi = await _gradService.Get<List<Model.Grad>>(null);
            gradovi.Insert(0, new Model.Grad { Naziv = "Odaberite grad", Id = 0, });

            cmbGrad.DataSource = gradovi;
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.ValueMember = "Id";
        }

        private async void BindTipoviProstoraOdrzavanja()
        {
            var tipoviProstoraOdrzavanja = await _tipProstoraService.Get<List<Model.TipProstoraOdrzavanja>>(null);
            tipoviProstoraOdrzavanja.Insert(0, new Model.TipProstoraOdrzavanja { Id = 0, Naziv = "Odaberite tip prostora odrzavanja" });

            cmbTipProstoraOdrzavanja.DataSource = tipoviProstoraOdrzavanja;
            cmbTipProstoraOdrzavanja.DisplayMember = "Naziv";
            cmbTipProstoraOdrzavanja.ValueMember = "Id";
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.valErrRequired);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNaziv, null);
            }
        }

        private void txtAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdresa.Text))
            {
                errorProvider1.SetError(txtAdresa, Properties.Resources.valErrRequired);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtAdresa, null);
            }
        }

        private void cmbTipProstoraOdrzavanja_Validating(object sender, CancelEventArgs e)
        {
            if(cmbTipProstoraOdrzavanja.SelectedIndex == 0)
            {
                errorProvider1.SetError(cmbTipProstoraOdrzavanja, Properties.Resources.valErrObavezanIzbor);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cmbTipProstoraOdrzavanja, null);
            }
        }

        private void cmbGrad_Validating(object sender, CancelEventArgs e)
        {
            if (cmbGrad.SelectedIndex == 0)
            {
                errorProvider1.SetError(cmbGrad, Properties.Resources.valErrObavezanIzbor);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cmbGrad, null);
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                ProstorOdrzavanjaInsertRequest request = new ProstorOdrzavanjaInsertRequest
                {
                    Adresa = txtAdresa.Text,
                    Naziv = txtNaziv.Text,
                    GradId = (cmbGrad.SelectedItem as Grad).Id,
                    TipProstoraOdrzavanjaId = (cmbTipProstoraOdrzavanja.SelectedItem as TipProstoraOdrzavanja).Id
                };
                if(ProstorId == 0)
                {
                    var result = await _prostorOdrzavanjaService.Insert<Model.ProstorOdrzavanja>(request);

                    if (result != null)
                    {
                        MessageBox.Show(Properties.Resources.UspjesnaAkcija, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    var result = await _prostorOdrzavanjaService.Update<Model.ProstorOdrzavanja>(ProstorId,request);

                    if (result != null)
                    {
                        MessageBox.Show(Properties.Resources.UspjesnaAkcija, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        frmProstorOdrzavanja.BindContent(frmProstorOdrzavanja.pageNumber);
                    }
                }
  
            }
        }
    }
}
