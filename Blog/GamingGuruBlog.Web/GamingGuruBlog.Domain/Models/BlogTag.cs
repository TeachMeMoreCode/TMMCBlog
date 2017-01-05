namespace GamingGuruBlog.Domain.Models
{
    public class BlogTag
    {
        public int BlogPostId { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public BlogPost BlogPost { get; set; }

    }
}
