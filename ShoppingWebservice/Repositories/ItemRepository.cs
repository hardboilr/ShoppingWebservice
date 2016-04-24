using System.Collections.Generic;
using System.Linq;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.Repositories {
    public class ItemRepository {



        public Item CreateItem(string categoryName, string categoryDescription, string itemName, string itemDescription, float itemPrice) {
            Item returnItem = null;
            using (var db = new ShoppingContext()) {
                Category category = null;
                var categories = from c in db.Categories where c.CategoryName == categoryName select c;
                category = categories.GetEnumerator().Current;
                if (category == null) {
                    category = new Category(categoryName, categoryDescription);
                }
                db.Categories.Add(category);
                Item item = new Item(itemName, itemDescription, itemPrice, category);
                db.Items.Add(item);
                db.SaveChanges();
                returnItem = item;
            }
            return returnItem;
        }

        public Item UpdateItem(int itemId, string itemName, string itemDescription, float itemPrice, int categoryId) {
            Item returnItem = null;
            using (var db = new ShoppingContext()) {
                var item = db.Items.Find(itemId);
                var category = db.Categories.Find(categoryId);
                if (item != null && category != null) {
                    item.Name = itemName;
                    item.Description = itemDescription;
                    item.Price = itemPrice;
                    item.Category = category;
                    db.SaveChanges();
                    returnItem = item;
                }
            }
            return returnItem;
        }

        public Item DeleteItem(int itemId) {
            Item returnItem = null;
            using (var db = new ShoppingContext()) {
                var item = db.Items.Find(itemId);
                db.Items.Remove(item);
                db.SaveChanges();
                returnItem = item;
            }
            return returnItem;
        }

        public IList<Item> GetAllItems() {
            IList<Item> returnItems = null;
            using (var db = new ShoppingContext()) {
                var items = from i in db.Items select i;
                IList<Item> itemsList = items.ToList();
                returnItems = itemsList;
            }
            return returnItems;
        }

        public IList<Item> GetAllItemsByCategory(int categoryId) {
            IList<Item> returnItems = null;
            using (var db = new ShoppingContext()) {
                var items = from i in db.Items where i.Category.CategoryId.Equals(categoryId) select i;
                returnItems = items.ToList();
            }
            return returnItems;
        }

        public Item GetItem(int itemId) {
            Item returnItem = null;
            using (var db = new ShoppingContext()) {
                var item = db.Items.Find(itemId);
                returnItem = item;
            }
            return returnItem;
        }

        public Category GetCategory(string categoryName) {
            Category returnCategory = null;
            using (var db = new ShoppingContext()) {
                var categories = from c in db.Categories where c.CategoryName == categoryName select c;
                returnCategory = categories.GetEnumerator().Current;
            }
            return returnCategory;
        }

    }
}