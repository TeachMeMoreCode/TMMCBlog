using GamingGuruBlog.Domain.Models;
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
        public List<Tag> Tags { get; set; } // this is to hold all current assigned Tags to the blog. For processing only (See BlogPost Controller: Edit POST).
        public Tag Tag { get; set;}
        public string TagString { get; set; } // this is to display current values (of Tags) in editing a blog

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