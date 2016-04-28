using System;
using System.Data.Entity;
using System.Linq;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.Repositories {
    public class CartRepository {

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
                cart.AddCartItem(new CartItem(item, item.Price * quantity, quantity));
                db.SaveChanges();
                returnItem = item;
            }
            return returnItem;
        }

        public Cart GetCart(int cartId) {
            Cart returnCart = null;
            using (var db = new ShoppingContext())
            {
                var cart = db.Carts.Where(c => c.CartId == cartId).Include(c => c.CartItems.Select(i => i.Item)).Include(c => c.User);
                returnCart = cart.First();
            }
            return returnCart;
        }

        public Cart CheckoutCart(int cartId) {
            Cart returnCart = null;
            using (var db = new ShoppingContext()) {
                var cart = db.Carts.Find(cartId);
                cart.CheckedOutAt = DateTime.Now;
                db.SaveChanges();
                returnCart = cart;
            }
            return returnCart;
        }
    }
}