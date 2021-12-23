using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutdal;

        public AboutManager(IAboutDal aboutdal)
        {
            _aboutdal = aboutdal;
        }

        public void GAdd(About t)
        {
            _aboutdal.Insert(t);
        }

        public void GDelete(About t)
        {
            _aboutdal.Delete(t);
        }

        public About GGetById(int id)
        {
          return  _aboutdal.GetByID(id);
        }

        public List<About> GGetList()
        {
            return _aboutdal.GetListAll();
        }

        public void GUpdate(About t)
        {
            _aboutdal.Update(t);
        }
    }
}