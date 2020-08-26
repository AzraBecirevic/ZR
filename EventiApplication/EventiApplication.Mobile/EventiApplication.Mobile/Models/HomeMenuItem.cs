using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Mobile.Models
{
    public enum MenuItemType
    {
        Pocetna,
        Prijateljstva,
        Pozivi,
        PosjeceniEventi,
        MojiPodaci,
        GPS,
        Chat,
        LogOut
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
