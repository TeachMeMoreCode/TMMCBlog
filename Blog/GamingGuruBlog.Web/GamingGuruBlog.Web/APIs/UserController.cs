using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using GamingGuruBlog.Domain.Models;
using GamingGuruBlog.Domain.Interfaces;


namespace GamingGuruBlog.Web.APIs
{
    public class UserController : ApiController
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public IHttpActionResult EditUser(User editedUser)
        {
            _userServices.EditUser(editedUser);
            return Ok();
        }
    }
}
