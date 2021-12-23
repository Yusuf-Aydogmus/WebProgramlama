using BusinessLayer.Concrete;
using DataAccesLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjem.ViewComponets.Category
{
    public class CategoryList : ViewComponent
    {

        CategoryManager cm_ = new CategoryManager(new EFCategoryRepository());

        public IViewComponentResult Invoke()
        {
            var values = cm_.GGetList();
            return View(values);
        }
    }
}