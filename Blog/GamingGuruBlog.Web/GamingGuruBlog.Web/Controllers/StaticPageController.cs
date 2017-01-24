using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace GamingGuruBlog.Web.Controllers
{
    public class StaticPageController : Controller
    {

        private IBlogPostRepository _blogPostRepo { get; set; }
        private IBlogCategoryRepository _blogCategoryRepo { get; set; }
        private IBlogTagRepository _blogTagRepo { get; set; }
        private ICategoryRepository _categoryRepo { get; set; }
        private ITagRepository _tagRepo { get; set; }
        private IUserRepository _userRepo { get; set; }
        private IStaticPageRepository _staticPageRepo { get; set; }

        private IBlogServices _blogServices;


        public StaticPageController(IStaticPageRepository staticPageRepo)
        {
            _staticPageRepo = staticPageRepo;
        }

        public ActionResult StaticPage(int id)
        {
            var model = _staticPageRepo.GetStaticPage(id);
            return View(model);
        }

        //GET
        public ActionResult EditStaticPage(int id)
        {
            var model = _staticPageRepo.GetStaticPage(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditStaticPage(StaticPage updatedStaticPage)
        {
            _staticPageRepo.EditStaticPage(updatedStaticPage);
            return RedirectToAction("AdminPanel", "Admin");
        }

        [HttpPost]
        public ActionResult DeleteStaticPage(int id)
        {
            _staticPageRepo.DeleteStaticPage(id);
            return RedirectToAction("AdminPanel", "Admin");
        }

        public ActionResult AddStaticPage()
        {
            var model = new StaticPage();
            model.UserId = User.Identity.GetUserId();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddStaticPage(StaticPage newStaticPage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _staticPageRepo.AddStaticPage(newStaticPage);
                    return RedirectToAction("Index", "Home");
                }
                var model = new StaticPage();
                return View(model);
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}