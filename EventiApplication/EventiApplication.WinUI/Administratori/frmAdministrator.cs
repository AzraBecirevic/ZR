using EventiApplication.Model;
using EventiApplication.Model.Request;
using Flurl.Http;
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

namespace EventiApplication.WinUI.Administratori
{
    public partial class FrmAdministrator : Form
    {
        private readonly APIService _administratorService = new APIService("Administrator");
        private readonly APIService _gradService = new APIService("Grad");

        private Administrator administrator = null;

        public FrmAdministrator()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text ))
            {
                errorProvider1.SetError(txtIme, Properties.Resources.valErrRequired);
                e.Cancel = true;
            }
            else if (txtIme.Text.Length < 2 || txtIme.Text.Length > 30)
            {
                errorProvider1.SetError(txtIme, Properties.Resources.valErrMinLenght2);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtIme, null);
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
            else if(txtTelefon.Text.Length > 9)
            {
                errorProvider1.SetError(txtTelefon, Properties.Resources.valErrTelefonFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtTelefon, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider1.SetError(txtPrezime, Properties.Resources.valErrRequired);
                e.Cancel = true;
            }
            else if (txtPrezime.Text.Length < 2 || txtPrezime.Text.Length > 30)
            {
                errorProvider1.SetError(txtPrezime, Properties.Resources.valErrMinLenght2);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPrezime, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
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
                AdministratorUpdateRequest request = new AdministratorUpdateRequest
                {
                    Email = txtEmail.Text,
                    GradId = (cmbGrad.SelectedItem as Grad).Id,
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Telefon = txtTelefon.Text,
                    Username = txtUsername.Text
                };
                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    request.Password = txtPassword.Text;
                    request.PasswordConfirmation = txtPasswordConfirmation.Text;
                }
                else
                {
                    request.Password = null;
                    request.PasswordConfirmation = null;
                }

                var result = await _administratorService.Update<Administrator>(administrator.Id, request);

             
                if (result != null)
                {
                    MessageBox.Show(Properties.Resources.UspjesnaAkcija, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, Properties.Resources.valErrRequired);
                e.Cancel = true;
            }
            else if (txtUsername.Text.Length < 3 || txtUsername.Text.Length > 40)
            {
                errorProvider1.SetError(txtUsername, Properties.Resources.valErrMinLenght3);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {  
                Regex hasNumber = new Regex(@"[0-9]+");
                Regex hasLowerCase = new Regex(@"[a-z]+");
                Regex hasUpperCase = new Regex(@"[A-Z]+");
               
                if (txtPassword.Text.Length < 8 || txtPassword.Text.Length > 50)
                {
                    errorProvider1.SetError(txtPassword, Properties.Resources.valErrPassword1);
                    e.Cancel = true;
                }
                else if (!hasNumber.IsMatch(txtPassword.Text))
                {
                    errorProvider1.SetError(txtPassword, Properties.Resources.valErrPassword2);
                    e.Cancel = true;
                }
                else if (!hasLowerCase.IsMatch(txtPassword.Text))
                {
                    errorProvider1.SetError(txtPassword, Properties.Resources.valErrPassword2);
                    e.Cancel = true;
                }
                else if (!hasUpperCase.IsMatch(txtPassword.Text))
                {
                    errorProvider1.SetError(txtPassword, Properties.Resources.valErrPassword2);
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(txtPassword, null);
                }
            }
        }

        private void txtPasswordConfirmation_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                if (string.IsNullOrWhiteSpace(txtPasswordConfirmation.Text))
                {
                    errorProvider1.SetError(txtPasswordConfirmation, Properties.Resources.valErrPassConfirmation);
                    e.Cancel = true;
                }
                else if(txtPasswordConfirmation.Text != txtPassword.Text)
                {
                    errorProvider1.SetError(txtPasswordConfirmation, Properties.Resources.valErrPassConfirmation);
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(txtPasswordConfirmation, null);
                }
            }
        }

        private void frmAdministrator_Load(object sender, EventArgs e)
        {
            BindGradovi();

            administrator = Global.Administrator;
            txtIme.Text = administrator.Ime;
            txtPrezime.Text = administrator.Prezime;
            txtTelefon.Text = administrator.Telefon;
            txtEmail.Text = administrator.Email;
            txtUsername.Text = administrator.Username;
        }

        private async void BindGradovi()
        {
            var gradovi = await _gradService.Get<List<Model.Grad>>(null);
            gradovi.Insert(0, new Model.Grad { Naziv = "Odaberite grad", Id = 0, });

            cmbGrad.DataSource = gradovi;
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.ValueMember = "Id";

            cmbGrad.SelectedItem = gradovi.Where(g => g.Id == administrator.Id).FirstOrDefault();
        }
    }
}
