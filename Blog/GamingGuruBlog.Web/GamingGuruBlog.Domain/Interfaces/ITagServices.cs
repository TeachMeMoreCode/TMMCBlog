using GamingGuruBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Domain.Interfaces
{
    public interface ITagServices
    {
        List<Tag> GetAllTags();
        List<Tag> AddCreatedTags(List<Tag> tagNames);
        void AddTagsToBlog(int blogID, List<Tag> tagIDs);
        List<Tag> AddAllTags(List<string> justTagNames);
        void DeleteTagsFromBlog(int blogPostID);
        void PurgeUnusedTags();
    }
}
