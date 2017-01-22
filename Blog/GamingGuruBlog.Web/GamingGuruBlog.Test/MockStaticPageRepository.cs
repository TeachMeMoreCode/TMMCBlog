using GamingGuruBlog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingGuruBlog.Domain.Models;

namespace GamingGuruBlog.Test
{
    class MockStaticPageRepository : IStaticPageRepository
    {

        private List<StaticPage> _staticPages;

        public MockStaticPageRepository()
        {
            _staticPages = new List<StaticPage>
            {
                new StaticPage { StaticPageId= 1, Title="First"},
                new StaticPage {StaticPageId = 2, Title= "Second" },
                new StaticPage {StaticPageId = 3, Title= "Third" }
            };
        }

        public void AddStaticPage(StaticPage newStaticPage)
        {
            _staticPages.Add(newStaticPage);
        }

        public void DeleteStaticPage(int id)
        {
            var staticPaheToDelete = _staticPages.Single(s => s.StaticPageId == id);
            _staticPages.Remove(staticPaheToDelete);
        }

        public void EditStaticPage(StaticPage updatedStaticPage)
        {
            throw new NotImplementedException();
        }

        public List<StaticPage> GetAllStaticPages()
        {
            return _staticPages;
        }

        public StaticPage GetStaticPage(int id)
        {
            throw new NotImplementedException();
        }
    }
}
