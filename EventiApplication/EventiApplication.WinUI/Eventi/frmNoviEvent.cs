using EventiApplication.Model;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventiApplication.WinUI.Eventi
{
    public partial class frmNoviEvent : Form
    {
        private readonly APIService _eventiService = new APIService("Event");
        private readonly APIService _kategorijeService = new APIService("Kategorija");
        private readonly APIService _prostoriOdrzavanjaService = new APIService("ProstorOdrzavanja");
        private readonly APIService _organizatoriService = new APIService("Organizator");


        EventInsertRequest request = new EventInsertRequest();
        Event vraceniEvent { get; set; } = null; 
        int eventId = 0;
        frmEventi frmEventi = null;

        public frmNoviEvent(frmEventi frm,int id=0)
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
            eventId = id;
            frmEventi = frm;
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.valErrRequired);
                e.Cancel = true;
            }
            if (txtNaziv.Text.Length < 2)
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.valErrMinLenght2);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNaziv, null);
            }

        }

        private void cmbProstorOdrzavanja_Validating(object sender, CancelEventArgs e)
        {
            if (cmbProstorOdrzavanja.SelectedIndex == 0)
            {
                errorProvider1.SetError(cmbProstorOdrzavanja, Properties.Resources.valErrObavezanIzbor);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cmbProstorOdrzavanja, null);
            }
        }

        private void cmbOrganizator_Validating(object sender, CancelEventArgs e)
        {
            if (cmbOrganizator.SelectedIndex == 0)
            {
                errorProvider1.SetError(cmbOrganizator, Properties.Resources.valErrObavezanIzbor);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cmbOrganizator, null);
            }
        }

        private void cmbKategorije_Validating(object sender, CancelEventArgs e)
        {
            if (cmbKategorije.SelectedIndex == 0)
            {
                errorProvider1.SetError(cmbKategorije, Properties.Resources.valErrObavezanIzbor);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cmbKategorije, null);
            }
        }

        private void txtVrijeme_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"\d{2}[:]\d{2}");
            if (string.IsNullOrWhiteSpace(txtVrijeme.Text))
            {
                errorProvider1.SetError(txtVrijeme, Properties.Resources.valErrRequired);
                e.Cancel = true;
            }
            if (!regex.IsMatch(txtVrijeme.Text))
            {
                errorProvider1.SetError(txtVrijeme, Properties.Resources.valErrTimeMatching);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtVrijeme, null);
            }
        }

        private void txtSlika_Validating(object sender, CancelEventArgs e)
        {
            if(eventId == 0)   // ako se dodaje novi event onda se mora dodati slika, ako je izmjena ne mora jer vac postoji
            {
                if (string.IsNullOrWhiteSpace(txtSlika.Text))
                {
                    errorProvider1.SetError(txtSlika, Properties.Resources.valErrObaveznaSlika);
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(txtSlika, null);
                }
            }
           
        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSlika.Text = openFileDialog1.FileName;

                Image image = Image.FromFile(openFileDialog1.FileName);

                MemoryStream ms = new MemoryStream();

                image.Save(ms, ImageFormat.Jpeg);

                request.Slika = ms.ToArray();

                int resizedImageWidth = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImageWidth"]);
                int resizedImageHeight = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImageHeight"]);
                int croppedImageWidth = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImageWidth"]);
                int croppedImageHeight = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImageHeight"]);

                if (image.Width > resizedImageWidth)
                {
                    //resize slike
                    Image resizedImage = Helper.Helper.ResizeImage(image, new Size(resizedImageWidth, resizedImageHeight));

                    // crop slike
                    Image croppedImage = resizedImage;  // u slucaju da se ne mogne izvrsitit cropping

                    if (resizedImage.Width >= croppedImageWidth && resizedImage.Height >= croppedImageHeight)
                    {
                        int croppedXposition = (resizedImageWidth - croppedImageWidth) / 2;
                        int croppedYposition = (resizedImageHeight - croppedImageHeight) / 2;

                        croppedImage = Helper.Helper.CropImage(resizedImage, new Rectangle(croppedXposition, croppedYposition, croppedImageWidth, croppedImageHeight));

                        ms = new MemoryStream();
                        croppedImage.Save(ms, ImageFormat.Jpeg);
                        request.SlikaThumb = ms.ToArray();

                        pictureBox1.Image = croppedImage;
                    }

                    pictureBox1.Image = croppedImage;
                } 
            }
        }

        private async void btnSnimiEvent_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                SnimiPodatke();

                if(eventId == 0)
                {
                    var result = await _eventiService.Insert<Event>(request);
                    if (result != null)
                    {
                        MessageBox.Show(Properties.Resources.UspjesnoDodavanjeEvent, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    var result = await _eventiService.Update<Event>(eventId,request);
                    if (result != null)
                    {
                        MessageBox.Show(Properties.Resources.UspjesnoIzmijenjenEvent, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmEventi.BindContent(frmEventi.pageNumber);
                    }
      
                }

            }
        }

        private void SnimiPodatke()
        {
            request.Naziv = txtNaziv.Text;
            request.Opis = txtOpis.Text;
            request.OrganizatorId = (cmbOrganizator.SelectedItem as Organizator).Id;
            request.AdministratorId = Global.Administrator.Id;
            request.DatumOdrzavanja = dtpDatumOdrzavanja.Value;
            request.IsOdobren = ckbOdobren.Checked;
            request.KategorijaId = (cmbKategorije.SelectedItem as Kategorija).Id;
            request.ProstorOdrzavanjaId = (cmbProstorOdrzavanja.SelectedItem as Model.ProstorOdrzavanja).Id;
            request.VrijemeOdrzavanja = txtVrijeme.Text;

            if(eventId == 0)
            {
                request.IsOtkazan = false;
            }
            else                      // izmjena eventa u pitanju
            {
                request.IsOtkazan = ckbOtkazan.Checked;
                if (string.IsNullOrWhiteSpace(txtSlika.Text))   // znaci da korisnik ne zeli mijenjati sliku
                {                                                //treba da ostane ona koja je u bazi
                    request.Slika = vraceniEvent.Slika;
                    request.SlikaThumb = vraceniEvent.SlikaThumb; 
                }

            }
        }

        private void frmNoviEvent_Load(object sender, EventArgs e)
        {
          
            if (eventId != 0)
            {
                BindingEvent();
                ckbOtkazan.Visible = true;
            }
            else
            {
                BindKategorije();
                BindProstoriOdrzavanja();
                BindOrganizatori();
            }

        }

        

        private async void BindingEvent()
        {
            vraceniEvent =  await _eventiService.GetById<Model.Event>(eventId);
         
            BindOdabraneStavke();

            txtNaziv.Text = vraceniEvent.Naziv;
            txtOpis.Text = vraceniEvent.Opis;
            txtVrijeme.Text = vraceniEvent.VrijemeOdrzavanja;
            dtpDatumOdrzavanja.Value = vraceniEvent.DatumOdrzavanja;
            ckbOdobren.Checked = vraceniEvent.IsOdobren;

        
            if (vraceniEvent.SlikaThumb != null && vraceniEvent.SlikaThumb.Length > 0)
            {
                MemoryStream stream = new MemoryStream(vraceniEvent.SlikaThumb);
                Image img = Image.FromStream(stream);

                pictureBox1.Image = img;
            }
            else
            {
                if (vraceniEvent.Slika != null && vraceniEvent.Slika.Length > 0)
                {
                    MemoryStream stream = new MemoryStream(vraceniEvent.Slika);
                    Image img = Image.FromStream(stream);

                    pictureBox1.Image = img;
                }
            }
           
        }

        private async void BindOdabraneStavke()
        {
            var kategorijeBind = await _kategorijeService.Get<List<Kategorija>>(null);
            kategorijeBind.Insert(0, new Model.Kategorija { Id = 0, Naziv = "Odaberite kategoriju" });

            cmbKategorije.DataSource = kategorijeBind;
            cmbKategorije.DisplayMember = "Naziv";
            cmbKategorije.ValueMember = "Id";
            cmbKategorije.SelectedItem = kategorijeBind.Where(k => k.Id == vraceniEvent.KategorijaId).FirstOrDefault();
           
            var organizatoriBind = await _organizatoriService.Get<List<Organizator>>(null);
            organizatoriBind.Insert(0, new Model.Organizator { Id = 0, Naziv = "Odaberite organizatora" });

            cmbOrganizator.DataSource = organizatoriBind;
            cmbOrganizator.DisplayMember = "Naziv";
            cmbOrganizator.ValueMember = "Id";
            cmbOrganizator.SelectedItem = organizatoriBind.Where(o => o.Id == vraceniEvent.OrganizatorId).FirstOrDefault();
           

            var prostoriOdrzavanjaBind = await _prostoriOdrzavanjaService.Get<List<ProstorOdrzavanja>>(null);
            prostoriOdrzavanjaBind.Insert(0, new ProstorOdrzavanja { Id = 0, Naziv = "Odaberite prostor" });

            cmbProstorOdrzavanja.DataSource = prostoriOdrzavanjaBind;
            cmbProstorOdrzavanja.DisplayMember = "Naziv";
            cmbProstorOdrzavanja.ValueMember = "Id";
            cmbProstorOdrzavanja.SelectedItem = prostoriOdrzavanjaBind.Where(p => p.Id == vraceniEvent.ProstorOdrzavanjaId).FirstOrDefault();
          
        }

        private async void BindOrganizatori()
        { 
            var organizatori = await _organizatoriService.Get<List<Organizator>>(null);
            organizatori.Insert(0, new Model.Organizator { Id = 0, Naziv = "Odaberite organizatora" });

            cmbOrganizator.DataSource = organizatori;
            cmbOrganizator.DisplayMember = "Naziv";
            cmbOrganizator.ValueMember = "Id";
        }

        private async void BindProstoriOdrzavanja()
        {  
            var prostoriOdrzavanja = await _prostoriOdrzavanjaService.Get<List<ProstorOdrzavanja>>(null);
            prostoriOdrzavanja.Insert(0, new ProstorOdrzavanja { Id = 0, Naziv = "Odaberite prostor" });

            cmbProstorOdrzavanja.DataSource = prostoriOdrzavanja;
            cmbProstorOdrzavanja.DisplayMember = "Naziv";   
            cmbProstorOdrzavanja.ValueMember = "Id";
        }

        private async void BindKategorije()
        {  
            var kategorije = await _kategorijeService.Get<List<Kategorija>>(null);
            kategorije.Insert(0, new Model.Kategorija { Id = 0, Naziv = "Odaberite kategoriju" });

            cmbKategorije.DataSource = kategorije;
            cmbKategorije.DisplayMember = "Naziv";
            cmbKategorije.ValueMember = "Id";
        }
    }
}
