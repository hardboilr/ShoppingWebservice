using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingWebservice.Models;
using ShoppingWebservice.Repositories;

namespace ShoppingWebservice.Controllers {
    [RoutePrefix("api/user")]
    public class UserController : ApiController {

        private UserRepository userRepository;

        public UserController() {
            userRepository = new UserRepository();
        }

        [HttpPost]
        [Route("create")]
        public User CreateUser(User user) {
            return userRepository.CreateUser(user);
        }

        [HttpGet]
        [Route("get/{username}")]
        public User GetUser(string username) {
            return userRepository.GetUser(username);
        }
    }
}
