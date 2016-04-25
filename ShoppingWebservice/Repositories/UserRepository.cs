using System.Linq;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.Repositories {
    public class UserRepository {

        public User CreateUser(User user) {
            User returnUser = null;
            using (var db = new ShoppingContext()) {
                db.Users.Add(user);
                db.SaveChanges();
                returnUser = user;
            }
            return returnUser;
        }

        public User GetUser(string username) {
            User returnUser = null;
            using (var db = new ShoppingContext()) {
                //var user = from u in db.Users where u.FirstName.Equals(username) select u;
                //returnUser = user.First();
            }
            return returnUser;
        }


    }
}