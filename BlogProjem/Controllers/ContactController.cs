
using BusinessLayer.Concrete;
using DataAccesLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjem.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact m)
        {
            m.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.ContactStatus = true;
            cm.ContactAdd(m);
            return RedirectToAction("Index", "Blog");

        }
    }
}