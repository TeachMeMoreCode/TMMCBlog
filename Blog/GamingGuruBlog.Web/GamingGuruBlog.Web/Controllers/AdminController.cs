using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Web.Models;
using System.Web.Mvc;

namespace GamingGuruBlog.Web.Controllers
{
    public class AdminController : Controller
    {
        private IBlogServices _blogServices;
        private IStaticPageServices _staticPageServices;

        public AdminController(IBlogServices newBlogServices, IStaticPageServices newStaticPageServices)
        {
            _blogServices = newBlogServices;
            _staticPageServices = newStaticPageServices;
        }

        // GET: Admin
        [Authorize(Roles ="Admin")]
        public ActionResult AdminPanel()
        {      
            AdminPanelVM model = new AdminPanelVM();
            model.Users = _blogServices.GetAllUsers();
            model.Categories = _blogServices.GetAllCategories();
            model.StaticPages = _staticPageServices.GetAllStaticPages();
            model.BlogPosts = _blogServices.GetAllBlogPosts();

            return View(model);
        }

       

    }
}