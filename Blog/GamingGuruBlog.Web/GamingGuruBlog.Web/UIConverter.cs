﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamingGuruBlog.Domain;
using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
using GamingGuruBlog.Web.Models;
using System.Web.Mvc;

namespace GamingGuruBlog.Web
{
    public class UIConverter
    {
        private IBlogServices _blogServices;

        public UIConverter(IBlogServices _passedInServices)
        {
            _blogServices = _passedInServices;
        }


        public BlogPostVM ConvertBlogPostToVeiwModel(BlogPost blogPost)
        {
            BlogPostVM newBlogPostVM = new BlogPostVM();
            newBlogPostVM.BlogPost = blogPost;
            //newBlogPostVM.BlogPost = _blogServices.CreateNewBlogPost(userID);
            List<Category> assignedcategories = _blogServices.GetAssignedCategories(blogPost.BlogPostId);
            List<Category> allCategories = _blogServices.GetAllCategories();

            newBlogPostVM.CategoryList = CategorySelectListItemList(allCategories);
            return newBlogPostVM;
        }

        public BlogPost ConvertBlogPostVMToBlogPost(BlogPostVM blogPostVM)
        {
            int blogID = _blogServices.AddNewBlogPost(blogPostVM.BlogPost);
            foreach (var category in blogPostVM.CategoryArray)
            {
                _blogServices.AddCategoryToBlogPost(blogID, int.Parse(category));
            }

            string[] postTags = blogPostVM.Tag.TagName.ToLower().Split(' ');
            blogPostVM.Tags = _blogServices.AddAllTags(postTags);

            foreach (var tag in blogPostVM.Tags)
            {
                _blogServices.AddTagToBlog(blogID, tag.TagId);
            }

            return _blogServices.GetBlogPost(blogID);

        }

        //public static BlogPost ConvertVMToBlogPost(BlogPostVM newBlogPost)
        //{

        //}

        private List<SelectListItem> CategorySelectListItemList(List<Category> allcategories)
        {
            List<SelectListItem> categoryList = new List<SelectListItem>();
            foreach (var category in allcategories)
            {
                SelectListItem categorySelectItem = new SelectListItem()
                {
                    Text = category.CategoryName,
                    Value = category.CategoryId.ToString()
                };
                categoryList.Add(categorySelectItem);
            }
            return categoryList;
        }

    }
}