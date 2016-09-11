using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingWebservice.Domains.Item;
using ShoppingWebservice.Domains.Item.Repository;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.Tests.test {
    [TestClass]
    public class ItemRepositoryTest {
        ItemRepository ic = new ItemRepository();

        [TestMethod]
        public void CreateItem() {
            //Setup
            Item franskBrie = new Item("Président Fransk Brie", "Hvidskimmelost lavet af fransk komælk. God til ostebordet", 24.95m, "mad,mejeri,ost");

            //Act
            var result = ic.CreateItem(franskBrie);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Message);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(franskBrie.Name + " successfully created.", result.MessageDetail);
        }

        //[TestMethod]
        //public void UpdateItemTest() {
        //    ic.UpdateItem(1, "Organic Egg", "1 organic egg", 1.00f, 1);
        //    Assert.AreEqual(1.00f, ic.GetItem(1).Price);
        //}

        //[TestMethod]
        //public void DeleteItemTest() {
        //    ic.CreateItem("Dairy", "Milk, Eggs, etc.", "Organic Milk", "1l. of milk", 2.50f);
        //    ic.DeleteItem(2);
        //    Assert.IsNull(ic.GetItem(2));
        //}

        [TestMethod]
        public void GetAllItems() {
            //Setup
            Item gammelOlesFar = new Item("Gammel Oles far", "Føj for satan den er ulækker den her.", 62.95m, "mad,mejeri,ost");
            
            //Act
            ic.CreateItem(gammelOlesFar);
            var result = ic.GetAllItems();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Message);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(2, result.Items.Count);
        }

        //[TestMethod]
        //public void GetAllItemsByCategoryTest() {
        //    ic.CreateItem("Toys", "Legos and shit", "Lego set nr. 8430", "Lego Technics racing car", 50.00f);
        //    Assert.AreEqual(3, ic.GetAllItems().Count);
        //    Assert.AreEqual(1, ic.GetAllItemsByCategory(1).Count);
        //}

        //[TestMethod]
        //public void GetCategoryTest() {
        //    Assert.AreEqual(1, ic.GetCategory("Dairy").CategoryId);
        //}
    }
}
