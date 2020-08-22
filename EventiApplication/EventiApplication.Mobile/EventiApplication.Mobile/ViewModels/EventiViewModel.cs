using EventiApplication.Model;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EventiApplication.Mobile.ViewModels
{
    public class EventiViewModel : BaseViewModel
    {
      
        private readonly APIService _eventService = new APIService("Event");
        public int kategorijaId { get; set; } = 0;  //? ne treba

        EventSearchRequest request = null;

        public ObservableCollection<Event> EventiList { get; set; } = new ObservableCollection<Event>();

       
        public async Task Init(int katId, string pretraga)
        {          
            if(katId == 0)
            {
                return;
            }
            
            request = new EventSearchRequest {  KategorijaId=katId, Predstojeci=true, PretragaNazivLokacija=pretraga};
            

            var eventi = await _eventService.Get<List<Event>>(request);

            EventiList.Clear();

            foreach (var e in eventi)
            {
                EventiList.Add(e);
            }
        }
    }
}
