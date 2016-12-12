using GamingGuruBlog.Data.Interfaces;
using GamingGuruBlog.Data.Models;
using GamingGuruBlog.Web.Models;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamingGuruBlog.Web.Controllers
{
    public class AdminController : Controller
    {

        private IBlogPostRepository _blogPostRepo { get; set; }
        private IBlogCategoryRepository _blogCategoryRepo { get; set; }
        private IBlogTagRepository _blogTagRepo { get; set; }
        private ICategoryRepository _categoryRepo { get; set; }
        private ITagRepository _tagRepo { get; set; }
        private IUserRepository _userRepo { get; set; }
        private IStaticPageRepository _staticPageRepo { get; set; }



        public AdminController(IBlogPostRepository blogPostRepo, IUserRepository userRepo, IStaticPageRepository staticPageRepo,IBlogCategoryRepository blogCategoryRepo, IBlogTagRepository blogTagRepo, ICategoryRepository categoryRepo, ITagRepository tagRepo)
        {
            _blogPostRepo = blogPostRepo;
            _blogCategoryRepo = blogCategoryRepo;
            _blogTagRepo = blogTagRepo;
            _categoryRepo = categoryRepo;
            _tagRepo = tagRepo;
            _userRepo = userRepo;
            _staticPageRepo = staticPageRepo;
        }

        // GET: Admin
        [Authorize(Roles ="Admin")]
        public ActionResult AdminPanel()
        {      
            AdminPanelVM model = new AdminPanelVM();
            model.Users = _userRepo.GetAllUsers();
            model.Categories = _categoryRepo.GetAllCategories();
            model.StaticPages = _staticPageRepo.GetAllStaticPages();
            model.BlogPosts = _blogPostRepo.GetAllBlogPostsWithCategoriesAndTags();

            return View(model);
        }

       

    }
}