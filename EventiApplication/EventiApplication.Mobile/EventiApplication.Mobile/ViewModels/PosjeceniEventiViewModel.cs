using EventiApplication.Model;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace EventiApplication.Mobile.ViewModels
{
    public class PosjeceniEventiViewModel
    {
        private readonly APIService _kupovinaService = new APIService("Kupovina");

        public ObservableCollection<Kupovina> KupovinaList { get; set; } = new ObservableCollection<Kupovina>();

        public async Task Init()
        {
            KupovinaSearchRequest request = new KupovinaSearchRequest { KorisnikId = Global.Korisnik.Id };

            var kupovine = await _kupovinaService.Get<List<Kupovina>>(request);
            if (kupovine != null)
            {
                KupovinaList.Clear();
                foreach (var k in kupovine)
                {
                    KupovinaList.Add(k);
                }
            }
            
        }
    }
}
