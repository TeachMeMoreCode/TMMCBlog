using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
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
            var roles = _userServices.GetUserRoles();
            model.UserRoles = roles;

            return View(model);
        }

       [Authorize(Roles = "Admin")]
       [HttpPost]
       public JsonResult UserRole(SetRoleID input)
        {
            var user = _userServices.GetUser(input.UserId);
            if (user != null)
            {
                _userServices.EditUserRole(input);
            }
            var editedUser = _userServices.GetUser(input.UserId);

            return Json(editedUser);
        }

    }
}