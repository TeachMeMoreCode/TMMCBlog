using GamingGuruBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Domain.Interfaces
{
    public interface IStaticPageServices
    {
        void AddStaticPage(StaticPage newStaticPage);
        StaticPage GetStaticPage(int staticPageID);
        void EditStaticPage(StaticPage updatedStaticPage);
        void DeleteStaticPage(int staticPageID);
        List<StaticPage> GetAllStaticPages();
    }
}
