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
        private ICategoryRepository _categoryRepo;
        private IUserRepository _userRepo;
        private IBlogCategoryRepository _blogCategoryRepo;
        private IBlogTagRepository _blogTagRepo;
        private ITagRepository _tagRepo;

        public BlogServices(IBlogPostRepository blogPostRepository, ICategoryRepository categoryRepository, IUserRepository userRepository, IBlogCategoryRepository blogCategoryRepository, IBlogTagRepository blogTagRepo, ITagRepository tagRepo)
        {
            _blogPostRepo = blogPostRepository;
            _categoryRepo = categoryRepository;
            _userRepo = userRepository;
            _blogCategoryRepo = blogCategoryRepository;
            _blogTagRepo = blogTagRepo;
            _tagRepo = tagRepo;

        }

        #region BlogPost
        public BlogPost GetBlogPost(int blogID)
        {
            return _blogPostRepo.GetBlogPost(blogID);
        }

        public List<BlogPost> GetAllBlogPosts()
        {
            return _blogPostRepo.GetAllBlogPostsWithCategoriesAndTags();
        }

        public List<BlogPost> AllBlogPostsByTag(int tagID)
        {
            return _blogPostRepo.GetAllBlogPostsByTag(tagID);
        }

        public void DeleteBlogPost(int blogID)
        {
            _blogPostRepo.DeleteBlogPost(blogID);
        }

        public List<BlogPost> GetBlogPostByCategoryID(int categoryID)
        {
            return _blogPostRepo.GetAllPostsByCategory(categoryID);
        }

        public int AddNewBlogPost(BlogPost newPost)
        {
            int newBlogId = _blogPostRepo.AddBlogPost(newPost);
            return newBlogId;
        }

        public List<Category> GetAssignedCategories(int blogID)
        {
            return _categoryRepo.GetAssignedcategories(blogID);
        }

        public void AddCategoriesToBlogPost(int blogPostID, List<Category> categoryIDs)
        {
            foreach (var catID in categoryIDs)
            {
                _blogCategoryRepo.AddCategoryToBlog(blogPostID, catID.CategoryId);
            }
        }

        public void AddTagsToBlog(int blogID, List<Tag> tagIDs)
        {
            foreach (var tag in tagIDs)
            {
                _blogTagRepo.AddTagToBlog(blogID, tag.TagId);

            }
        }

        public void ProcessEditedBlogPost(BlogPost editedBlogPost)
        {
            editedBlogPost.EditDate = DateTime.Now;
            _blogPostRepo.EditBlogPost(editedBlogPost);
            int blogPostID = editedBlogPost.BlogPostId;

            // remove all existing Categories from blog post
            _blogCategoryRepo.DeleteCategoryFromBlogPost(blogPostID);

            // add selected categories to this blog post
            foreach (var category in editedBlogPost.AssignedCategories)
            {
                _blogCategoryRepo.AddCategoryToBlog(blogPostID, category.CategoryId);
            }

            List<string> justTagNames = new List<string>();
            foreach (var tag in editedBlogPost.AssignedTags)
            {
                justTagNames.Add(tag.TagName);
            }
            // add newly created tag names to tag repo, assigns them valid tagIDs, returns list of valid Tag objects
            editedBlogPost.AssignedTags = _tagRepo.AddAllTags(justTagNames);
            // remove all assigned tags to this blogPost
            _blogTagRepo.DeleteTagFromBlog(blogPostID);
            // assign newly created Tags to this blog post
            foreach (var tag in editedBlogPost.AssignedTags)
            {
                _blogTagRepo.AddTagToBlog(blogPostID, tag.TagId);
            }

        }

        #endregion

        #region Tags
        public List<Tag> GetAllTags()
        {
            return _tagRepo.GetAllTags();
        }

        public List<Tag> AddCreatedTags(List<Tag> tagNames)
        {
            List<string> justTagNames = new List<string>();

            foreach (var tag in tagNames)
            {
                justTagNames.Add(tag.TagName);
            }
            return _tagRepo.AddAllTags(justTagNames);
        }
        #endregion

        #region Categories

        public void AddCategory(Category newCategory)
        {
            _categoryRepo.AddCategory(newCategory);
        }

        public void DeleteCategory(int categoryID)
        {
            _categoryRepo.DeleteCategory(categoryID);
        }

        public void EditCategory(Category changedCategory)
        {
            _categoryRepo.EditCategory(changedCategory);
        }

        public Category GetCategory(int categoryID)
        {
            return _categoryRepo.GetCategory(categoryID);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepo.GetAllCategories();
        }

        #endregion

        #region User
        public User GetUser(string userID)
        {
            return _userRepo.GetUser(userID);
        }

        public void EditUser(User editedUser)
        {
            _userRepo.EditUser(editedUser);
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }
        #endregion
    }
}
