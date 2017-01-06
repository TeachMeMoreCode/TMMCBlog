using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamingGuruBlog.Domain;
using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Web.Models;

namespace GamingGuruBlog.Web
{
    public class UIConverter
    {
        private IServices _services;

        public UIConverter(IServices _passedInServices)
        {
            _services = _passedInServices;
        }


        public void AddNewBlogPost(BlogPostVM newBlogPost)
        {

        }

    }
}