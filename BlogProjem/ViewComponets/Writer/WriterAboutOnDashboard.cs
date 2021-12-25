using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjem.ViewComponets.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {

            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            var abouts = writerManager.GetWriterByID(writerId);
            return View(abouts);
        }

    }
}
