using BusinessLayer.Concrete;
using DataAccesLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjem.Controllers
{
    public class CommentController : Controller
    {
       CommentManager cm = new CommentManager(new EFCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialAddComment()
        {

            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
        {

           var values= cm.GetList(id);
            return PartialView(values);
        }

    }
}
