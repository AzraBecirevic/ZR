using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventiApplication.WebAPI.Database
{
    public class Data
    {
        public static void Seed (MojContext context)
        {
            context.Database.Migrate();
            DataInit.DopunaSlike(context);
        }
    }
}
