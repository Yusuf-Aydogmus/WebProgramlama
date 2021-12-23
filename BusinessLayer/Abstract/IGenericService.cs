using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IGenericService<T>//Bir t parametresi ile Entity alacak(category,blog)
    {
        void GAdd(T t);
        void GDelete(T t);
        void GUpdate(T t);
        List<T> GGetList();
        T GGetById(int id);
    }
}
