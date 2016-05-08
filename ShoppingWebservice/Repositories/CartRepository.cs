using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using ShoppingWebservice.DTO;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.Repositories {
    public class CartRepository {

        private readonly ShoppingContext _shoppingContext;

        public CartRepository() {
            _shoppingContext = new ShoppingContext();
        }

        public ResponseDTO CreateCart(int userId) {
            using (var db = _shoppingContext) {
                var user = db.Users.Find(userId);
                if (user == null) {
                    return new ResponseDTO {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Not found",
                        MessageDetail = "User with id: " + userId + " not found."
                    };
                }
                Cart cart = new Cart(user);
                db.Carts.Add(cart);
                db.SaveChanges();
                return new ResponseDTO {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Ok",
                    MessageDetail = "Cart successfully created.",
                    Cart = cart
                };
            }
        }

        public ResponseDTO AddItem(int itemId, int cartId, int quantity) {
            // negative quantity
            if (quantity <= 0) {
                return new ResponseDTO {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Forbidden",
                    MessageDetail = quantity + " is a negative value and therefore not allowed."
                };
            }

            using (var db = _shoppingContext) {

                var cart = db.Carts
                    .Where(c => c.CartId == cartId)
                    .Include(c => c.CartItems.Select(i => i.Item))
                    .Include(c => c.User);


                // cart not found
                if (cart == null || !cart.Any()) {
                    return new ResponseDTO {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Not found",
                        MessageDetail = "Cart with id: " + cartId + " not found."
                    };
                }

                var item = db.Items.Find(itemId);

                // item not found
                if (item == null) {
                    return new ResponseDTO {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Not found",
                        MessageDetail = "Item with id: " + itemId + " not found."
                    };
                }

                // check if item is already in cart, then update price and qty
                foreach (var c in cart.First().CartItems) {
                    if (c.Item.ItemId == itemId) {
                        c.Qty = c.Qty + quantity; // update qty
                        c.Price = c.Item.Price * c.Qty; // calculate new sumPrice
                        db.SaveChanges();
                    }
                    return new ResponseDTO {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Ok",
                        MessageDetail = "Successfully added " + quantity + " " + item.Name + "'s to existing item in cart."
                    };
                }

                // item is not in cart already, so create new cartItem and add it to cart
                cart.First().AddCartItem(new CartItem(item, item.Price * quantity, quantity));
                db.SaveChanges();

                return new ResponseDTO {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Ok",
                    MessageDetail = "Successfully added " + quantity + " " + item.Name + "'s to cart with id: " + cartId + "."
                };

            }
        }

        public ResponseDTO UpdateCarItem(int cartId, CartItem item) {
            using (var db = _shoppingContext) {
                var existingCartItem = db.CartItems.Find(item.CartItemId);
                var existingCart = db.Carts.Find(cartId);
                if (existingCartItem != null && existingCart != null) {
                    if (item.Qty <= 0) {
                        db.CartItems.Remove(existingCartItem);
                        db.SaveChanges();
                        return new ResponseDTO {
                            StatusCode = HttpStatusCode.OK,
                            Message = "Ok",
                            MessageDetail = item.Item.Name + " Successfully removed from cart."
                        };
                    } else {
                        existingCartItem.Cart = existingCart;
                        existingCartItem.Item = item.Item;
                        existingCartItem.Price = item.Item.Price * item.Qty;
                        existingCartItem.Qty = item.Qty;
                        db.SaveChanges();
                        return new ResponseDTO {
                            StatusCode = HttpStatusCode.OK,
                            Message = "Ok",
                            MessageDetail = "The Quantity for " + existingCartItem.Item.Name +
                              " was successfully updated to: " + item.Qty + "."
                        };
                    }
                   
                }
            }
            return new ResponseDTO {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "Not found",
                MessageDetail = "CartItem with id: " + item.CartItemId + " not found."
            };
        }

        public ResponseDTO GetCart(int cartId) {
            using (var db = _shoppingContext) {
                var cart = db.Carts
                    .Where(c => c.CartId == cartId)
                    .Include(c => c.CartItems.Select(i => i.Item))
                    .Include(c => c.User);

                if (!cart.Any())
                {
                    return new ResponseDTO {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Not found",
                        MessageDetail = "No cart with id: " +  cartId + " was found."
                    };
                }

                return new ResponseDTO {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Ok",
                    MessageDetail = "Cart succesfully found",
                    Cart = cart.First()
                };
            }
        }

        public ResponseDTO GetAllCartsbyStatus(bool isClosed) {

            string status = isClosed ? "closed" : "open";

            using (var db = _shoppingContext) {
                var cart = db.Carts
                    .Where(c => c.CheckedOutAt.HasValue == isClosed)
                    .Include(c => c.CartItems.Select(i => i.Item))
                    .Include(c => c.User)
                    .ToList();

                if (!cart.Any()) {
                    return new ResponseDTO {
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

                return new ResponseDTO {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Ok",
                    MessageDetail = messageDetail,
                    Carts = cart
                };
            }
        }

        public ResponseDTO CheckoutCart(int cartId) {
            using (var db = _shoppingContext) {
                var cart = db.Carts
                    .Where(c => c.CartId == cartId)
                    .Include(c => c.CartItems.Select(i => i.Item))
                    .Include(c => c.User);

                if (cart == null || !cart.Any()) {
                    return new ResponseDTO {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Not found",
                        MessageDetail = "Cart with id: " + cartId + " not found."
                    };
                }

                if (cart.First().CheckedOutAt.HasValue) {
                    return new ResponseDTO {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Already checked out",
                        MessageDetail = "Cart with id: " + cartId + " already checked out."
                    };
                }

                cart.First().CheckedOutAt = DateTime.UtcNow;
                db.SaveChanges();
                return new ResponseDTO {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Ok",
                    MessageDetail = "Cart successfully checked out",
                    Cart = cart.First()
                };
            }
        }

        public ResponseDTO DeleteCart(int cartId) {
            using (var db = _shoppingContext)
            {
                var cart = db.Carts.Find(cartId);

                if (cart == null) {
                    return new ResponseDTO {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Not found",
                        MessageDetail = "Cart with id: " + cartId + " not found."
                    };
                }

                db.Carts.Remove(cart);
                db.SaveChanges();
                return new ResponseDTO {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Ok",
                    MessageDetail = "Cart with id: " + cartId + " successfully deleted."
                };
            }
        }

        public ResponseDTO DeleteCarItemfromCart(int cartItemId) {
            using (var db = _shoppingContext) {
                var existingCartItem = db.CartItems.Find(cartItemId);
                if (existingCartItem != null) {
                    db.CartItems.Remove(existingCartItem);
                    db.SaveChanges();
                    return new ResponseDTO {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Ok",
                        MessageDetail = "CarItem with id: " + cartItemId + " successfully deleted."
                    }; 
                }
                return new ResponseDTO {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Not found",
                    MessageDetail = "CartItem with id: " + cartItemId + " not found."
                };
            }
        }
    }
}