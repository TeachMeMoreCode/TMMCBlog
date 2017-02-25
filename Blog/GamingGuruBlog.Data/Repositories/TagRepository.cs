using GamingGuruBlog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingGuruBlog.Domain.Models;
using System.Data.SqlClient;
using Dapper;

namespace GamingGuruBlog.Data.Repositories
{
    public class TagRepository : ITagRepository
    {
        public List<Tag> GetAssignedTags()
        {
            List<Tag> assignedTags = new List<Tag>();
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                // get only tags that are associated with a blog post
                assignedTags = connection.Query<Tag>("SELECT Tag.TagID, Tag.TagName FROM BlogTag INNER JOIN Tag ON BlogTag.TagID = Tag.TagID").ToList();
            }

            return assignedTags;
        }

        public List<Tag> AddAllTags(List<string> tagNames)
        {
            List<Tag> allTags = new List<Tag>();
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                foreach (var item in tagNames)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("TagName", item);

                    Tag tag = connection.Query<Tag>("SELECT * FROM Tag where TagName = @TagName",parameters).SingleOrDefault();

                    // if the tag already exist, don't added it, instead get it and add it to the returned list
                    if (tag == null)
                    {
                        AddTag(item);
                        allTags.Add(SelectSingleTag(item));
                    }
                    else
                    {
                        allTags.Add(tag);
                    }          
                }

            }

            return allTags;
        }

        public void AddTag(string tagName)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("TagName", tagName);

                connection.Execute("Insert Into Tag (TagName) values (@TagName)", parameters);

            }
        }

        public Tag SelectSingleTag(string tagName)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {

                var parameters = new DynamicParameters();
                parameters.Add("TagName", tagName);

                Tag tag = connection.Query<Tag>("SELECT * FROM Tag where TagName = @TagName",parameters).SingleOrDefault();

                return tag;
            }
        }

        public List<Tag> GetAllTags()
        {
            List<Tag> assignedTags = new List<Tag>();
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                // get all tags whether they are associated with a blog post or not
                assignedTags = connection.Query<Tag>("SELECT * FROM Tag").ToList();
            }

            return assignedTags;

        }

        public void PurgeUnusedTags()
        {
            List<Tag> allExistingTags = GetAllTags();
            List<Tag> assignedTags = GetAssignedTags();
            List<Tag> notUsedTags = allExistingTags.Except(assignedTags).ToList();
            if (notUsedTags.Count > 0)
            {
                using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
                {
                    foreach (var unusedTag in notUsedTags)
                    {
                        connection.Execute($"DELETE FROM Tag WHERE Tag.TagID = {unusedTag.TagId}");
                    }
                }
            }
        }
    }
}
