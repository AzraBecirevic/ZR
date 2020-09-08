using EventiApplication.Model;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventiApplication.WinUI.Korisnici
{
    public partial class frmKorisniciDetalji : Form
    {
        private readonly APIService _korisniciService = new APIService("Korisnik");
        private readonly APIService _gradService = new APIService("Grad");

        Korisnik korisnik = null;
        private int KorisnikId;
        frmKorisnici frmKorisnici = null;
        public frmKorisniciDetalji(int id, frmKorisnici frm)
        {
            InitializeComponent();
            KorisnikId = id;
            frmKorisnici = frm;
        }

        private void frmKorisniciDetalji_Load(object sender, EventArgs e)
        {
            BindKorisnik();
        }

        private async void BindKorisnik()
        {
            korisnik = await _korisniciService.GetById<Korisnik>(KorisnikId);
            if(korisnik != null)
            {
                txtIme.Text = korisnik.Ime;
                txtPrezime.Text = korisnik.Prezime;
                
                txtAdresa.Text = korisnik.Adresa;
                txtPostanskiBroj.Text = korisnik.PostanskiBroj;
                txtUsername.Text = korisnik.Username;
                txtEmail.Text = korisnik.Email;
                txtTelefon.Text = korisnik.Telefon;
                ckbIsAktivan.Checked = korisnik.IsAktivan;

                Grad grad = await _gradService.GetById<Grad>(korisnik.GradId);
                txtGrad.Text = grad.Naziv;

                if (korisnik.Slika != null && korisnik.Slika.Length >0)
                {
                    MemoryStream stream = new MemoryStream(korisnik.Slika);
                    Image img = Image.FromStream(stream);   //parametr is not valid
                   // pictureBox.Image = img;
                }
               
            }
        }

        private async void btnPromijeniAktivnost_Click(object sender, EventArgs e)
        {
           if(korisnik != null)
           {
                
                KorisnikPatchRequest request = new KorisnikPatchRequest
                {
                    Id = KorisnikId,
                    IsAktivan = ckbIsAktivan.Checked
                };


                var result = await _korisniciService.UpdateAttribute<Model.Korisnik>(request); 

                if (result != null)
                {
                    MessageBox.Show(Properties.Resources.UspjesnaAkcija, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmKorisnici.BindContent(frmKorisnici.pageNumber);
                }
                else
                {
                    MessageBox.Show(Properties.Resources.nijePromijenjenStatus ,"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
           }
        }
        
    }
}
