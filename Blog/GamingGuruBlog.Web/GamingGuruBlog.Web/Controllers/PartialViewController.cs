using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
using GamingGuruBlog.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GamingGuruBlog.Web.Controllers
{
    public class PartialViewController : Controller
    {
        private IBlogServices _blogServices;
        private IStaticPageServices _staticPageServices;


        public PartialViewController(IStaticPageServices newStaticPageServices, IBlogServices newBlogservices)
        {
            _blogServices = newBlogservices;
            _staticPageServices = newStaticPageServices;
        }
        // GET: PartialView
        public PartialViewResult Action()
        {
            var model = _staticPageServices.GetAllStaticPages();
            return PartialView("~/Views/Shared/_StaticPagePartial.cshtml", model);
        }

        public PartialViewResult FillWidgetWithData()
        {
            AllBlogPostsVM result = new AllBlogPostsVM();
            result.AllBlogPosts = _blogServices.GetAllBlogPosts();
            result.AllCategories = _blogServices.GetAllCategories();
            result.AllTags = _blogServices.GetAllTags();

            return PartialView("~/Views/Shared/_BlogWidgetPartial.cshtml", result);
        }

        public PartialViewResult AdminPanelTabbedUsers()
        {
            var model = _blogServices.GetAllUsers();
            return PartialView("~/Views/PartialView/AdminPanelTabbedUsers.cshtml", model);
        }

    }
}