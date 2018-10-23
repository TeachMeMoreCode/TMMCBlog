namespace GamingGuruBlog.Domain.Models
{
    public class User
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }

        public User Clone()
        {
            return new User
            {
                ID = this.ID,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email =  this.Email,
                RoleId = this.RoleId,
                UserName = this.UserName
            };
        }
    }


}
