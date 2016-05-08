using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using ShoppingWebservice.DTO;
using ShoppingWebservice.ErrorHandling;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.Repositories {
    public class ItemRepository {

        private readonly ShoppingContext _shoppingContext;

        public ItemRepository() {
            _shoppingContext = new ShoppingContext();
        }

        // CREATE
        public Transaction CreateItem(Item item) {
            using (var db = _shoppingContext) {
                // check for existing items with same name

                Item it = CheckIfItemExists(item, false);
                if (it != null) {
                    return new Transaction {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Item already exist",
                        MessageDetail = "It seems that you're trying to create an item already in the database: " + it
                    };
                }
                db.Items.Add(item);
                db.SaveChanges();
                return new Transaction {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Ok",
                    MessageDetail = item.Name + " successfully created."
                };
            }
        }

        // READ ALL
        public Transaction GetAllItems() {
            using (var db = _shoppingContext) {
                var items = db.Items
                    .ToList();

                if (!items.Any()) {
                    return new Transaction {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "No items",
                        MessageDetail = "No items found."
                    };
                }
                return new Transaction {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Ok",
                    MessageDetail = "Successfully retrieved items",
                    Items = items
                };
            }
        }

        // READ PER ID
        public Transaction GetItem(int itemId) {
            using (var db = _shoppingContext) {
                var item = db.Items
                    .Where(i => i.ItemId == itemId);
                if (!item.Any()) {
                    return new Transaction {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Not found",
                        MessageDetail = "Item with id: " + itemId + " not found.",
                    };
                }
                return new Transaction {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Ok",
                    MessageDetail = "Successfully found item with id: " + itemId + ".",
                    Item = item.First()
                };
            }
        }

        // UPDATE
        public Transaction UpdateItem(Item item) {
            using (var db = _shoppingContext) {
                var existingItem = db.Items
                    .Where(i => i.ItemId == item.ItemId);

                if (!existingItem.Any()) {
                    return new Transaction {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Not found",
                        MessageDetail = "Item with id: " + item.ItemId + " not found."
                    };
                }

                Item it = CheckIfItemExists(item, true);
                if (it != null) {
                    return new Transaction {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Item already exist",
                        MessageDetail = "It seems that you're trying to edit an existing into an item already in the database: " + it
                    };
                }

                existingItem.First().Name = item.Name;
                existingItem.First().Description = item.Description;
                existingItem.First().Price = item.Price;
                existingItem.First().Tag = item.Tag;
                db.SaveChanges();
                return new Transaction {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Ok",
                    MessageDetail = "Item with id: " + item.ItemId + " successfully updated."
                };
            }
        }

        // DELETE
        public Transaction DeleteItem(int itemId) {
            using (var db = _shoppingContext) {
                var existingItem = db.Items.
                    Where(i => i.ItemId == itemId);

                if (!existingItem.Any()) {
                    return new Transaction {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Not found",
                        MessageDetail = "Item with id: " + itemId + " not found."
                    };
                }
                db.Items.Remove(existingItem.First());
                db.SaveChanges();
                return new Transaction {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Ok",
                    MessageDetail = "Item with id: " + itemId + " successfully deleted."
                };
            }
        }

        private static Item CheckIfItemExists(Item item, bool isUpdating) {
            using (var db = new ShoppingContext()) {
                var items = db.Items;

                foreach (var i in items) {
                    // can only be item with different id
                    if (isUpdating) {
                        if (i.Name.Equals(item.Name) && i.ItemId != item.ItemId) {
                            return i;
                        }
                     // can be any item in db
                    } else {
                        if (i.Name.Equals(item.Name)) {
                            return i;
                        }
                    }
                }
            }
            return null;
        }
    }
}