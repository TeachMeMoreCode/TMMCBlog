using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Domain
{
    public class StaticPageServices : IStaticPageServices
    {
        private IStaticPageRepository _staticPagerepo;

        public StaticPageServices(IStaticPageRepository newStaticPageRepo)
        {
            _staticPagerepo = newStaticPageRepo;
        }

        public void AddStaticPage(StaticPage newStaticPage)
        {
            _staticPagerepo.AddStaticPage(newStaticPage);
        }

        public StaticPage GetStaticPage(int staticPageID)
        {
            return _staticPagerepo.GetStaticPage(staticPageID);
        }

        public void EditStaticPage(StaticPage updatedStaticPage)
        {
            _staticPagerepo.EditStaticPage(updatedStaticPage);
        }

        public void DeleteStaticPage(int staticPageID)
        {
            _staticPagerepo.DeleteStaticPage(staticPageID);
        }

        public List<StaticPage> GetAllStaticPages()
        {
            return _staticPagerepo.GetAllStaticPages();
        }

    }
}
