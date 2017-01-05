using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GamingGuruBlog.Domain.Models
{
    public class StaticPage
    {
        public int StaticPageId { get; set; }
        public string UserId { get; set; }

        [Required]
        [StringLength(100,ErrorMessage ="Title can only be 100 Characters Long", MinimumLength = 1)]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please add content to Body")]
        [UIHint("tinyMCE"), AllowHtml]
        public string Body { get; set; }


    }
}
