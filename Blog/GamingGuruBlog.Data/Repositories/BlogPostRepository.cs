using GamingGuruBlog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using GamingGuruBlog.Domain.Models;
using System.Data.SqlClient;
using Dapper;

namespace GamingGuruBlog.Data.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        public BlogPost GetBlogPost(int id)
        {
            //TODO: try-catch
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@BlogPostID", id);
                var blogPost = connection.Query<BlogPost>("SELECT * FROM BlogPost WHERE BlogPostID = @BlogPostID", parameter).First();
                string userId = blogPost.UserId;
                parameter.Add("@UserID", userId);
                blogPost.Author = GetAuthor(userId, connection);
                blogPost.AssignedCategories = GetAssignedCategories(id, connection);
                blogPost.AssignedTags = GetAssignedTags(id, connection);

                return blogPost;
            }
        }

        public void EditBlogPost(BlogPost blogPost)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {

                var parameters = new DynamicParameters();
                parameters.Add("Title", blogPost.Title);
                parameters.Add("Body", blogPost.Body);
                parameters.Add("Summary", blogPost.Summary);
                parameters.Add("BlogId", blogPost.BlogPostId);
                parameters.Add("EditDate", blogPost.EditDate);

                connection.Execute("Update BlogPost set Title = @Title, Body = @Body, Summary = @Summary, EditDate = @EditDate WHERE BlogPostId = @BlogId", parameters);

            }
        }

        public void DeleteBlogPost(int id)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BlogPostId", id);
                connection.Execute("Delete from BlogCategory where BlogPostId = @BlogPostId", parameters);
                connection.Execute("Delete from BlogTag where BlogPostId = @BlogPostId", parameters);
                connection.Execute("Delete from BlogPost where BlogPostId = @BlogPostId", parameters);
            }
        }

        public int AddBlogPost(BlogPost newBlogPost)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                const string insertSql = "INSERT INTO BlogPost (Title, Body, Summary, UserID, DateCreatedUTC) OUTPUT INSERTED.BlogPostID VALUES(@Title, @Body, @Summary, @UserID, @DateCreatedUTC)";
                connection.Open();

                using (SqlCommand myCommand = new SqlCommand(insertSql, connection))
                {

                    myCommand.Parameters.AddWithValue("@Title", newBlogPost.Title);
                    myCommand.Parameters.AddWithValue("@Body", newBlogPost.Body);
                    myCommand.Parameters.AddWithValue("@Summary", newBlogPost.Summary);
                    myCommand.Parameters.AddWithValue("@UserId", newBlogPost.UserId);
                    myCommand.Parameters.AddWithValue("@DateCreatedUTC", newBlogPost.DateCreatedUTC);

                    var newId = myCommand.ExecuteScalar();
                    return (int)newId;
                }

            };
        }

        public List<BlogPost> GetAllBlogPostsWithCategoriesAndTags()
        {

            //TODO: probably need a try-catch
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                List<BlogPost> allBlogPosts = connection.Query<BlogPost>("SELECT * FROM BlogPost ORDER BY DateCreatedUTC DESC").ToList();

                foreach (var blogPost in allBlogPosts)
                {
                    int blogId = blogPost.BlogPostId;
                    string userId = blogPost.UserId;
                    blogPost.Author = GetAuthor(userId, connection);
                    blogPost.AssignedCategories = GetAssignedCategories(blogId, connection);
                    blogPost.AssignedTags = GetAssignedTags(blogId, connection);
                }
                return allBlogPosts;
            }
        }

        private List<Tag> GetAssignedTags(int blogId, SqlConnection connection)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@BlogPostID", blogId);
            return connection.Query<Tag>("SELECT t.TagID, t.TagName FROM BlogPost as bp JOIN BlogTag as bt ON bp.BlogPostID = bt.BlogPostID JOIN Tag as t ON bt.TagID = t.TagID WHERE @BlogPostID = bp.BlogPostID", parameter).ToList();
        }

        private List<Category> GetAssignedCategories(int blogId, SqlConnection connection)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@BlogPostID", blogId);
            return connection.Query<Category>("SELECT * FROM BlogPost as bp JOIN BlogCategory as bc ON bp.BlogPostID = bc.BlogPostID JOIN Category as c ON bc.CategoryID = c.CategoryID WHERE @BlogPostID = bp.BlogPostID", parameter).ToList();
        }

        private User GetAuthor(string userId, SqlConnection connection)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@UserID", userId);
            return connection.Query<User>("SELECT * FROM BlogPost AS bp JOIN AspNetUsers AS au ON bp.UserID = au.Id WHERE bp.UserID = @UserID", parameter).FirstOrDefault();
        }

        public List<BlogPost> GetAllPostsByCategory(int categoryID)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@CategoryID", categoryID);

                List<BlogPost> allPostsByCategory = connection.Query<BlogPost>("SELECT * FROM BlogPost as BP JOIN BlogCategory as BC ON BC.BlogPostID = BP.BlogPostID WHERE BC.CategoryID = @CategoryID ORDER BY DateCreatedUTC DESC", parameter).ToList();

                foreach (var blogPost in allPostsByCategory)
                {
                    int blogId = blogPost.BlogPostId;
                    string userId = blogPost.UserId;
                    blogPost.Author = GetAuthor(userId, connection);
                    blogPost.AssignedCategories = GetAssignedCategories(blogId, connection);
                    blogPost.AssignedTags = GetAssignedTags(blogId, connection);
                }

                return allPostsByCategory;
            }
        }

        public List<BlogPost> GetAllBlogPostsByTag(int tagID)
        {
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@TagID", tagID);

                List<BlogPost> allPostsByTag = connection.Query<BlogPost>("SELECT * FROM BlogPost AS bp JOIN BlogTag AS bt on bp.BlogPostID = bt.BlogPostID WHERE bt.TagID = @TagID ORDER BY DateCreatedUTC DESC", parameter).ToList();

                foreach (var blogPost in allPostsByTag)
                {
                    int blogId = blogPost.BlogPostId;
                    string userId = blogPost.UserId;
                    blogPost.Author = GetAuthor(userId, connection);
                    blogPost.AssignedCategories = GetAssignedCategories(blogId, connection);
                    blogPost.AssignedTags = GetAssignedTags(blogId, connection);
                }

                return allPostsByTag;
            }
        }

    }
}
