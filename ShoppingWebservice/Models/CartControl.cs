using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingWebservice.Models {
    public class CartControl {

        public Cart CreateCart(int userId) {
            Cart returnCart = null;
            using (var db = new ShoppingContext()) {
                var user = db.Users.Find(userId);
                Cart cart = new Cart(user);
                db.Carts.Add(cart);
                returnCart = cart;
            }
            return returnCart;
        }
        public Item AddItem(int itemId, int cartId, int quantity) {
            Item returnItem = null;
            using (var db = new ShoppingContext()) {
                var cart = db.Carts.Find(cartId);
                var item = db.Items.Find(itemId);
                cart.CartItems.Add(new CartItem(item, item.Price * quantity, quantity));
                db.SaveChanges();
                returnItem = item;
            }
            return returnItem;
        }

        public Cart GetCart(int cartId) {
            Cart returnCart = null;
            using (var db = new ShoppingContext()) {
                var cart = db.Carts.Find(cartId);
                returnCart = cart;
            }
            return returnCart;
        }

        public Cart CheckoutCart(int cartId) {

            return null;
        }
    }
}