using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_Service_Abstraction
{
    public class Repository<T> : IRepository<T>
    {

        public Repository()
        { }

        public ICollection<T> GetAll()
        {
            return GetAll();
        }

        public T Detail(int id)
        {
            return Detail(id);
        }

        public T GetById(int id)
        {
            return GetById(id);
        }

        public T Create()
        {
            return Create();
        }

        public T Create(T t)
        {
            return Create(t);
        }

        public void Delete(int id)
        {
            Delete(id);
        }

        public void Update(int id)
        {
            Update(id);
        }

    }
}
