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
        private IBlogPostRepository _blogPostRepo;
        private ICategoryRepository _categoryRepo;
        private IUserRepository _userRepo;
        private IBlogCategoryRepository _blogCategoryRepo;
        private IBlogTagRepository _blogTagRepo;
        private ITagRepository _tagRepo;

        private IBlogServices _blogServices;

        public BlogPostController(IBlogPostRepository blogPostRepository, ICategoryRepository categoryRepository, IUserRepository userRepository, IBlogCategoryRepository blogCategoryRepository, IBlogTagRepository blogTagRepo, ITagRepository tagRepo, IBlogServices newBlogServices)
        {
            _blogPostRepo = blogPostRepository;
            _categoryRepo = categoryRepository;
            _userRepo = userRepository;
            _blogCategoryRepo = blogCategoryRepository;
            _blogTagRepo = blogTagRepo;
            _tagRepo = tagRepo;
            _blogServices = newBlogServices;

        }

        [HttpGet]
        public ActionResult GetBlogPost(int id)
        {
            //TODO: check id is valid
            BlogPost existingPost = _blogServices.GetBlogPost(id);
            List<Category> allCategories = _blogServices.GetAllCategories();
            List<Tag> allTags = _blogServices.GetAllTags();
       
            var model = WebServices.ConvertBlogPostToVeiwModel(existingPost, allCategories, allTags);

            return View(model);
        }

        // GET: BlogPost
        [Authorize(Roles = "Admin")]
        public ActionResult Post()
        {
            BlogPost newPost = new BlogPost();
            newPost.DateCreatedUTC = DateTime.UtcNow;
            newPost.UserId = User.Identity.GetUserId();
            List<Category> allCategories = _blogServices.GetAllCategories();
            List<Tag> allTags = _blogServices.GetAllTags();

            var model = WebServices.ConvertBlogPostToVeiwModel(newPost, allCategories, allTags);

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

                    
                    //_blogPostRepo.AddBlogPost(newBlogPost.BlogPost);

                //foreach (var category in newBlogPost.ChosenCategoriesArray)
                //{
                //    _blogCategoryRepo.AddCategoryToBlog(blogId, int.Parse(category));
                //}

                //string[] postTags = newBlogPost.Tag.TagName.ToLower().Split(' ');
                //newBlogPost.Tags = _tagRepo.AddAllTags(postTags);

                //foreach (var tag in newBlogPost.Tags)
                //{
                //    _blogTagRepo.AddTagToBlog(blogId, tag.TagId);
                //}

                return RedirectToAction("Index", "Home");
            }
            return View(PopulatedCategorySelectListItem(newBlogPost));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {

            BlogPost existingPost = _blogServices.GetBlogPost(id);
            List<Category> allCategories = _blogServices.GetAllCategories();
            List<Tag> allTags = _blogServices.GetAllTags();

            BlogPostVM model = WebServices.ConvertBlogPostToVeiwModel(existingPost, allCategories, allTags);

            //var model = PopulatedCategorySelectListItem();
            //model.BlogPost = _blogPostRepo.GetBlogPost(id);
            //model.TagString = string.Join(" ", model.BlogPost.AssignedTags.Select(assignedTag => assignedTag.TagName));
            //model.BlogPost.EditDate = DateTime.UtcNow;

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(BlogPostVM editedBlogPostVM)
        {
            if (ModelState.IsValid)
            {
                BlogPost postToBeProcessed = WebServices.ConvertBlogPostVMToBlogPost(editedBlogPostVM);
                _blogServices.ToString // to be continued

                _blogPostRepo.EditBlogPost(editedBlogPostVM.BlogPost);
                var blogPostID = editedBlogPostVM.BlogPost.BlogPostId;
                _blogCategoryRepo.DeleteCategoryFromBlogPost(blogPostID);

                foreach (var category in editedBlogPostVM.ChosenCategoriesArray)
                {
                    _blogCategoryRepo.AddCategoryToBlog(blogPostID, int.Parse(category));
                }

                string[] postTags = editedBlogPostVM.Tag.TagName.ToLower().Split(' ');
                editedBlogPostVM.Tags = _tagRepo.AddAllTags(postTags);
                _blogTagRepo.DeleteTagFromBlog(blogPostID);
                foreach (var tag in editedBlogPostVM.Tags)
                {
                    _blogTagRepo.AddTagToBlog(blogPostID, tag.TagId);
                }

                return RedirectToAction("Index", "Home");
            }
            return View(editedBlogPostVM);

        }

        public ActionResult BlogPostsByCategory(int id, int? page)
        {
            var model = _blogPostRepo.GetAllPostsByCategory(id);
            return (View(model.ToPagedList(pageNumber: page ?? 1, pageSize: 5)));
        }

        public ActionResult BlogPostsByTag(int id, int? page)
        {

            var model = _blogPostRepo.GetAllBlogPostsByTag(id);

            return (View(model.ToPagedList(pageNumber: page ?? 1, pageSize: 5)));
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeleteBlog(int id)
        {
            _blogPostRepo.DeleteBlogPost(id);
            return RedirectToAction("AdminPanel", "Admin");
        }


        public BlogPostVM GetSinglePostVM(int id)
        {
            BlogPostVM populatedBlogPost = new BlogPostVM();
            populatedBlogPost.BlogPost = _blogPostRepo.GetBlogPost(id);
            populatedBlogPost.BlogPost.BlogPostId = id;
            populatedBlogPost.AllCategories = _categoryRepo.GetAllCategories();
            // populatedBlogPost.Tags = _tagRepo.GetAllTags(); I don't think this is used in the UI. the AllBlogPostsVM is used in the partial view
            return populatedBlogPost;
        }

        private BlogPostVM PopulatedCategorySelectListItem()
        {
            BlogPostVM blogPostVM = new BlogPostVM();
            return PopulatedCategorySelectListItem(blogPostVM);
        }

        private BlogPostVM PopulatedCategorySelectListItem(BlogPostVM returnedBlogPost)
        {

            var categoryListItems = _categoryRepo.GetAllCategories();

            foreach (var category in categoryListItems)
            {
                SelectListItem categoryList = new SelectListItem()
                {
                    Text = category.CategoryName,
                    Value = category.CategoryId.ToString()
                };
                returnedBlogPost.CategorySelectListItemList.Add(categoryList);
            }

            return returnedBlogPost;
        }
    }
}