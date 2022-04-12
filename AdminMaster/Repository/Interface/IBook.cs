using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminMaster.Repository.Interface
{
    public interface IBook
    {
        bool DeleteBook(int id);
    }
    public interface GenericInterface<T>
    {
        List<T> Getdata();
    }
}
