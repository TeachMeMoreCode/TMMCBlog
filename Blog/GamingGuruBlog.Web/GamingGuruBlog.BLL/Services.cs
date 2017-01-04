using GamingGuruBlog.Data.Interfaces;
using GamingGuruBlog.Data.Models;
using GamingGuruBlog.Web.Models;
using GamingGuruBlog;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GamingGuruBlog.BLL
{
    public class BlogServices
    {
        private IBlogPostRepository _blogPostRepo;
        private ICategoryRepository _categoryRepo;
        private IUserRepository _userRepo;
        private IBlogCategoryRepository _blogCategoryRepo;
        private IBlogTagRepository _blogTagRepo;
        private ITagRepository _tagRepo;

        public BlogServices (IBlogPostRepository blogPostRepository, ICategoryRepository categoryRepository, IUserRepository userRepository, IBlogCategoryRepository blogCategoryRepository, IBlogTagRepository blogTagRepo, ITagRepository tagRepo)
        {
            _blogPostRepo = blogPostRepository;
            _categoryRepo = categoryRepository;
            _userRepo = userRepository;
            _blogCategoryRepo = blogCategoryRepository;
            _blogTagRepo = blogTagRepo;
            _tagRepo = tagRepo;
        }

        public BlogPostVM GetReadPostVM(int id)
        {
            BlogPostVM populatedBlogPost = new BlogPostVM();
            populatedBlogPost.BlogPost = _blogPostRepo.GetBlogPost(id);
            populatedBlogPost.BlogPost.BlogPostId = id;
            populatedBlogPost.Categories = _categoryRepo.GetAllCategories();
            populatedBlogPost.Tags = _tagRepo.GetAllTags();
            return populatedBlogPost;
        }

        public BlogPostVM NewBlogPost()
        {
            var model = PopulatedCategorySelectListItem();
            model.BlogPost.DateCreatedUTC = DateTime.UtcNow;

            return model;
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
                returnedBlogPost.CategoryList.Add(categoryList);
            }

            return returnedBlogPost;

        }
    }
}