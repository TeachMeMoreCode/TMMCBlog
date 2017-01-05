using GamingGuruBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamingGuruBlog.Web.Models
{
    public class AllBlogPostsVM
    {
        public List<BlogPost> AllBlogPosts { get; set; }
        public List<Category> AllCategories { get; set; }
        public List<Tag> AllTags { get; set; }
    }
}