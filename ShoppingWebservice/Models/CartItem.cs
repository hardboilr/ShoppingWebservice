using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingWebservice.Models {
    public class CartItem {
        public int CartItemId { get; private set; }
        public Item Item { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }
        public List<Cart> Carts { get; set; }

        public CartItem() { }

        public CartItem(Item item, float price, int qty) {
            Item = item;
            Price = price;
            Qty = qty;
        }
    }
}