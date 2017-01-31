using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace GamingGuruBlog.Domain.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }

        [Required(ErrorMessage ="Please enter in a title")]
        [StringLength(100, ErrorMessage = "Must be between 1 and 100 characters", MinimumLength = 1)]
        [UIHint("tinymce"), AllowHtml]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter in a body")]
        [UIHint("tinymce"), AllowHtml]
        public string Body { get; set; }

        [Required(ErrorMessage = "Please enter in a summary")]
        [StringLength(500, ErrorMessage = "Must be between 1 and 500 characters", MinimumLength = 1)]
        [UIHint("tinymce"), AllowHtml]
        public string Summary { get; set; }
            
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreatedUTC { get; set; }  //use DateTime.UTCNow 

        public string UserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EditDate { get; set; }

        public User Author { get; set; }

        public List<Category> AssignedCategories { get; set; }

        public List<Tag> AssignedTags { get; set; }

        public bool IsApproved { get; set; }
    }

    
}
