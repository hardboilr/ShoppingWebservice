using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using ShoppingWebservice.DTO;
using ShoppingWebservice.Models;
using ShoppingWebservice.Repositories;

namespace ShoppingWebservice.Controllers {
    [RoutePrefix("api/cart")]
    public class CartController : ApiController {

        private readonly CartRepository _cartRepository;

        public CartController() {
            _cartRepository = new CartRepository();
        }

        [HttpPost]
        [Route("create/{userId}")]
        public IHttpActionResult CreateCart(int userId) {
            Transaction trans = _cartRepository.CreateCart(userId);
            return Content(trans.StatusCode, trans);
        }

        [HttpPost]
        [Route("add/{itemId:int}/{cartId:int}/{quantity:int}")]
        public IHttpActionResult AddItem(int itemId, int cartId, int quantity) {
            Transaction trans = _cartRepository.AddItem(itemId, cartId, quantity);
            return Content(trans.StatusCode, trans);
        }

        [HttpGet]
        [Route("get/{cartId}")]
        public IHttpActionResult GetCart(int cartId) {
            Cart cart = _cartRepository.GetCart(cartId);
            if (cart == null) {
                dynamic responseBody = new JObject();
                responseBody.message = "No cart found with cartId: " + cartId + ".";
                return Content(HttpStatusCode.BadRequest, responseBody);
            } else {
                return Content(HttpStatusCode.OK, cart);
            }
        }

        [HttpGet]
        [Route("open")]
        public IHttpActionResult GetAllOpenCarts() {
            Transaction trans = _cartRepository.GetAllCartsbyStatus(false);
            return Content(trans.StatusCode, trans);
        }

        [HttpGet]
        [Route("closed")]
        public IHttpActionResult GetAllClosedCarts() {
            Transaction trans = _cartRepository.GetAllCartsbyStatus(true);
            return Content(trans.StatusCode, trans);
        }

        [HttpPut]
        [Route("checkout/{cartId}")]
        public IHttpActionResult CheckoutCart(int cartId) {
            Transaction trans = _cartRepository.CheckoutCart(cartId);
            return Content(trans.StatusCode, trans);
        }

        [HttpPut]
        [Route("update/cartItem/{cartId}")]
        public IHttpActionResult UpdateCartItem(int cartId, CartItem item) {
            string msg = _cartRepository.UpdateCarItem(cartId, item);
            dynamic responseBody = new JObject();

            if (msg.Length > 0) {
                responseBody.message = msg;
                return Content(HttpStatusCode.OK, responseBody);
            } else {
                responseBody.message = "CartItem with id: " + item.CartItemId + " not found.";
                return Content(HttpStatusCode.BadRequest, responseBody);
            }
        }

        [HttpDelete]
        [Route("delete/cartItem/{cartItemId}")]
        public IHttpActionResult DeleteCartItem(int cartItemId) {
            bool success = _cartRepository.DeleteCarItemfromCart(cartItemId);
            dynamic responseBody = new JObject();
            if (success) {
                responseBody.message = "CarItem with id " + cartItemId + " successfully removed.";
                return Content(HttpStatusCode.OK, responseBody);
            } else {
                responseBody.message = "CartItem with id: " + cartItemId + " not found.";
                return Content(HttpStatusCode.BadRequest, responseBody);
            }
        }

        [HttpDelete]
        [Route("{cartId}")]
        public IHttpActionResult DeleteCart(int cartId) {
            Transaction trans = _cartRepository.DeleteCart(cartId);
            return Content(trans.StatusCode, trans);
        }
    }
}
