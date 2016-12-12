using GamingGuruBlog.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GamingGuruBlog.Web.Models
{
    public class BlogPostVM
    {
        public BlogPost BlogPost { get; set; }
        [Required(ErrorMessage = "Please select a category")]
        public string[] CategoryArray { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public List<Category> Categories { get; set; }
        public List<Tag> Tags { get; set; }
        public Tag Tag { get; set;}
        public string TagString { get; set; }

        public BlogPostVM()
        {
            CategoryList = new List<SelectListItem>();
            BlogPost = new BlogPost();
            Tags = new List<Tag>();
            Tag = new Tag();
            Categories = new List<Category>();
        }
    }
}