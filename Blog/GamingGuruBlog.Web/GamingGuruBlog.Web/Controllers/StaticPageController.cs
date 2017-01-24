using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace GamingGuruBlog.Web.Controllers
{
    public class StaticPageController : Controller
    {
        private IStaticPageServices _staticPageServices;

        public StaticPageController(IStaticPageServices newStaticPageServices)
        {
            _staticPageServices = newStaticPageServices;
        }

        public ActionResult StaticPage(int id)
        {
            StaticPage model = _staticPageServices.GetStaticPage(id);
            return View(model);
        }

        //GET
        public ActionResult EditStaticPage(int id)
        {
            StaticPage model = _staticPageServices.GetStaticPage(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditStaticPage(StaticPage updatedStaticPage)
        {
            _staticPageServices.EditStaticPage(updatedStaticPage);
            return RedirectToAction("AdminPanel", "Admin");
        }

        [HttpPost]
        public ActionResult DeleteStaticPage(int id)
        {
            _staticPageServices.DeleteStaticPage(id);
            return RedirectToAction("AdminPanel", "Admin");
        }

        public ActionResult AddStaticPage()
        {
            StaticPage model = new StaticPage();
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
                    _staticPageServices.AddStaticPage(newStaticPage);
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