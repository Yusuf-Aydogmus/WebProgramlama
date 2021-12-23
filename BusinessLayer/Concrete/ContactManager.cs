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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;
        private DataAccesLayer.EntitiyFramework.EFContactRepository eFContactRepository;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public ContactManager(DataAccesLayer.EntitiyFramework.EFContactRepository eFContactRepository)
        {
            this.eFContactRepository = eFContactRepository;
        }

        public void ContactAdd(Contact contact)
        {
            _contactDal.Insert(contact);
        }
    }
}
