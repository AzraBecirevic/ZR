using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using EventiApplication.Mobile.Models;

namespace EventiApplication.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Pocetna, (NavigationPage)Detail);    //browse
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Pocetna:
                        MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage))) { BarBackgroundColor = Color.Black });
                        break;
                    case (int)MenuItemType.Prijateljstva:
                        MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(PrijateljstvaPage))) { BarBackgroundColor = Color.Black });
                        break;
                    case (int)MenuItemType.Pozivi:
                        MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(PoziviPage))) { BarBackgroundColor = Color.Black });
                        break;
                    case (int)MenuItemType.PosjeceniEventi:
                        MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(PosjeceniEventiPage))) { BarBackgroundColor = Color.Black });
                        break;
                    case (int)MenuItemType.MojiPodaci:
                        MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(MojiPodaciPage))) { BarBackgroundColor = Color.Black });
                        break;
                    case (int)MenuItemType.GPS:
                        MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(GPSPage))) { BarBackgroundColor = Color.Black });
                        break;
                    case (int)MenuItemType.Chat:
                        MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(ChatPage))) { BarBackgroundColor = Color.Black });
                        break;
                    case (int)MenuItemType.LogOut:
                        MenuPages.Add(id, new NavigationPage((Page)Activator.CreateInstance(typeof(OdjavaPage))) { BarBackgroundColor = Color.Black });
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}