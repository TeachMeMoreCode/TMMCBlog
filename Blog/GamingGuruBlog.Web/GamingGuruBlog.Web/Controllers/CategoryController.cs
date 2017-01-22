using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
using System;
using System.Web.Mvc;

namespace GamingGuruBlog.Web.Controllers
{
    public class CategoryController : Controller
    {

        private ICategoryRepository _categoryRepo { get; set; }


        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
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
            var model = _categoryRepo.GetCategory(id);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditCategory(Category newCategory)
        {
            try
            {
                _categoryRepo.EditCategory(newCategory);
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
                _categoryRepo.AddCategory(newCategory);
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
                _categoryRepo.DeleteCategory(id);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}