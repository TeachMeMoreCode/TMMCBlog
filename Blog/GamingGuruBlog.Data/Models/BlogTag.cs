using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Data.Models
{
    public class BlogTag
    {
        public int BlogPostId { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public BlogPost BlogPost { get; set; }

    }
}
