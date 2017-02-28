using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Web.Models;
using System.Web.Mvc;

namespace GamingGuruBlog.Web.Controllers
{
    public class AdminController : Controller
    {
        private IBlogServices _blogServices;
        private IStaticPageServices _staticPageServices;
        private ICategoryServices _categoryServices;
        private IUserServices _userServices;

        public AdminController(IBlogServices newBlogServices, IStaticPageServices newStaticPageServices, ICategoryServices newCategoryServices, IUserServices newUserServices)
        {
            _blogServices = newBlogServices;
            _staticPageServices = newStaticPageServices;
            _categoryServices = newCategoryServices;
            _userServices = newUserServices;
        }

        // GET: Admin
        [Authorize(Roles ="Admin")]
        public ActionResult AdminPanel()
        {      
            AdminPanelVM model = new AdminPanelVM();

            model.Users = _userServices.GetAllUsers();
            model.Categories = _categoryServices.GetAllCategories();
            model.StaticPages = _staticPageServices.GetAllStaticPages();
            model.BlogPosts = _blogServices.GetAllBlogPosts();

            return View(model);
        }

       

    }
}