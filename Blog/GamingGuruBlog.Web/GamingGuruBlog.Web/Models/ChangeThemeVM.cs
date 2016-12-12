using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace GamingGuruBlog.Web.Models
{
    public class ChangeThemeVM
    {
        List<SelectListItem> ThemeList { get; set; }

        public ChangeThemeVM()
        {
            //ThemeList = new SelectListItem()
            //{
            //    Text = "SandStorm", Value = "Value"


            //}
            ThemeList.Add(new SelectListItem() { Text = "Simplex", Value = "1" });
            ThemeList.Add(new SelectListItem() { Text = "Cyborg", Value = "2" });
            ThemeList.Add(new SelectListItem() { Text = "Sandstone", Value = "3" });
        }
    }
}