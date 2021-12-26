using BlogProjem.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjem.Controllers
{
    
    public class WriterController : Controller
    {
        WriterManager _writerManager = new WriterManager(new EFWriterRepository());
        Context c = new Context();

        [Authorize]
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            var usermail = User.Identity.Name;
            TempData["mail"] = usermail;

            var writername = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            TempData["name"] = writername;

            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
     
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            var wv = _writerManager.GGetById(writerId);
            return View(wv);
        }
       
        [HttpPost]
        public IActionResult WriterEditProfile( Writer writer)
        {
            WriterValidator wl = new WriterValidator();
            ValidationResult result = wl.Validate(writer);
            if (result.IsValid)
            {
                _writerManager.GUpdate(writer);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage writer)
        {
            Writer writermodel = new Writer();
            if (writer.WriterImage != null)
            {
                var path = Path.GetExtension(writer.WriterImage.FileName);
                var newimageName = Guid.NewGuid() + path;
                //Guid: Globally Unique Identifer benzersiz bir tanımlayıcı yapısı sağlar
                var pwd = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/WriterImage/", newimageName);
                var stream = new FileStream(pwd, FileMode.Create);
                writer.WriterImage.CopyTo(stream);
                writermodel.WriterImage = newimageName;
            }
            writermodel.WriterMail = writer.WriterMail;
            writermodel.WriterName = writer.WriterName;
            writermodel.WriterPassword  = writer.WriterPassword;
            writermodel.WriterStatus = writer.WriterStatus;
            writermodel.WriterAbout = writer.WriterAbout;

            _writerManager.GAdd(writermodel);
            return RedirectToAction("BlogListByWriter", "Blog");
        }


    }
}
