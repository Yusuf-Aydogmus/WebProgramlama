using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjem.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());
        public IActionResult Index() //userlayoutu layout sayfası olarak tanımladık burada
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = blogManager.GetBlogById(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var values = blogManager.GetListWithCategoryByWriterBM(2);

            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            GetCategoryList();
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(blog);
            if (results.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = 2;
                blogManager.GAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
           GetCategoryList();
            return View();
        }

        public void GetCategoryList()
        {
            CategoryManager cm = new CategoryManager(new EFCategoryRepository());
            List<SelectListItem> CategoryValues = (from x in cm.GGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.CategoryList = CategoryValues;
        }
        public IActionResult DeleteBlog(int id)
        {
            var deletingBlog = blogManager.GGetById(id);
            blogManager.GDelete(deletingBlog);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {

            var editingBlog = blogManager.GGetById(id);
            GetCategoryList();
            return View(editingBlog);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            blog.WriterID = 2;
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            blogManager.GUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
