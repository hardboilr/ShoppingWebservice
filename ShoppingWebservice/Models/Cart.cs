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

        public DateTime CreatedAt { get; set; }

        public DateTime? CheckedOutAt { get; set; } // ? is to allow null

        [Required]
        public User User { get; set; }

        public List<CartItem> CartItems { set; get; } = new List<CartItem>();

        public Cart() { }

        public Cart(DateTime createdAt, User user) {
            CreatedAt = createdAt;
            User = user;
        }
    }
}