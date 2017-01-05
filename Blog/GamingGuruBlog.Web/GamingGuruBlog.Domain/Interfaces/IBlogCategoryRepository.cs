namespace GamingGuruBlog.Domain.Interfaces
{
    public interface IBlogCategoryRepository
    {
        void AddCategoryToBlog(int blogPostId, int category);
        void DeleteCategoryFromBlogPost(int blogPostId);
    }
}
