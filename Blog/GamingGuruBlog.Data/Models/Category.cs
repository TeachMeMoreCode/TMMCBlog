using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is Required")]
        [StringLength(30,ErrorMessage = "Category can only be 30 Characters Long",MinimumLength =1)]
        public string CategoryName { get; set; }
    }
}
