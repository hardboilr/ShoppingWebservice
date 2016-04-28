using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingWebservice.Models {

    [Table("CartItem")]
    public class CartItem {

        [Key]
        public int CartItemId { get; set; }

        [Required]
        public Item Item { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Qty { get; set; }

        public Cart Cart { get; set; } 

        public CartItem() { }

        public CartItem(Item item, float price, int qty, Cart cart) {
            Item = item;
            Price = price;
            Qty = qty;
            Cart = cart;
        }
    }
}