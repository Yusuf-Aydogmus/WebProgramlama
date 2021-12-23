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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public List<Writer> GetWriterByID(int id)
        {
            return _writerDal.GetListAll(x => x.WriterID == id);
        }

        public void GAdd(Writer t)
        {
            _writerDal.Insert(t);
        }

        public void GDelete(Writer t)
        {
            throw new NotImplementedException();
        }

        public void GUpdate(Writer t)
        {
            _writerDal.Update(t);
        }
        public Writer GGetById(int id)
        {
           return _writerDal.GetByID(id);

        }

        public List<Writer> GGetList()
        {
            throw new NotImplementedException();
        }

    }
}
