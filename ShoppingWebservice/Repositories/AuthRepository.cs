using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.Repositories {
    public class AuthRepository : IDisposable {


        public string RegisterUser(User userModel) {
            string message = "";

            using (var db = new ShoppingContext()) {
                // check for existing items with same name
                var query =
                    from u in db.Users
                    select u;

                foreach (var u in query) {
                    if (u.UserName.Equals(userModel.UserName)) {
                        return userModel.UserName + " already exists ";
                    }
                }
                db.Users.Add(userModel);
                db.SaveChanges();
            }
            return message;
        }

        public async Task<User> FindUser(string userName, string password) {
            User user = null;
            Debug.WriteLine(userName + "," + password);
            using (var db = new ShoppingContext()) {
                var query = from u in db.Users
                            where u.UserName == userName && u.Password == password
                            select u;
                foreach (User u in query) {
                    Debug.WriteLine(u);
                    user = u;

                }
                return user;
            }


        }

        public void Dispose() {
            this.Dispose();
        }
    }
}