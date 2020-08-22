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

namespace EventiApplication.WinUI
{
    public partial class frmLogin : Form
    {
        private readonly APIService _service = new APIService("Administrator");  
        public frmLogin()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, Properties.Resources.valErrRequired);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtUsername, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, Properties.Resources.valErrRequired);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPassword, null);
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                APIService.Username = txtUsername.Text;
                APIService.Password = txtPassword.Text;

                try
                {
                   
                   AdministratorSearchRequest request = new AdministratorSearchRequest { Username = txtUsername.Text };
                   var admins = await _service.Get<List<Administrator>>(request);
                   if (admins.Count() == 1)
                   {
                       //autentifiakcija je prosla, admin je nadjen 
                        Global.Administrator = admins[0];
                        //MessageBox.Show("welcome " + Global.Administrator.Grad.Naziv );  greska
                        frmPocetna frm = new frmPocetna();
                        frm.Show();
                   }
                }
                catch (Exception ex)
                {
                    
                }
            }
           
            
        }
    }
}
