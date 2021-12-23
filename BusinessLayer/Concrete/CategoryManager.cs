using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntitiyFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    //business katmanında abstract klasörü içerisindeki kalsörler servistir
    //business katmanında conrete klasörü içerisindeki yer alan sınıflar manager olarak adlandırılır.
    //Business katmanın içerisinde validation yapılacak geçerlilik kuralları
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void GAdd(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void GDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public Category GGetById(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<Category> GGetList()
        {
            return _categoryDal.GetListAll();
        }

        public void GUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}