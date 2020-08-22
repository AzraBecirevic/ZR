using EventiApplication.Model;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventiApplication.WinUI.Organizatori
{
    public partial class frmNoviOrganizator : Form
    {
        private readonly APIService _organizatorService = new APIService("Organizator");
        private readonly APIService _gradService = new APIService("Grad");
        private int OrganizatorId;

        frmOrganizatori frmOrganizatori = null;
        public frmNoviOrganizator(frmOrganizatori frm,int id=0)
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
            OrganizatorId = id;
            frmOrganizatori = frm;
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.valErrRequired);
                e.Cancel = true;
            }
            else if(txtNaziv.Text.Length < 2)
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.valErrMinLenght2);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNaziv, null);
            }
        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"[0-9]{9}");
            Regex hasLetter = new Regex(@"[a-zA-Z]+");
            Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            
            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                errorProvider1.SetError(txtTelefon, Properties.Resources.valErrRequired);
                e.Cancel = true;
            }
            else if (hasLetter.IsMatch(txtTelefon.Text))
            {
                errorProvider1.SetError(txtTelefon, Properties.Resources.valErrTelefonFormat);
                e.Cancel = true;
            }
            else if (hasSymbols.IsMatch(txtTelefon.Text))
            {
                errorProvider1.SetError(txtTelefon, Properties.Resources.valErrTelefonFormat);
                e.Cancel = true;
            }
            else if (!regex.IsMatch(txtTelefon.Text))
            {
                errorProvider1.SetError(txtTelefon, Properties.Resources.valErrTelefonFormat);
                e.Cancel = true;
            }
            else if (txtTelefon.Text.Length > 9)
            {
                errorProvider1.SetError(txtTelefon, Properties.Resources.valErrTelefonFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtTelefon, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            //Regex regex = new Regex(@"[a-zA-Z]*[0-9]*[@][a-zA-Z]*[0-9]*[.][a-zA-Z]*");
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, Properties.Resources.valErrRequired);
                e.Cancel = true;
            }
            else if (!Helper.Helper.ProvjeriMailFormat(txtEmail.Text)) // mail nije ispravnog formata
            {
                errorProvider1.SetError(txtEmail, Properties.Resources.valErrEmailFormat);
                e.Cancel = true;
            }
           
            else
            {
                errorProvider1.SetError(txtEmail, null);
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

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                
                OrganizatorInsertRequest request = new OrganizatorInsertRequest
                {
                    Email = txtEmail.Text,
                    GradId = (cmbGrad.SelectedItem as Grad).Id,
                    Naziv = txtNaziv.Text,
                    Telefon = txtTelefon.Text
                };

                if(OrganizatorId == 0)
                {
                    var result = await _organizatorService.Insert<Model.Organizator>(request);

                    if (result != null)
                    {
                        MessageBox.Show(Properties.Resources.UspjesnaAkcija, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    var result = await _organizatorService.Update<Model.Organizator>(OrganizatorId,request);

                    if (result != null)
                    {
                        MessageBox.Show(Properties.Resources.UspjesnaAkcija, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmOrganizatori.BindContent(frmOrganizatori.pageNumber);
                    }
                }
               
            }
        }

        private void frmNoviOrganizator_Load(object sender, EventArgs e)
        {
            if (OrganizatorId != 0)
                BindOrganizator();
            else
                BindGradovi();
        }

        private async void BindOrganizator()
        {
            Organizator organizator = await _organizatorService.GetById<Organizator>(OrganizatorId);
          
            if(organizator != null)
            {
                var gradovi = await _gradService.Get<List<Grad>>(null);
                gradovi.Insert(0, new Grad { Id = 0, Naziv = "Odaberite grad", DrzavaId = 0 });

                cmbGrad.DataSource = gradovi;
                cmbGrad.DisplayMember = "Naziv";
                cmbGrad.ValueMember = "Id";
                cmbGrad.SelectedItem = gradovi.Where(g => g.Id == organizator.GradId).FirstOrDefault();

                txtNaziv.Text = organizator.Naziv;
                txtTelefon.Text = organizator.Telefon;
                txtEmail.Text = organizator.Email;
            }
        }

        private async void BindGradovi()
        {
            var gradovi = await _gradService.Get<List<Grad>>(null);
            gradovi.Insert(0, new Grad { Id = 0, Naziv = "Odaberite grad", DrzavaId = 0 });

            cmbGrad.DataSource = gradovi;
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.ValueMember = "Id";
        }
    }
}
