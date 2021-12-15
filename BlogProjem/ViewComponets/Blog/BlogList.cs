using BusinessLayer.Concrete;
using DataAccesLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjem.ViewComponets.Blog
{
    public class BlogList:ViewComponent
    {

        BlogManager bm_ = new BlogManager(new EFBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = bm_.GetList();
            return View(values);
        }
    }
}
