using EventiApplication.Mobile.Views;
using EventiApplication.Model;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EventiApplication.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnik");

        public LoginViewModel()
        {
            LoginCommand = new Command( async()=> await Login());
        }

        public ICommand LoginCommand { get; set; }

        private string _username= string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private string _lblUsernameErr = string.Empty;
        public string LblUsernameErr
        {
            get { return _lblUsernameErr; }
            set { SetProperty(ref _lblUsernameErr, value); }
        }

        private string _lblPasswordErr = string.Empty;
        public string LblPasswordErr
        {
            get { return _lblPasswordErr; }
            set { SetProperty(ref _lblPasswordErr, value); }
        }
        async Task Login()
        {
            if (!Validate())
            {
                return;
            }
            APIService.Username = Username;
            APIService.Password = Password;

            try
            {
                 KorisnikSearchRequest request = new KorisnikSearchRequest { Username = this.Username };
                 List<Korisnik> list = await _service.Get<List<Korisnik>>(request);
                 if (list.Count() == 1)
                 {
                    if(list[0].IsAktivan == true)
                    {
                        Global.Korisnik = list[0];
                        Application.Current.MainPage = new MainPage();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Greska", "Vas nalog nije aktivan", "OK");
                    }
                 }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Greska", "Ne mozete se prijaviti", "OK");
                }
              
            }
            catch(Exception ex)
            {
               
            } 
        }

        private bool Validate()
        {
            if (UsernameValidation() && PasswordValidation())
                return true;
            return false;
        }

        private bool UsernameValidation()
        {
            bool IsValidno = true;
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrEmpty(Username))
            {
                LblUsernameErr = Messages.ValErrObaveznoPolje;
                IsValidno = false;
            }
           
            if (IsValidno == true)
            {
                LblUsernameErr = null;

            }
            return IsValidno;
        }

        private bool PasswordValidation()
        {
            bool IsValidno = true;
           
            if (string.IsNullOrWhiteSpace(Password) || string.IsNullOrEmpty(Password))
            {
                LblPasswordErr = Messages.ValErrObaveznoPolje;
                IsValidno = false;
            }
          
            if (IsValidno == true)
            {
                LblPasswordErr = null;
            }
            return IsValidno;
        }
    }
}
