using GamingGuruBlog.Domain.Interfaces;
using GamingGuruBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingGuruBlog.Domain
{
    public class TagServices
    {
        private ITagRepository _tagRepo;
        private IBlogTagRepository _blogTagRepo;

        public TagServices(ITagRepository newTagRepo, IBlogTagRepository newBlogTagRepo)
        {
            _tagRepo = newTagRepo;
            _blogTagRepo = newBlogTagRepo;
        }

        public List<Tag> GetAllTags()
        {
            return _tagRepo.GetAssignedTags();
        }

        public List<Tag> AddCreatedTags(List<Tag> tagNames)
        {
            List<string> justTagNames = new List<string>();

            foreach (var tag in tagNames)
            {
                justTagNames.Add(tag.TagName);
            }
            return _tagRepo.AddAllTags(justTagNames);
        }

        public void AddTagsToBlog(int blogID, List<Tag> tagIDs)
        {
            foreach (var tag in tagIDs)
            {
                _blogTagRepo.AddTagToBlog(blogID, tag.TagId);

            }
        }

    }
}
