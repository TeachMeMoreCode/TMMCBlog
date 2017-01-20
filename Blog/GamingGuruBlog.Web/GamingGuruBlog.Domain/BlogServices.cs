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
        public List<Category> GetAllCategories()
        {
            return _categoryRepo.GetAllCategories();
        }

        #endregion 

    }
}
