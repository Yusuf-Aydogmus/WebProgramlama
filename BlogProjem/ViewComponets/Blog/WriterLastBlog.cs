
using BusinessLayer.Concrete;
using DataAccesLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjem.ViewComponets.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());

        public IViewComponentResult Invoke(int id)
        {
            var values = bm.GetBlogListByWriter(id);
            return View(values);
        }
    }
}