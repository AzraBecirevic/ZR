using System;
using System.Collections.Generic;
using System.Text;

namespace EventiApplication.Model.Request
{
    public class PozivNaEventPatchRequest
    {
        public int Id { get; set; }
        public bool IsPrihvacen { get; set; }
        public bool IsOdbijen { get; set; }

    }
}
