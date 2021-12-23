using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjem.Controllers
{
    
    public class WriterController : Controller
    {
        WriterManager _writerManager = new WriterManager(new EFWriterRepository());

     
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
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var wv = _writerManager.GGetById(2);
            return View(wv);
        }
        [AllowAnonymous]
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

    }
}
