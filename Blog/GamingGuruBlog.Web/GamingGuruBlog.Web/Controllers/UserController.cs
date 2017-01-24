using System.Web.Mvc;
using GamingGuruBlog.Domain.Models;
using GamingGuruBlog.Domain.Interfaces;

namespace GamingGuruBlog.Web.Controllers
{
    public class UserController : Controller
    {
        private IBlogServices _blogServices;

        public UserController(IBlogServices newBlogServices)
        {
            _blogServices = newBlogServices;
        }

        // GET: User
        public ActionResult GetUser(string id)
        {
            _blogServices.GetUser(id);
            return View();
        }

        public ActionResult EditUser(string id)
        {
            var model = _blogServices.GetUser(id);
            return View(model);            
        }

        [HttpPost]
        public ActionResult EditUser(User editedUser)
        {
                _blogServices.EditUser(editedUser);
                return RedirectToAction("Index", "Home");
        }
    }
}