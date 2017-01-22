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
        public string[] ChosenCategoriesArray { get; set; } // thi is to hold the selected categories for this Blog
        public List<SelectListItem> CategorySelectListItemList { get; set; }

        [Display(Name = "Categories")]
        public List<Category> AllCategories { get; set; } // this is to display all cateogries in the UI
        public List<Tag> Tags { get; set; } // this is to hold all just assigned Tags to the blog. For processing only (See BlogPost Controller: Edit POST).
        public Tag Tag { get; set;} // this is to hold the value of the tag text box
        public string TagString { get; set; } // this is to display current values (of Tags) in editing a blog

        public BlogPostVM()
        {
            CategorySelectListItemList = new List<SelectListItem>();
            BlogPost = new BlogPost();
            Tags = new List<Tag>();
            Tag = new Tag();
            AllCategories = new List<Category>();
        }
    }
}