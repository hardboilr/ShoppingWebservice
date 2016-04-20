using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingWebservice.Models {
    public class User {
        public int UserId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; } //ex. "Smallegade 46A, 2. th., 2000 Frederiksberg"
        public IList<Cart> Carts { get; set; } = new List<Cart>();

        public User() { }

        public User(string firstName, string lastName, string email, string address) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        }

    }
}