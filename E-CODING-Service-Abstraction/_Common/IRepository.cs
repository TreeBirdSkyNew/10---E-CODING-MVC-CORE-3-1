using System;
using System.Collections.Generic;

namespace E_CODING_Service_Abstraction
{
    public interface IRepository<T>
    {
        ICollection<T> GetAll();
        T GetById(int id);
        T Create();
        T Create(T t);
        void Delete(int id);
        T Detail(int id);
        void Update(int id);
    }
}
