using GamingGuruBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamingGuruBlog.Web.Models
{
    public class AdminPanelVM
    {
        public List<User> Users { get; set; }
        public List<Category> Categories { get; set; }
        public List<StaticPage> StaticPages { get; set; }
        public List<BlogPost> BlogPosts { get; set; }

    }
}