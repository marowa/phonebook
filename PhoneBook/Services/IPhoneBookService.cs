using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook.Services
{
    public interface IPhoneBookService:IService<PhoneBookModel>
    {
        List<PhoneBookModel> SearchNumber(string search);
    }
}
