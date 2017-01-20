using System;
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
    public static class WebServices
    {
        private static IBlogServices _blogServices; // how the hell does this work for a static class?!



        public static BlogPostVM ConvertBlogPostToVeiwModel(BlogPost blogPost, List<Category> allCategories, List<Tag> allTags)
        {
            BlogPostVM newBlogPostVM = new BlogPostVM();
            newBlogPostVM.BlogPost = blogPost;
            newBlogPostVM.AllCategories = allCategories;
            newBlogPostVM.Tags = allTags;
            newBlogPostVM.CategorySelectListItemList = CreateSelectListItemList(allCategories);
            newBlogPostVM.TagString = string.Join(" ", blogPost.AssignedTags.Select(assignedTag => assignedTag.TagName));

            return newBlogPostVM;
        }

        public static BlogPost ConvertBlogPostVMToBlogPost(BlogPostVM blogPostVM)
        {
            BlogPost returnedBlogPost = blogPostVM.BlogPost;
            returnedBlogPost.AssignedCategories = CreateCategories(blogPostVM.ChosenCategoriesArray);

            // to be continued

            int blogID = _blogServices.AddNewBlogPost(blogPostVM.BlogPost);
            foreach (var category in blogPostVM.ChosenCategoriesArray)
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

        private static List<Category> CreateCategoryList(string[] chosenCategories)
        {
            List<Category> categoriesToBeProcessed = new List<Category>();
            foreach (var category in chosenCategories)
            {
                Category chosenCategory = new Category
                {
                    CategoryId = int.Parse(category),
                    CategoryName = "Needs to be associated with blog in BlogCategory table",
                };
                categoriesToBeProcessed.Add(chosenCategory);
            }
            return categoriesToBeProcessed;
        }

        private static List<Tag> CreateTagList(string tagString)
        {
            List<Tag> tagsToBeProcessed = new List<Tag>();
            string[] postTags = tagString.ToLower().Split(' ');
            foreach (var tag in postTags)
            {
                Tag newTag
            }

        }

        private static List<SelectListItem> CreateSelectListItemList(List<Category> allCategories)
        {
            List<SelectListItem> categorySelectListItemList = new List<SelectListItem>();
            foreach (var category in allCategories)
            {
                SelectListItem categorySelectItem = new SelectListItem()
                {
                    Text = category.CategoryName,
                    Value = category.CategoryId.ToString()
                };
                categorySelectListItemList.Add(categorySelectItem);
            }
            return categorySelectListItemList;
        }

        private static List<SelectListItem> CreateSelectListItemList(List<Tag> allTags)
        {
            List<SelectListItem> tagSelectListItemList = new List<SelectListItem>();
            foreach (var tag in allTags)
            {
                SelectListItem categorySelectItem = new SelectListItem()
                {
                    Text = tag.TagName,
                    Value = tag.TagId.ToString()
                };
                tagSelectListItemList.Add(categorySelectItem);
            }
            return tagSelectListItemList;
        }

    }
}