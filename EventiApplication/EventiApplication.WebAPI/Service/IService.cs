using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventiApplication.WebAPI.Service
{
    public interface IService<T, TSearch>
    {
        public List<T> Get(TSearch search);

        public T GetById(int id);
    }
}
