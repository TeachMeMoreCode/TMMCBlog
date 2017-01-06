using GamingGuruBlog.Domain.Models;
using System.Collections.Generic;

namespace GamingGuruBlog.Domain.Interfaces
{
    public interface IServices
    {
        int NewBlogPost(BlogPost newPost);
    }
}
