using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class DatumPSearchRequest
    {
        public DateTime IzabraniDatum { get; set; }
        public int ProstorOdrzavanjaId { get; set; }
        public int KategorijaId { get; set; }
        public TimeSpan VrijemeEventa { get; set; }
    }
}
