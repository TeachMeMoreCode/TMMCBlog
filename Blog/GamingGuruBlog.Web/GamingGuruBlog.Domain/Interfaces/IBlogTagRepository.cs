using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Domain.Interfaces
{
    public interface IBlogTagRepository
    {
        void AddTagToBlog(int blogPostId, int tag);
        void DeleteTagFromBlog(int blogPostId);
    }
}
