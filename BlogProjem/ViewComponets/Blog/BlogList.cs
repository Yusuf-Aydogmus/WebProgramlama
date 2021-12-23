
using BusinessLayer.Concrete;
using DataAccesLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjem.ViewComponets.Blog
{
    public class BlogList : ViewComponent
    {

        BlogManager _bm = new BlogManager(new EFBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = _bm.GetBlogListWithCategory();
            return View(values);
        }
    }
}