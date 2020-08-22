﻿using EventiApplication.Mobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventiApplication.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Pocetna, Title="Početna" },
                new HomeMenuItem {Id = MenuItemType.Prijateljstva, Title="Prijateljstva" },
                new HomeMenuItem {Id = MenuItemType.Pozivi, Title="Pozivi" },
                new HomeMenuItem {Id = MenuItemType.PosjeceniEventi, Title="Posjećeni eventi" },
                new HomeMenuItem {Id = MenuItemType.MojiPodaci, Title="Moji podaci" },
                new HomeMenuItem {Id = MenuItemType.GPS, Title="GPS preporuka" },
                new HomeMenuItem {Id = MenuItemType.LogOut, Title="Odjava" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };

            
        }

      
    }
}