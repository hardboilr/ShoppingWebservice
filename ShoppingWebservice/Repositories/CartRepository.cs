using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.Repositories {
    public class CartRepository
    {

        private ShoppingContext ShoppingContext;

        public CartRepository() {
            ShoppingContext = new ShoppingContext();
        }

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
            using (var db = ShoppingContext)
            {
                var cart = db.Carts
                    .Where(c => c.CartId == cartId)
                    .Include(c => c.CartItems.Select(i => i.Item))
                    .Include(c => c.User);

                returnCart = cart.FirstOrDefault();
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


        public string UpdateCarItem(int cartId, CartItem item) {
            string msg = "";
            using (var db = ShoppingContext){
                var existingCartItem = db.CartItems.Find(item.CartItemId);
                var existingCart = db.Carts.Find(cartId);
                if (existingCartItem != null && existingCart != null)
                    {
                        if (item.Qty <= 0)
                        {
                            db.CartItems.Remove(existingCartItem);
                            msg = "CarItem with id " + existingCartItem.CartItemId + " removed.";
                        } else {
                            existingCartItem.Cart = existingCart;
                            existingCartItem.Item = item.Item;
                            existingCartItem.Price = item.Item.Price * item.Qty;
                            existingCartItem.Qty = item.Qty;
                            msg = "Quantity for CarItem with id " + existingCartItem.CartItemId +
                                  " successfully updated to: " + item.Qty + ".";
                        }
                        db.SaveChanges();
                        return msg;
                    }
                } 
            return msg;
        }


        public bool deleteCarItemfromCart(int cartItemId) {
            using (var db = ShoppingContext)
            {
                var existingCartItem = db.CartItems.Find(cartItemId);
                if (existingCartItem != null)
                {
                    db.CartItems.Remove(existingCartItem);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}