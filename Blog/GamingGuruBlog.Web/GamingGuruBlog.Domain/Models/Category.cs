using System.ComponentModel.DataAnnotations;

namespace GamingGuruBlog.Domain.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is Required")]
        [StringLength(30,ErrorMessage = "Category can only be 30 Characters Long",MinimumLength =1)]
        public string CategoryName { get; set; }
    }
}
