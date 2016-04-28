using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using ShoppingWebservice.ErrorHandling;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.Repositories {
    public class ItemRepository {

        // CREATE
        public string CreateItem(Item item) {
            string message = "";
            using (var db = new ShoppingContext()) {
                // check for existing items with same name
                var query =
                    from i in db.Items
                    select i;

                foreach (var i in query) {
                    if (i.Name.Equals(item.Name)) {
                        message = "It seems that you're trying to create an item already in the database: " + i;
                    }
                }
                db.Items.Add(item);
                db.SaveChanges();
            }
            return message;
        }

        // READ ALL
        public List<Item> GetAllItems() {
            using (var db = new ShoppingContext()) {
                var query =
                    from i in db.Items
                    select i;
                return query.ToList();
            }
        }

        // READ PER ID
        public Item GetItem(int itemId) {
            using (var db = new ShoppingContext()) {
                var item = db.Items.Find(itemId);
                return item;
            }
        }

        // UPDATE
        public bool UpdateItem(Item item) {
            using (var db = new ShoppingContext()) {
                var existingItem = db.Items.Find(item.ItemId);
                if (existingItem != null) {
                    existingItem.Name = item.Name;
                    existingItem.Description = item.Description;
                    existingItem.Price = item.Price;
                    existingItem.Tag = item.Tag;
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        // DELETE
        public bool DeleteItem(int itemId) {
            using (var db = new ShoppingContext()) {
                var existingItem = db.Items.Find(itemId);
                if (existingItem != null) {
                    db.Items.Remove(existingItem);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}