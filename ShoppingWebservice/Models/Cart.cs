using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingWebservice.Models {
    public class Cart {
        public int CartId { get; private set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CheckedOutAt { get; set; }
        public User User { get; set; }
        public List<CartItem> CartItems { set; get; }


        public Cart(User user) {
            CreatedAt = DateTime.Now;
            User = user;
        }
    }
}