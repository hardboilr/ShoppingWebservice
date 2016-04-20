using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.Run {
     class InitDb {
         static void Main() {

             using (var db = new ShoppingContext()) {
                 db.Users.Add(new User("Tobias", "Jacobsen", "tobias.cbs@gmail.com", "Castle of Fun 42, 1337 Fantasy City"));

             }

         }
    }
}