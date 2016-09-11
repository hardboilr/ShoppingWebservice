using System;
using System.Net;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingWebservice.Domains.Item;
using ShoppingWebservice.Models;
using ShoppingWebservice.Shared.DTOs;

namespace ShoppingWebservice.Tests.test {
    [TestClass]
    public class ItemControllerTest {

        private readonly ItemController _controller = new ItemController();

        [TestMethod]
        public void CreateNewNonExistingItem() {

            // Setup
            Item franskBrie = new Item("Président Fransk Brie", "Hvidskimmelost lavet af fransk komælk. God til ostebordet", 24.95m, "mad,mejeri,ost");

            // Act
            var resultRaw = _controller.CreateItem(franskBrie);
            NegotiatedContentResult<ResponseDto> result = (NegotiatedContentResult<ResponseDto>)resultRaw;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.OK, result.Content.StatusCode);
            Assert.AreEqual("Président Fransk Brie successfully created.", result.Content.MessageDetail);

        }

        [TestMethod]
        public void CreateNewExistingItem() {

            // Setup
            Item gammelOlesFar = new Item("Gammel Oles far", "Føj for satan den er ulækker den her.", 62.95m, "mad,mejeri,ost");

            // Act
            var resultRaw = _controller.CreateItem(gammelOlesFar);
            NegotiatedContentResult<ResponseDto> result = (NegotiatedContentResult<ResponseDto>)resultRaw;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Content.StatusCode);
            Assert.AreEqual("Item already exist", result.Content.Message);

        }

        [TestMethod]
        public void GetAllItems() {

            // Act
            var resultRaw = _controller.GetAllItems();
            NegotiatedContentResult<ResponseDto> result = (NegotiatedContentResult<ResponseDto>)resultRaw;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.OK, result.Content.StatusCode);
            Assert.AreEqual("Successfully retrieved items", result.Content.MessageDetail);
            Assert.AreEqual(29, result.Content.Data.Count);
        }

        [TestMethod]
        public void GetItemWithValidId() {

            // Act
            var resultRaw = _controller.GetItem(2);
            NegotiatedContentResult<ResponseDto> result = (NegotiatedContentResult<ResponseDto>)resultRaw;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.OK, result.Content.StatusCode);
            Assert.AreEqual(2, result.Content.Item.ItemId);
            Assert.AreEqual("JerseyLetmælk", result.Content.Item.Name);
        }

        [TestMethod]
        public void GetItemWithInValidId() {

            // Act
            var resultRaw = _controller.GetItem(232);
            NegotiatedContentResult<ResponseDto> result = (NegotiatedContentResult<ResponseDto>)resultRaw;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Content.StatusCode);
            Assert.AreEqual("Not found", result.Content.Message);
        }

        [TestMethod]
        public void UpdateItem() {
            // Setup

            Item roastbeef = new Item("Roastbeef", "Af tyksteg", 240.00m, "mad,kød,oksekød");
            roastbeef.ItemId = 14;

            // Act
            var resultRaw = _controller.UpdateItem(roastbeef);
            NegotiatedContentResult<ResponseDto> result = (NegotiatedContentResult<ResponseDto>)resultRaw;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.OK, result.Content.StatusCode);
            Assert.AreEqual("Item with id: 14 successfully updated.", result.Content.MessageDetail);
        }


        [TestMethod]
        public void UpdateItemWithInvalidId() {
            // Setup

            Item roastbeef = new Item("Roastbeef", "Af tyksteg", 240.00m, "mad,kød,oksekød");
            roastbeef.ItemId = 1432;

            // Act
            var resultRaw = _controller.UpdateItem(roastbeef);
            NegotiatedContentResult<ResponseDto> result = (NegotiatedContentResult<ResponseDto>)resultRaw;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Content.StatusCode);
            Assert.AreEqual("Not found", result.Content.Message);
        }

        [TestMethod]
        public void DeleteItem() {
            // Act
            var resultRaw = _controller.DeleteItem(2);
            NegotiatedContentResult<ResponseDto> result = (NegotiatedContentResult<ResponseDto>)resultRaw;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.OK, result.Content.StatusCode);
            Assert.AreEqual("Item with id: 2 successfully deleted.", result.Content.MessageDetail);
        }


        [TestMethod]
        public void DeleteItemWithInvalidId() {
            // Act
            var resultRaw = _controller.DeleteItem(234);
            NegotiatedContentResult<ResponseDto> result = (NegotiatedContentResult<ResponseDto>)resultRaw;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Content.StatusCode);
            Assert.AreEqual("Item with id: 234 not found.", result.Content.MessageDetail);
        }

    }
}

