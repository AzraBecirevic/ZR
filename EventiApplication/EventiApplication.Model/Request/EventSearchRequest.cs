using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class EventSearchRequest
    {
        public int? KategorijaId { get; set; }
        public string Naziv { get; set; }
        public int GradId { get; set; }

        public bool IsOdobren { get; set; } // vraca samo odobrene evente
        public bool IsOtkazan { get; set; } // vraca samo otkazane evente

        public bool Predstojeci { get; set; } // vraca samo odobrene, buduce evente

        public int OrganizatorId { get; set; }
   
        public DateTime TrenutniDatum { get; set; }
        public TimeSpan TrenutnoVrijeme { get; set; }
        public bool IsGps { get; set; }

        public string PretragaNazivLokacija { get; set; }

        public bool IsPreporuka { get; set; }
        public int EventId { get; set; }
    }
}
