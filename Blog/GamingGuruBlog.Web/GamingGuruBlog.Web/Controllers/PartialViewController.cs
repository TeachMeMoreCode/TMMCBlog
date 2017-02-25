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
        private ICategoryServices _categoryServices;
        private ITagServices _tagServices;
        private IUserServices _userServices;


        public PartialViewController(IBlogServices newBlogservices, IStaticPageServices newStaticPageServices, ICategoryServices newCategoryServices, ITagServices newTagServices, IUserServices newUserServices)
        {
            _blogServices = newBlogservices;
            _staticPageServices = newStaticPageServices;
            _categoryServices = newCategoryServices;
            _tagServices = newTagServices;
            _userServices = newUserServices;
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
            result.AllCategories = _categoryServices.GetUsedCategories();
            result.AllTags = _tagServices.GetAllTags();

            return PartialView("~/Views/Shared/_BlogWidgetPartial.cshtml", result);
        }

        public PartialViewResult AdminPanelTabbedUsers()
        {
            var model = _userServices.GetAllUsers();
            return PartialView("~/Views/PartialView/AdminPanelTabbedUsers.cshtml", model);
        }

    }
}