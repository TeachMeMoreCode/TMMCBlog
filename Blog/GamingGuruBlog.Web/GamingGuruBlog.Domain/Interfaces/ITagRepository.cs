using GamingGuruBlog.Domain.Models;
using System.Collections.Generic;

namespace GamingGuruBlog.Data.Interfaces
{
    public interface ITagRepository
    {
        List<Tag> GetAllTags();
        List<Tag> SelectAllTags(string[] tagNames);
        void AddTag(string tagName);
        Tag SelectSingleTag(string tagName);
    }
}
