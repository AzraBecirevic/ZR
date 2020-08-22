using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xamarin.Essentials;

namespace EventiApplication.Mobile.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            //?
            Platform.MapServiceToken = "Arq_PsOb9JDoBElf2Y4DdC85O7GNHiiHhTXmhr-MU60D3dSoNKMNgfCPuBG0j6Ot";

                // stari kljuc "AvEMT9xnkTY8rfXzR7TD1jaClhYUX9qqfSrRORpATDvhkyv9ltiaXw765QFZPX2U";
            LoadApplication(new EventiApplication.Mobile.App());
           
        }
    }
}
