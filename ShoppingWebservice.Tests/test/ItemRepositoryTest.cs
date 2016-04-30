using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingWebservice.Models;
using ShoppingWebservice.Repositories;

namespace ShoppingWebservice.Tests.test {
    [TestClass]
    public class ItemRepositoryTest {
        ItemRepository ic = new ItemRepository();

        //[TestMethod]
        //public void CreateItemTest() {
        //    ic.CreateItem("Dairy", "Milk, Eggs, etc.", "Organic Eggs", "6 organic eggs", 6.00f);
        //    Assert.AreEqual(6.00f, ic.GetItem(1).Price);
        //}

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

        //[TestMethod]
        //public void GetAllItemsTest() {
        //    ic.CreateItem("Dairy", "Milk, Eggs, etc.", "Organic Milk", "1l. of milk", 2.50f);
        //    Assert.AreEqual(2, ic.GetAllItems().Count);
        //}

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
