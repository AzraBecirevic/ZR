using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model
{
    public class Recenzija
    {
        public int Id { get; set; }
     //   public int Ocjena { get; set; }
        public string Komentar { get; set; }
        public int KupovinaId { get; set; }
    }
}
