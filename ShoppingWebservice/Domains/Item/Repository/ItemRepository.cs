using static ShoppingWebservice.Shared.Config.ClientMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingWebservice.Models;
using ShoppingWebservice.Shared.DTOs;
using ShoppingWebservice.Shared.ErrorHandling;

namespace ShoppingWebservice.Domains.Item.Repository {

    public class ItemRepository {

        private readonly ShoppingContext _shoppingContext;
        private readonly Type _classType = typeof(ItemRepository);
        public string DomainNameSingular { get; } = "item";
        public string DomainNamePlural = "items";

        public ItemRepository() {
            _shoppingContext = new ShoppingContext();
        }

        // CREATE
        public void CreateItem(Item item, out ErrorDto error) {
            error = null;

            using (var db = _shoppingContext) {
                // check for existing items with same name
                Item it = CheckIfItemExists(item, false);

                if (it != null) {
                    error = new ErrorDto {
                        ErrorMsg = ExistMsg("item"),
                        ErrorWhen = "when attempting to create new item with id: " + item.ItemId,
                        ClassType = _classType,
                        ErrorType = ErrorType.KeyExistError,
                    };
                    return;
                }
                db.Items.Add(item);
                db.SaveChanges();
            }
        }

        // READ ALL
        public List<Item> GetAllItems(out ErrorDto error) {
            error = null;

            using (var db = _shoppingContext) {

                List<Item> i = db.Items.ToList();

                if (!i.Any()) {
                    error = new ErrorDto {
                        ErrorMsg = NotFoundMsg(DomainNamePlural),
                        ErrorWhen = "when attempting to get all item entities from database",
                        ClassType = typeof(ItemRepository),
                        ErrorType = ErrorType.EmptyTableError
                    };
                }
                return i;
            }
        }

        // READ PER ID
        public Item GetItem(int itemId, out ErrorDto error) {
            error = null;

            using (var db = _shoppingContext) {
                var item = db.Items
                    .Where(i => i.ItemId == itemId);

                if (!item.Any()) {
                    error = new ErrorDto {
                        ErrorMsg = NotFoundMsg(DomainNameSingular, itemId.ToString()),
                        ErrorWhen = "when attempting to get item with id: " + itemId,
                        ErrorType = ErrorType.EntryNotFoundError,
                        ClassType = _classType
                    };
                }
                return item.First();
            }
        }

        // UPDATE
        public void UpdateItem(Item item, out ErrorDto error) {
            error = null;

            using (var db = _shoppingContext) {
                var existingItem = db.Items
                    .Where(i => i.ItemId == item.ItemId);

                if (!existingItem.Any()) {
                    error = new ErrorDto {
                        ErrorMsg = NotFoundMsg(DomainNameSingular, item.ItemId.ToString()),
                        ErrorWhen = "when attempting to update an existing item with id: " + item.ItemId,
                        ErrorType = ErrorType.EntryNotFoundError,
                        ClassType = _classType
                    };
                    return;
                }

                Item it = CheckIfItemExists(item, true);

                if (it != null) {

                    error = new ErrorDto {
                        ErrorMsg = ExistMsg(item.Name),
                        ErrorWhen = "when attempting to update an existing item with id: " + item.ItemId,
                        ErrorType = ErrorType.KeyExistError,
                        ClassType = _classType
                    };
                    return;
                }

                existingItem.First().Name = item.Name;
                existingItem.First().Description = item.Description;
                existingItem.First().Price = item.Price;
                existingItem.First().Tag = item.Tag;
                db.SaveChanges();
            }
        }

        // DELETE
        public void DeleteItem(int itemId, out ErrorDto error) {
            error = null;

            using (var db = _shoppingContext) {

                var existingItem = db.Items
                    .Where(i => i.ItemId == itemId);

                if (!existingItem.Any()) {

                    error = new ErrorDto {
                        ErrorMsg = NotFoundMsg(itemId.ToString()),
                        ErrorWhen = "when attempting to delete an existing item with id: " + itemId,
                        ErrorType = ErrorType.EntryNotFoundError,
                        ClassType = _classType
                    };
                    return;
                }

                db.Items.Remove(existingItem.First());
                db.SaveChanges();
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