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
    public class CommentController : Controller
    {
       CommentManager cm = new CommentManager(new EFCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {

            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment q)
        {
            q.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            q.CommentStatus = true;
            q.BlogID = 2;
            cm.CommentAdd(q);
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
        {

           var values= cm.GetList(id);
            return PartialView(values);
        }

    }
}
