using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public interface IService<T>
    {
        List<T> GetAll();
        T GetDataByID(int ID);
        int Insert(T t);
        int Update(T t);
        int Delete(int ID);
    }
}
