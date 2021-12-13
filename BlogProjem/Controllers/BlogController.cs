using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjem.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index() //userlayoutu layout sayfası olarak tanımladık burada
        {
            return View();
        }
    }
}
