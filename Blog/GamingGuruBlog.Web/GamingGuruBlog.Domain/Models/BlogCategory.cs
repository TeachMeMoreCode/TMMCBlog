namespace GamingGuruBlog.Domain.Models
{
    public class BlogCategory
    {
        public int CategoryId { get; set; }
        public int BlogPostId { get; set; }
        public Category Category { get; set; }
        public BlogPost BlogPost { get; set; }
    }
}
