using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Data.Interfaces
{
    public interface IBlogTagRepository
    {
        void AddTagToBlog(int blogPostId, int category);
        void DeleteTagFromBlog(int blogPostId);
    }
}
