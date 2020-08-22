using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventiApplication.WebAPI.Service
{
    public interface ICRUDService<T, TSearch, TInsert, TUpdate, TPatch> : IService<T,TSearch>
    {
        public T Insert(TInsert request);
        public T Update(int id, TUpdate request);

        public T Delete(int id);
        public T Autentificiraj(string username, string password);
                        
        public T UpdateAttribute( TPatch vrijednost);

    }
}
