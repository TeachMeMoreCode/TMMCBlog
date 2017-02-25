using System.Web.Mvc;
using GamingGuruBlog.Domain.Models;
using GamingGuruBlog.Domain.Interfaces;

namespace GamingGuruBlog.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserServices _userServices;

        public UserController(IUserServices newUserServices)
        {
            _userServices = newUserServices;
        }

        // GET: User
        public ActionResult GetUser(string id)
        {
            _userServices.GetUser(id);
            return View();
        }

        public ActionResult EditUser(string id)
        {
            var model = _userServices.GetUser(id);
            return View(model);            
        }

        [HttpPost]
        public ActionResult EditUser(User editedUser)
        {
                _userServices.EditUser(editedUser);
                return RedirectToAction("Index", "Home");
        }
    }
}