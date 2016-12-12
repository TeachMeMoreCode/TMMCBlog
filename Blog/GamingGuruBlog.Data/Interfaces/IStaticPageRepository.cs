
using GamingGuruBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Data.Interfaces
{
    public interface IStaticPageRepository
    {
        List<StaticPage> GetAllStaticPages();
        StaticPage GetStaticPage(int id);
        void DeleteStaticPage(int id);
        void AddStaticPage(StaticPage newStaticPage);
        void EditStaticPage(StaticPage updatedStaticPage);

    }
}
