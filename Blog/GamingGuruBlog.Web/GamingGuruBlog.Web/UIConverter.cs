using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamingGuruBlog.Domain;
using GamingGuruBlog.Web.Models;

namespace GamingGuruBlog.Web
{
    public class UIConverter
    {
        private Services _services;

        public UIConverter()
        {
            _services = new Services();
        }


        public BlogPostVM GetBlogPostVM(int id)
        {

        }

    }
}