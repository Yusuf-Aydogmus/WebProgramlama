using BusinessLayer.Concrete;
using DataAccesLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjem.ViewComponets
{
    public class BlogListDashboard:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());

        public IViewComponentResult Invoke()
        {
            var blogs = blogManager.GetBlogListWithCategory().OrderByDescending(x => x.BlogCreateDate).Take(5).ToList();
            return View(blogs);
        }
    }
}
