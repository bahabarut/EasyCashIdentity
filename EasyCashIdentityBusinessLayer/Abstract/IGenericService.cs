using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityBusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TAdd(T t);
        void TUpdate(T t);
        void TDelete(T t);
        T TGetById(int id);
        List<T> TGetList();
    }
}
