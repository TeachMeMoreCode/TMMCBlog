using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
using System;
using System.Web.Mvc;

namespace GamingGuruBlog.Web.Controllers
{
    public class CategoryController : Controller
    {

        private IBlogServices _blogServices;

        public CategoryController(IBlogServices newBlogServices)
        {
            _blogServices = newBlogServices;
        }

        // GET: Category
        [Authorize(Roles = "Admin")]
        public ActionResult AddCategory()
        {
            var model = new Category();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditCategory(int id)
        {
            var model = _blogServices.GetCategory(id);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditCategory(Category newCategory)
        {
            try
            {
                _blogServices.EditCategory(newCategory);
                return RedirectToAction("AdminPanel", "Admin");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddCategory(Category newCategory)
        {
            if (newCategory == null || string.IsNullOrEmpty(newCategory.CategoryName))
            {
                throw new ArgumentException();
            }
            try
            {
                _blogServices.AddCategory(newCategory);
                return RedirectToAction("AdminPanel", "Admin");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteCategory(int id)
        {
            try
            {
                _blogServices.DeleteCategory(id);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}