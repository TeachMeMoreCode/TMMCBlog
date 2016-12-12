using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Data.Models
{
    public class BlogCategory
    {
        public int CategoryId { get; set; }
        public int BlogPostId { get; set; }
        public Category Category { get; set; }
        public BlogPost BlogPost { get; set; }
    }
}
