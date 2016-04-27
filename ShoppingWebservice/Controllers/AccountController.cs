using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using ShoppingWebservice.Models;
using ShoppingWebservice.Repositories;

namespace ShoppingWebservice.Controllers {
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController {
        private AuthRepository _repo = null;

        public AccountController() {
            _repo = new AuthRepository();
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public IHttpActionResult Register(User userModel) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            dynamic json = new JObject();

            string result = _repo.RegisterUser(userModel);

            if (result.Length <= 0) {
                json.message = userModel.UserName + " successfully created";
                return Content(HttpStatusCode.OK, json);
            } else {
                json.message = result;
                return Content(HttpStatusCode.BadRequest, json);
            }

        }

    }
}
