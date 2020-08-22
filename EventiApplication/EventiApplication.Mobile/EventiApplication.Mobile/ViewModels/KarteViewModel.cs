using EventiApplication.Model;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace EventiApplication.Mobile.ViewModels
{
    public class KarteViewModel
    {
        private readonly APIService _karteService = new APIService("Karta");
        public ObservableCollection<Karta> KarteList { get; set; } = new ObservableCollection<Karta>();
        public async Task Init(int kupovinaId)
        {
            if (kupovinaId <= 0)
                return;

            KartaSearchRequest request = new KartaSearchRequest { KupovinaId = kupovinaId };

            var karte =await _karteService.Get<List<Karta>>(request);

            if (karte != null)
            {
                foreach (var k in karte)
                {
                    KarteList.Add(k);
                }
            }
          
        }
    }
}
