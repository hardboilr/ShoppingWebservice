using System;
using System.Diagnostics;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingWebservice.Controllers;
using ShoppingWebservice.DTO;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.Tests.test {
    [TestClass]
    public class CartControllerTest {

        private readonly CartController _controller = new CartController();

        [TestMethod]
        public void CreateCartWithValidId() {
            // Act
            var resultRaw = _controller.CreateCart(1);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.OK, result.Content.StatusCode);
            Assert.IsNotNull(result.Content.Cart);
        }

        [TestMethod]
        public void CreateCartWithInValidId() {
            // Act
            var resultRaw = _controller.CreateCart(189);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Content.StatusCode);
            Assert.AreEqual("User with id: 189 not found.", result.Content.MessageDetail);
        }

        [TestMethod]
        public void AddItemWithValidId() {
            // Act
            var resultRaw = _controller.AddItem(1,1,2);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.OK, result.Content.StatusCode);
        }

        [TestMethod]
        public void AddItemWithIValidItemdId() {
            // Act
            var resultRaw = _controller.AddItem(187, 1, 2);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Content.StatusCode);
            Assert.AreEqual("Item with id: 187 not found.", result.Content.MessageDetail);
        }

        [TestMethod]
        public void AddItemWithIValidCartId() {
            // Act
            var resultRaw = _controller.AddItem(1, 189, 2);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Content.StatusCode);
            Assert.AreEqual("Cart with id: 189 not found.", result.Content.MessageDetail);
        }

        [TestMethod]
        public void AddItemWithIValidQuantity() {
            // Act
            var resultRaw = _controller.AddItem(1, 1, -2);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Content.StatusCode);
            Assert.AreEqual("-2 is a negative value and therefore not allowed.", result.Content.MessageDetail);
        }

        [TestMethod]
        public void GetCartWithValidId() {
            // Act
            var resultRaw = _controller.GetCart(1);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>) resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.OK, result.Content.StatusCode);
            Assert.AreEqual(1, result.Content.Cart.CartId);
            Assert.AreEqual(1, result.Content.Cart.User.UserId);
            Assert.AreEqual(1, result.Content.Cart.CartItems[0].CartItemId);
            Assert.AreEqual(1, result.Content.Cart.CartItems[0].Item.ItemId);
        }

        [TestMethod]
        public void GetCartWithInValidId() {
            // Act
            var resultRaw = _controller.GetCart(189);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Content.StatusCode);
            Assert.AreEqual("Not found", result.Content.Message);
        }

        [TestMethod]
        public void GetAllOpenCarts() {
            // Act
            var resultRaw = _controller.GetAllOpenCarts();
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.OK, result.Content.StatusCode);
            Assert.AreEqual(3, result.Content.Carts.Count);
            Assert.AreEqual(1, result.Content.Carts[0].User.UserId);
            Assert.AreEqual(1, result.Content.Carts[0].CartItems[0].CartItemId);
            Assert.AreEqual(1, result.Content.Carts[0].CartItems[0].Item.ItemId);
        }

        [TestMethod]
        public void GetAllClosedCarts() {
            // Act
            var resultRaw = _controller.GetAllClosedCarts();
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.OK, result.Content.StatusCode);
            Assert.AreEqual(1, result.Content.Carts.Count);
            Assert.AreEqual(1, result.Content.Carts[0].User.UserId);
            Assert.AreEqual(8, result.Content.Carts[0].CartItems[0].CartItemId);
            Assert.AreEqual(8, result.Content.Carts[0].CartItems[0].Item.ItemId);
        }

        [TestMethod]
        public void CheckoutCartWithValidId() {
            // Act
            var resultRaw = _controller.CheckoutCart(1);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.OK, result.Content.StatusCode);
            Assert.AreEqual("Cart successfully checked out", result.Content.MessageDetail);
        }

        [TestMethod]
        public void CheckoutCartWithInValidId() {
            // Act
            var resultRaw = _controller.CheckoutCart(154);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Content.StatusCode);
            Assert.AreEqual("Cart with id: 154 not found.", result.Content.MessageDetail);
        }

        [TestMethod]
        public void CheckoutCartWhichAlreadyHasCheckedOut() {
            // Act
            var resultRaw = _controller.CheckoutCart(3);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Content.StatusCode);
            Assert.AreEqual("Cart with id: 3 already checked out.", result.Content.MessageDetail);
        }

        [TestMethod]
        public void UpdateCartItem() {
            // Setup
            Item hvedemel = new Item("hvedemel", "mel er et pulver fremstillet ved formaling af ubehandlede korn eller andre frø eller rødder", 16.00m, "mad, kolonial, bagning");
            CartItem item = new CartItem(hvedemel, hvedemel.Price, 5);
            item.CartItemId = 1;
            // Act
            var resultRaw = _controller.UpdateCartItem(1, item);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.OK, result.Content.StatusCode);
            Assert.AreEqual("The Quantity for hvedemel was successfully updated to: 5.", result.Content.MessageDetail);
        }

        [TestMethod]
        public void UpdateCartItemWithNegativeQty() {
            // Setup
            Item hvedemel = new Item("hvedemel", "mel er et pulver fremstillet ved formaling af ubehandlede korn eller andre frø eller rødder", 16.00m, "mad, kolonial, bagning");
            CartItem item = new CartItem(hvedemel, hvedemel.Price, -95);
            item.CartItemId = 1;
            // Act
            var resultRaw = _controller.UpdateCartItem(1, item);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.OK, result.Content.StatusCode);
            Assert.AreEqual("hvedemel Successfully removed from cart.", result.Content.MessageDetail);
        }
        [TestMethod]
        public void DeleteCartItemWithValidId() {
            // Act
            var resultRaw = _controller.DeleteCartItem(2);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.OK, result.Content.StatusCode);
            Assert.AreEqual("CarItem with id: 2 successfully deleted.", result.Content.MessageDetail);
        }

        [TestMethod]
        public void DeleteCartItemWithInValidId() {
            // Act
            var resultRaw = _controller.DeleteCartItem(156);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Content.StatusCode);
            Assert.AreEqual("CartItem with id: 156 not found.", result.Content.MessageDetail);
        }

        [TestMethod]
        public void DeleteCartWithValidId() {
            // Act
            var resultRaw = _controller.DeleteCart(1);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.OK, result.Content.StatusCode);
            Assert.AreEqual("Cart with id: 1 successfully deleted.", result.Content.MessageDetail);
        }

        [TestMethod]
        public void DeleteCartWithInValidId() {
            // Act
            var resultRaw = _controller.DeleteCart(156);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>)resultRaw;

            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Content.StatusCode);
            Assert.AreEqual("Cart with id: 156 not found.", result.Content.MessageDetail);
        }


    }
}
