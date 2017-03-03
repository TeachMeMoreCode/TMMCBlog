using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamingGuruBlog.Domain
{
    public class BlogServices : IBlogServices
    {
        private IBlogPostRepository _blogPostRepo;
        private IUserRepository _userRepo;
        private ITagServices _tagServices;
        private ICategoryServices _categoryServices;

        public BlogServices(IBlogPostRepository blogPostRepository, IUserRepository userRepository, ITagServices newTagServices, ICategoryServices newCategoryServices)
        {
            _blogPostRepo = blogPostRepository;
            _userRepo = userRepository;
            _tagServices = newTagServices;
            _categoryServices = newCategoryServices;
        }

        public BlogPost GetBlogPost(int blogID)
        {
            return _blogPostRepo.GetBlogPost(blogID);
        }

        public BlogPost GetApprovedBlogPost(int id)
        {
            return _blogPostRepo.GetApprovedBlogPost(id);
        }

        public List<BlogPost> GetAllBlogPosts()
        {
            return _blogPostRepo.GetAllBlogPostsWithCategoriesAndTags();
        }

        public List<BlogPost> GetApprovedBlogPosts()
        {
            return _blogPostRepo.ApprovedBlogPostsWithCategoriesAndTags();
        }

        public List<BlogPost> AllApprovedBlogPostsByTag(int tagID)
        {
            return _blogPostRepo.GetApprovedBlogPostsByTag(tagID);
        }
        
        public List<BlogPost> AllApprovedBlogPostsByCategoryID(int categoryID)
        {
            return _blogPostRepo.GetApprovedPostsByCategory(categoryID);
        }

        public void DeleteBlogPost(int blogID)
        {
            _blogPostRepo.DeleteBlogPost(blogID);
        }

        public void AddNewBlogPost(BlogPost newPost)
        {
            int newBlogId = _blogPostRepo.AddBlogPost(newPost);
            _categoryServices.AddCategoriesToBlogPost(newBlogId, newPost.AssignedCategories);
            List<Tag> newTags =  _tagServices.AddCreatedTags(newPost.AssignedTags);
            _tagServices.AddTagsToBlog(newBlogId, newTags);
        }

        public void ProcessEditedBlogPost(BlogPost editedBlogPost)
        {
            editedBlogPost.EditDate = DateTime.Now;
            _blogPostRepo.EditBlogPost(editedBlogPost);
            int blogPostID = editedBlogPost.BlogPostId;

            // remove all existing Categories from blog post
            _categoryServices.DeleteCategoryFromBlogPost(blogPostID);

            // add selected categories to this blog post
            _categoryServices.AddCategoriesToBlogPost(blogPostID, editedBlogPost.AssignedCategories);

            List<string> justTagNames = new List<string>();
            foreach (var tag in editedBlogPost.AssignedTags)
            {
                justTagNames.Add(tag.TagName);
            }
            // add newly created tag names to tag repo, assigns them valid tagIDs, returns list of valid Tag objects
            editedBlogPost.AssignedTags = _tagServices.AddAllTags(justTagNames);

            // remove all assigned tags to this blogPost
            _tagServices.DeleteTagsFromBlog(blogPostID);

            // assign newly created Tags to this blog post
            _tagServices.AddTagsToBlog(blogPostID, editedBlogPost.AssignedTags);

            // purge tags that are not used
            _tagServices.PurgeUnusedTags();
        }
    }
}
