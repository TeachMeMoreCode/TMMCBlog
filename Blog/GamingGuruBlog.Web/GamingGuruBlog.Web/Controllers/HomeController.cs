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
        private IBlogPostRepository _blogPostRepo { get; set; }
        private IBlogCategoryRepository _blogCategoryRepo { get; set; }
        private IBlogTagRepository _blogTagRepo { get; set; }
        private ICategoryRepository _categoryRepo { get; set; }
        private ITagRepository _tagRepo { get; set; }
        private IUserRepository _userRepo { get; set; }


        public HomeController(IBlogPostRepository blogPostRepo, IUserRepository userRepo, IBlogCategoryRepository blogCategoryRepo, IBlogTagRepository blogTagRepo, ICategoryRepository categoryRepo, ITagRepository tagRepo)
        {
            _blogPostRepo = blogPostRepo;
            _blogCategoryRepo = blogCategoryRepo;
            _blogTagRepo = blogTagRepo;
            _categoryRepo = categoryRepo;
            _tagRepo = tagRepo;
            _userRepo = userRepo;
        }


        public ActionResult Index(int? page)
        {
            
            List<BlogPost> allBlogPosts = _blogPostRepo.GetAllBlogPostsWithCategoriesAndTags();
            return (View(allBlogPosts.ToPagedList(pageNumber: page ?? 1, pageSize:5)));
        }


        public AllBlogPostsVM GetAllBlogPostsVM()
        {
            AllBlogPostsVM allBlogPosts = new AllBlogPostsVM();
            allBlogPosts.AllBlogPosts = _blogPostRepo.GetAllBlogPostsWithCategoriesAndTags();
            allBlogPosts.AllCategories = _categoryRepo.GetAllCategories();
            allBlogPosts.AllTags = _tagRepo.GetAllTags();


            return allBlogPosts;
        }

    }
}