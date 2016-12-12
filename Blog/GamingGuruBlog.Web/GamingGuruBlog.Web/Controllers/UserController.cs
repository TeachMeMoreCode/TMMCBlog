using GamingGuruBlog.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using GamingGuruBlog.Data.Models;

namespace GamingGuruBlog.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepo;
        private IBlogCategoryRepository _blogCategoryRepo;
        private IBlogPostRepository _blogPostRepo;
        private ICategoryRepository _categoryRepo;
        private ITagRepository _tagRepo;
        private IBlogTagRepository _blogTagRepo;
        private IStaticPageRepository _staticPageRepo;

        public UserController(IUserRepository userRepo, IBlogCategoryRepository blogCategoryRepo, IBlogPostRepository blogPostRepo, ICategoryRepository categoryRepo, ITagRepository tagRepo, IBlogTagRepository blogTagRepo, IStaticPageRepository staticPageRepo)
        {
            _userRepo = userRepo;
            _blogCategoryRepo = blogCategoryRepo;
            _blogPostRepo = blogPostRepo;
            _categoryRepo = categoryRepo;
            _tagRepo = tagRepo;
            _blogTagRepo = blogTagRepo;
            _staticPageRepo =staticPageRepo;
        }

        // GET: User
        public ActionResult GetUser(string id)
        {
            _userRepo.GetUser(id);
            return View();
        }

        public ActionResult EditUser(string id)
        {
            var model = _userRepo.GetUser(id);
            return View(model);            
        }

        [HttpPost]
        public ActionResult EditUser(User editedUser)
        {
            _userRepo.EditUser(editedUser);
            return RedirectToAction("Index", "Home");

        }

        //GET
        //public ActionResult AdminPanel()
        //{

        //}
    }
}