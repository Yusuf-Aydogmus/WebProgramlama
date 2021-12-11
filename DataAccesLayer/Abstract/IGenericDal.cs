using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    //T-->entitty bir clasa ait tüm nitelikleri kullanacak
  public  interface IGenericDal<T>where T:class
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetListAll();
        T GetByID(int id);



    }
}
