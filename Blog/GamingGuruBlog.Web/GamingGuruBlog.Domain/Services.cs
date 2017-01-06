using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;

namespace GamingGuruBlog.Domain
{
    public class Services
    {
        private IBlogPostRepository _blogPostRepo;
        private ICategoryRepository _categoryRepo;
        private IUserRepository _userRepo;
        private IBlogCategoryRepository _blogCategoryRepo;
        private IBlogTagRepository _blogTagRepo;
        private ITagRepository _tagRepo;
        //private BlogServices _services;

        public Services(IBlogPostRepository blogPostRepository, ICategoryRepository categoryRepository, IUserRepository userRepository, IBlogCategoryRepository blogCategoryRepository, IBlogTagRepository blogTagRepo, ITagRepository tagRepo)
        {
            _blogPostRepo = blogPostRepository;
            _categoryRepo = categoryRepository;
            _userRepo = userRepository;
            _blogCategoryRepo = blogCategoryRepository;
            _blogTagRepo = blogTagRepo;
            _tagRepo = tagRepo;

        }

        public int AddNewBlogPost(BlogPost newPost)
        {
            int newBlogId = _blogPostRepo.AddBlogPost(newPost);
            return newBlogId;
        }

    }
}
