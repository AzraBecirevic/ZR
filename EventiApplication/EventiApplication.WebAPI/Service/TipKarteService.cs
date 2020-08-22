using AutoMapper;
using EventiApplication.Model;
using EventiApplication.Model.Request;
using EventiApplication.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventiApplication.WebAPI.Service
{
    public class TipKarteService : BaseCRUDService<Model.TipKarte, object, Database.TipKarte, TipKarteInsertRequest, object, object>
    {
        public TipKarteService(MojContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }

        public override Model.TipKarte Delete(int id)
        {
            if (_ctx.ProdajaTip.Where(p => p.TipKarteId == id).Count()>0)
                return null;
            return base.Delete(id);
        }

        public override Model.TipKarte Insert(TipKarteInsertRequest request)
        {
            if (_ctx.TipKarte.Where(t => t.Naziv.ToLower().Equals(request.Naziv.ToLower())).Count() > 0)
                return null;
            return base.Insert(request);
        }
    }
}
