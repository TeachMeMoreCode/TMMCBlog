using GamingGuruBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
