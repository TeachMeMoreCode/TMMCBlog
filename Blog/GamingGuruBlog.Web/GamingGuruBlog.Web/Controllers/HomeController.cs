using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
using GamingGuruBlog.Web.Models;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GamingGuruBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private IBlogServices _blogServices;

        public HomeController(IBlogServices newBlogServices)
        {
            _blogServices = newBlogServices;
        }

        [HttpGet]
        public ActionResult Index(int? page)
        {
            List<BlogPost> allBlogPosts = _blogServices.GetAllBlogPosts();
            return (View(allBlogPosts.ToPagedList(pageNumber: page ?? 1, pageSize:5)));
        }

        [HttpGet]
        public AllBlogPostsVM GetAllBlogPostsVM()
        {
            AllBlogPostsVM allBlogPosts = new AllBlogPostsVM();
            allBlogPosts.AllBlogPosts = _blogServices.GetAllBlogPosts();
            allBlogPosts.AllCategories = _blogServices.GetAllCategories();
            allBlogPosts.AllTags = _blogServices.GetAllTags();

            return allBlogPosts;
        }

    }
}