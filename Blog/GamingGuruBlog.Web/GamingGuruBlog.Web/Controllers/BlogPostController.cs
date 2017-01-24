using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
using GamingGuruBlog.Domain;
using GamingGuruBlog.Web.Models;
using GamingGuruBlog;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace GamingGuruBlog.Web.Controllers
{
    public class BlogPostController : Controller
    {
        private IBlogServices _blogServices;

        public BlogPostController( IBlogServices newBlogServices)
        {
            _blogServices = newBlogServices;
        }

        [HttpGet]
        public ActionResult GetBlogPost(int id)
        {
            //TODO: check id is valid
            BlogPost existingPost = _blogServices.GetBlogPost(id);
            List<Category> allCategories = _blogServices.GetAllCategories();
       
            var model = WebServices.ConvertBlogPostToVeiwModel(existingPost, allCategories);

            return View(model);
        }

        // GET: BlogPost
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Post()
        {
            BlogPost newPost = new BlogPost();
            newPost.DateCreatedUTC = DateTime.UtcNow;
            newPost.UserId = User.Identity.GetUserId();
            List<Category> allCategories = _blogServices.GetAllCategories();

            var model = WebServices.ConvertBlogPostToVeiwModel(newPost, allCategories);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Post(BlogPostVM newBlogPost)
        {
            if (ModelState.IsValid)
            {
                BlogPost newPost = WebServices.ConvertBlogPostVMToBlogPost(newBlogPost);
                int blogId = _blogServices.AddNewBlogPost(newPost);

                _blogServices.AddCategoriesToBlogPost(blogId, newPost.AssignedCategories);

                List<Tag> newTags = _blogServices.AddCreatedTags(newPost.AssignedTags);

                _blogServices.AddTagsToBlog(blogId, newTags);

                return RedirectToAction("AdminPanel", "Admin");
            }
            List<Category> allCategories = _blogServices.GetAllCategories();
            var model = WebServices.ConvertBlogPostToVeiwModel(newBlogPost.BlogPost, allCategories);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {

            BlogPost existingPost = _blogServices.GetBlogPost(id);
            List<Category> allCategories = _blogServices.GetAllCategories();
            BlogPostVM model = WebServices.ConvertBlogPostToVeiwModel(existingPost, allCategories);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(BlogPostVM editedBlogPostVM)
        {
            if (ModelState.IsValid)
            {
                BlogPost postToBeProcessed = WebServices.ConvertBlogPostVMToBlogPost(editedBlogPostVM);
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
            var model = _blogServices.GetBlogPostByCategoryID(id);
            return (View(model.ToPagedList(pageNumber: page ?? 1, pageSize: 5)));
        }

        [HttpGet]
        public ActionResult BlogPostsByTag(int id, int? page)
        {
            var model = _blogServices.AllBlogPostsByTag(id);
            return (View(model.ToPagedList(pageNumber: page ?? 1, pageSize: 5)));
        }

    }
}