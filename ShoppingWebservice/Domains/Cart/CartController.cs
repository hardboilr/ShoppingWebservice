using System.Net;
using System.Web.Http;
using ShoppingWebservice.Models;
using ShoppingWebservice.Shared.DTOs;

namespace ShoppingWebservice.Domains.Cart {

    [RoutePrefix("api/cart")]
    public class CartController : ApiController {

        private readonly CartRepository _cartRepository;

        public CartController() {
            _cartRepository = new CartRepository();
        }

        [HttpPost]
        [Route("create/{userId}")]
        public IHttpActionResult CreateCart(int userId) {
            ResponseDto responseDto = _cartRepository.CreateCart(userId);
            return Content(HttpStatusCode.OK, responseDto);
        }

        [HttpPost]
        [Route("add/{itemId:int}/{cartId:int}/{quantity:int}")]
        public IHttpActionResult AddItem(int itemId, int cartId, int quantity) {
            ResponseDto responseDto = _cartRepository.AddItem(itemId, cartId, quantity);
            return Content(HttpStatusCode.OK, responseDto);
        }

        [HttpGet]
        [Route("get/{cartId}")]
        public IHttpActionResult GetCart(int cartId) {
            ResponseDto responseDto = _cartRepository.GetCart(cartId);
            return Content(HttpStatusCode.OK, responseDto);
        }

        [HttpGet]
        [Route("open")]
        public IHttpActionResult GetAllOpenCarts() {
            ResponseDto responseDto = _cartRepository.GetAllCartsbyStatus(false);
            return Content(HttpStatusCode.OK, responseDto);
        }

        [HttpGet]
        [Route("closed")]
        public IHttpActionResult GetAllClosedCarts() {
            ResponseDto responseDto = _cartRepository.GetAllCartsbyStatus(true);
            return Content(HttpStatusCode.OK, responseDto);
        }

        [HttpPut]
        [Route("checkout/{cartId}")]
        public IHttpActionResult CheckoutCart(int cartId) {
            ResponseDto responseDto = _cartRepository.CheckoutCart(cartId);
            return Content(HttpStatusCode.OK, responseDto);
        }

        [HttpPut]
        [Route("update/cartItem/{cartId}")]
        public IHttpActionResult UpdateCartItem(int cartId, CartItem item) {
            ResponseDto responseDto = _cartRepository.UpdateCarItem(cartId, item);
            return Content(HttpStatusCode.OK, responseDto);
        }

        [HttpDelete]
        [Route("delete/cartItem/{cartItemId}")]
        public IHttpActionResult DeleteCartItem(int cartItemId) {
            ResponseDto responseDto = _cartRepository.DeleteCarItemfromCart(cartItemId);
            return Content(HttpStatusCode.OK, responseDto);
        }

        [HttpDelete]
        [Route("{cartId}")]
        public IHttpActionResult DeleteCart(int cartId) {
            ResponseDto responseDto = _cartRepository.DeleteCart(cartId);
            return Content(HttpStatusCode.OK, responseDto);
        }
    }
}
