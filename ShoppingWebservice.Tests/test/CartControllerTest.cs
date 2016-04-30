using System;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingWebservice.Controllers;
using ShoppingWebservice.DTO;

namespace ShoppingWebservice.Tests.test {
    [TestClass]
    public class CartControllerTest {

        private readonly CartController _controller = new CartController();

        [TestMethod]
        public void GetCartWithId() {
            // Act
            //IHttpActionResult actionResult = _controller.GetCart(1);

            var resultRaw = _controller.GetCart(1);
            NegotiatedContentResult<Transaction> result = (NegotiatedContentResult<Transaction>) resultRaw;


            //Debug.WriteLine(resultRaw.GetType());
            //var contentResult = resultRaw as NegotiatedContentResult<>;
            ////Assert.IsInstanceOfType(resultRaw, typeof(OkNegotiatedContentResult<Transaction>));
            ////NegotiatedContentResult<Content> negResult = resultRaw as NegotiatedContentResult<Content>;





            ////// Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(1, result.Content.Cart.CartId);

        }
    }
}
