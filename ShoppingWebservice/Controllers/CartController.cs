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
            Transaction trans = _cartRepository.GetCart(cartId);
            return Content(trans.StatusCode, trans);
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
            Transaction trans = _cartRepository.UpdateCarItem(cartId, item);
            return Content(trans.StatusCode, trans);
        }

        [HttpDelete]
        [Route("delete/cartItem/{cartItemId}")]
        public IHttpActionResult DeleteCartItem(int cartItemId) {
            Transaction trans = _cartRepository.DeleteCarItemfromCart(cartItemId);
            return Content(trans.StatusCode, trans);
        }

        [HttpDelete]
        [Route("{cartId}")]
        public IHttpActionResult DeleteCart(int cartId) {
            Transaction trans = _cartRepository.DeleteCart(cartId);
            return Content(trans.StatusCode, trans);
        }
    }
}
