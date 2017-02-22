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
        private ITagServices _tagServices;


        public PartialViewController(IBlogServices newBlogservices, IStaticPageServices newStaticPageServices, ITagServices newTagServices)
        {
            _blogServices = newBlogservices;
            _staticPageServices = newStaticPageServices;
            _tagServices = newTagServices;
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
            result.AllCategories = _blogServices.GetUsedCategories();
            result.AllTags = _tagServices.GetAllTags();

            return PartialView("~/Views/Shared/_BlogWidgetPartial.cshtml", result);
        }

        public PartialViewResult AdminPanelTabbedUsers()
        {
            var model = _blogServices.GetAllUsers();
            return PartialView("~/Views/PartialView/AdminPanelTabbedUsers.cshtml", model);
        }

    }
}