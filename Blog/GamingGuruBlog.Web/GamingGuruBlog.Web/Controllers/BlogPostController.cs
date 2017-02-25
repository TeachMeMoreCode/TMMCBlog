using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
using GamingGuruBlog.Web.Models;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;

namespace GamingGuruBlog.Web.Controllers
{
    public class BlogPostController : Controller
    {
        private IBlogServices _blogServices;
        private ICategoryServices _categoryServices;

        public BlogPostController( IBlogServices newBlogServices, ICategoryServices newCategoryServices)
        {
            _blogServices = newBlogServices;
            _categoryServices = newCategoryServices;
        }

        [HttpGet]
        public ActionResult GetBlogPost(int id)
        {
            //TODO: check id is valid
            BlogPost existingPost = _blogServices.GetApprovedBlogPost(id);

            List<Category> allCategories = _categoryServices.GetAllCategories();
       
            var model = UIServices.ConvertBlogPostToVeiwModel(existingPost, allCategories);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Post()
        {
            BlogPost newPost = new BlogPost();
            newPost.UserId = User.Identity.GetUserId();
            List<Category> allCategories = _categoryServices.GetAllCategories();

            var model = UIServices.ConvertBlogPostToVeiwModel(newPost, allCategories);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Post(BlogPostVM newBlogPost)
        {
            if (ModelState.IsValid)
            {
                newBlogPost.BlogPost.DateCreatedUTC = DateTime.Now;
                BlogPost newPost = UIServices.ConvertBlogPostVMToBlogPost(newBlogPost);
                _blogServices.AddNewBlogPost(newPost);
                return RedirectToAction("AdminPanel", "Admin");
            }
            List<Category> allCategories = _categoryServices.GetAllCategories();
            var model = UIServices.ConvertBlogPostToVeiwModel(newBlogPost.BlogPost, allCategories);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            BlogPost existingPost = _blogServices.GetBlogPost(id);
            List<Category> allCategories = _categoryServices.GetAllCategories();
            BlogPostVM model = UIServices.ConvertBlogPostToVeiwModel(existingPost, allCategories);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(BlogPostVM editedBlogPostVM)
        {
            if (ModelState.IsValid)
            {
                BlogPost postToBeProcessed = UIServices.ConvertBlogPostVMToBlogPost(editedBlogPostVM);
                _blogServices.ProcessEditedBlogPost(postToBeProcessed);

                return RedirectToAction("AdminPanel", "Admin");
            }
            return View(editedBlogPostVM);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeleteBlog(int id)
        {
            _blogServices.DeleteBlogPost(id); //_blogPostRepo.DeleteBlogPost(id);
            return RedirectToAction("AdminPanel", "Admin");
        }

        [HttpGet]
        public ActionResult BlogPostsByCategory(int id, int? page)
        {
            var model = _blogServices.AllApprovedBlogPostsByCategoryID(id);
            return (View(model.ToPagedList(pageNumber: page ?? 1, pageSize: 5)));
        }

        [HttpGet]
        public ActionResult BlogPostsByTag(int id, int? page)
        {
            var model = _blogServices.AllApprovedBlogPostsByTag(id);
            return (View(model.ToPagedList(pageNumber: page ?? 1, pageSize: 5)));
        }

    }
}