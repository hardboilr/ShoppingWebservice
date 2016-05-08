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
            ResponseDTO responseDto = _cartRepository.CreateCart(userId);
            return Content(responseDto.StatusCode, responseDto);
        }

        [HttpPost]
        [Route("add/{itemId:int}/{cartId:int}/{quantity:int}")]
        public IHttpActionResult AddItem(int itemId, int cartId, int quantity) {
            ResponseDTO responseDto = _cartRepository.AddItem(itemId, cartId, quantity);
            return Content(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("get/{cartId}")]
        public IHttpActionResult GetCart(int cartId) {
            ResponseDTO responseDto = _cartRepository.GetCart(cartId);
            return Content(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("open")]
        public IHttpActionResult GetAllOpenCarts() {
            ResponseDTO responseDto = _cartRepository.GetAllCartsbyStatus(false);
            return Content(responseDto.StatusCode, responseDto);
        }

        [HttpGet]
        [Route("closed")]
        public IHttpActionResult GetAllClosedCarts() {
            ResponseDTO responseDto = _cartRepository.GetAllCartsbyStatus(true);
            return Content(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        [Route("checkout/{cartId}")]
        public IHttpActionResult CheckoutCart(int cartId) {
            ResponseDTO responseDto = _cartRepository.CheckoutCart(cartId);
            return Content(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        [Route("update/cartItem/{cartId}")]
        public IHttpActionResult UpdateCartItem(int cartId, CartItem item) {
            ResponseDTO responseDto = _cartRepository.UpdateCarItem(cartId, item);
            return Content(responseDto.StatusCode, responseDto);
        }

        [HttpDelete]
        [Route("delete/cartItem/{cartItemId}")]
        public IHttpActionResult DeleteCartItem(int cartItemId) {
            ResponseDTO responseDto = _cartRepository.DeleteCarItemfromCart(cartItemId);
            return Content(responseDto.StatusCode, responseDto);
        }

        [HttpDelete]
        [Route("{cartId}")]
        public IHttpActionResult DeleteCart(int cartId) {
            ResponseDTO responseDto = _cartRepository.DeleteCart(cartId);
            return Content(responseDto.StatusCode, responseDto);
        }
    }
}
