using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingWebservice.Models {

    [Table("Cart")]
    public class Cart {

        [Key]
        public int CartId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? CheckedOutAt { get; set; } // ? is to allow null

        [Required]
        public User User { get; set; }

        public List<CartItem> CartItems { set; get; } = new List<CartItem>();

        public void AddCartItem(CartItem item) {
            CartItems.Add(item);
            item.Cart = this;
        }

        public Cart() { }
   
        public Cart(User user) {
            CreatedAt = DateTime.UtcNow;
            User = user;
            user.Carts.Add(this);
        }
    }
}