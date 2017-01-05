
using GamingGuruBlog.Domain.Models;
using System.Collections.Generic;

namespace GamingGuruBlog.Domain.Interfaces
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
