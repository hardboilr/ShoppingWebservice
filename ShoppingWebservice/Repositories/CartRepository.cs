using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using ShoppingWebservice.DTO;
using ShoppingWebservice.Models;
using System.Web.Http;
using Microsoft.Ajax.Utilities;

namespace ShoppingWebservice.Repositories {
    public class CartRepository {

        public Transaction CreateCart(int userId) {
            using (var db = new ShoppingContext()) {
                var user = db.Users.Find(userId);
                if (user == null) {
                    return new Transaction {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Not found",
                        MessageDetail = "User with id: " + userId + " not found."
                    };
                }
                Cart cart = new Cart(user);
                db.Carts.Add(cart);
                db.SaveChanges();
                return new Transaction {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Ok",
                    MessageDetail = "Cart successfully created.",
                    Cart = cart
                };
            }
        }

        public Transaction AddItem(int itemId, int cartId, int quantity) {
            using (var db = new ShoppingContext()) {

                var cart = db.Carts
                    .Where(c => c.CartId == cartId)
                    .Include(c => c.CartItems.Select(i => i.Item))
                    .Include(c => c.User);
                    

                // cart not found
                if (cart == null || !cart.Any()) {
                    return new Transaction {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Not found",
                        MessageDetail = "Cart with id: " + cartId + " not found."
                    };
                }

                var item = db.Items.Find(itemId);

                // item not found
                if (item == null) {
                    return new Transaction {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Not found",
                        MessageDetail = "Item with id: " + itemId + " not found."
                    };
                }

                // check if item is already in cart, then update price and qty
                foreach (var c in cart.First().CartItems) {
                    if (c.Item.ItemId == itemId) {
                        Debug.WriteLine("Found existing item!");
                        c.Qty = c.Qty + quantity; // update qty
                        c.Price = c.Item.Price * c.Qty; // calculate new sumPrice
                        db.SaveChanges();
                    }
                    return new Transaction {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Ok",
                        MessageDetail = "Successfully added " + quantity + " " + item.Name + "'s to existing item in cart."
                    };
                }

                // item is not in cart already, so create new cartItem and add it to cart
                cart.First().AddCartItem(new CartItem(item, item.Price * quantity, quantity));
                db.SaveChanges();

                return new Transaction {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Ok",
                    MessageDetail = "Successfully added " + quantity + " " + item.Name + "'s to cart with id: " + cartId + "."
                };

            }
        }

        public Cart GetCart(int cartId) {
            Cart returnCart = null;
            using (var db = new ShoppingContext()) {
                var cart = db.Carts
                    .Where(c => c.CartId == cartId)
                    .Include(c => c.CartItems.Select(i => i.Item))
                    .Include(c => c.User);
                returnCart = cart.First();
            }
            return returnCart;
        }

        public Transaction GetAllCartsbyStatus(bool isClosed) {

            string status = isClosed ? "closed" : "open";

            using (var db = new ShoppingContext()) {
                var cart = db.Carts
                    .Where(c => c.CheckedOutAt.HasValue == isClosed)
                    .Include(c => c.CartItems.Select(i => i.Item))
                    .Include(c => c.User)
                    .ToList();

                if (!cart.Any()) {
                    return new Transaction {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Not found",
                        MessageDetail = "No " + status + " carts found."
                    };
                }

                string messageDetail = "";
                int noOfCarts = cart.Count;
                if (noOfCarts == 1) {
                    messageDetail = "Successfully found " + noOfCarts + " " + status + " cart.";
                } else {
                    messageDetail = "Successfully found " + noOfCarts + " " + status + " carts.";
                }

                return new Transaction {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Ok",
                    MessageDetail = messageDetail,
                    Carts = cart
                };
            }
        }

        public Transaction CheckoutCart(int cartId) {
            using (var db = new ShoppingContext()) {
                var cart = db.Carts
                    .Where(c => c.CartId == cartId)
                    .Include(c => c.CartItems.Select(i => i.Item))
                    .Include(c => c.User);

                if (cart == null || !cart.Any()) {
                    return new Transaction {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Not found",
                        MessageDetail = "Cart with id: " + cartId + " not found."
                    };
                }

                if (cart.First().CheckedOutAt.HasValue) {
                    return new Transaction {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Already checked out",
                        MessageDetail = "Cart with id: " + cartId + " already checked out."
                    };
                }

                cart.First().CheckedOutAt = DateTime.UtcNow;
                db.SaveChanges();
                return new Transaction {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Ok",
                    MessageDetail = "Cart successfully checked out",
                    Cart = cart.First()
                };
            }
        }

        public Transaction DeleteCart(int cartId) {
            using (var db = new ShoppingContext()) {
                var cart = db.Carts
                    .First(c => c.CartId == cartId);

                if (cart == null) {
                    return new Transaction {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Not found",
                        MessageDetail = "Cart with id: " + cartId + " not found."
                    };
                }

                db.Carts.Remove(cart);
                db.SaveChanges();
                return new Transaction {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Ok",
                    MessageDetail = "Cart with id: " + cartId + " successfully deleted."
                };
            }
        }
    }
}