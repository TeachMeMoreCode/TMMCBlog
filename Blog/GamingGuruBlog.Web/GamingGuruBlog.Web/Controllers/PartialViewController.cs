using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
using GamingGuruBlog.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GamingGuruBlog.Web.Controllers
{
    public class PartialViewController : Controller
    {

        private IBlogPostRepository _blogPostRepo { get; set; }
        private IBlogCategoryRepository _blogCategoryRepo { get; set; }
        private IBlogTagRepository _blogTagRepo { get; set; }
        private ICategoryRepository _categoryRepo { get; set; }
        private ITagRepository _tagRepo { get; set; }
        private IUserRepository _userRepo { get; set; }
        private IStaticPageRepository _staticPageRepo { get; set; }


        public PartialViewController(IBlogPostRepository blogPostRepo, IUserRepository userRepo, IStaticPageRepository staticPageRepo, IBlogCategoryRepository blogCategoryRepo, IBlogTagRepository blogTagRepo, ICategoryRepository categoryRepo, ITagRepository tagRepo)
        {
            _blogPostRepo = blogPostRepo;
            _blogCategoryRepo = blogCategoryRepo;
            _blogTagRepo = blogTagRepo;
            _categoryRepo = categoryRepo;
            _tagRepo = tagRepo;
            _userRepo = userRepo;
            _staticPageRepo = staticPageRepo;
        }
        // GET: PartialView
        public PartialViewResult Action()
        {
            var model = _staticPageRepo.GetAllStaticPages();
            return PartialView("~/Views/Shared/_StaticPagePartial.cshtml", model);
        }

        public PartialViewResult FillWidgetWithData()
        {
            AllBlogPostsVM result = new AllBlogPostsVM();
            result.AllBlogPosts = _blogPostRepo.GetAllBlogPostsWithCategoriesAndTags();
            result.AllCategories = _categoryRepo.GetAllCategories();
            result.AllTags = _tagRepo.GetAllTags();


            return PartialView("~/Views/Shared/_BlogWidgetPartial.cshtml", result);
        }


        public List<StaticPage> StaticPages()
        {
            var model = _staticPageRepo.GetAllStaticPages();
            return model;
        }

        public PartialViewResult AdminPanelTabbedUsers()
        {
            var model = _userRepo.GetAllUsers();
            return PartialView("~/Views/PartialView/AdminPanelTabbedUsers.cshtml", model);
        }

    }
}