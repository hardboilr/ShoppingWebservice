using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using ShoppingWebservice.Models;
using ShoppingWebservice.Repositories;

namespace ShoppingWebservice.Controllers {
    [RoutePrefix("api/item")]
    public class ItemController : ApiController {

        private ItemRepository itemRepository;

        public ItemController() {
            itemRepository = new ItemRepository(); ;
        }

        [HttpPost]
        [Route("create")]
        public Item CreateItem(JObject data) {
            dynamic json = data;

            List<Category> categories = new List<Category>(json.Categories); // måske for-loop virker bedre...

            Category category = new Category() {
                CategoryName = json.CategoryName,
                Description = json.CategoryDescription
            };
            Item item = new Item() {
                Name = json.ItemName,
                Description = json.ItemDescription,
                Price = json.ItemPrice
            };
            return itemRepository.CreateItem(category.CategoryName, category.Description, item.Name, item.Description, item.Price);
        }

        [HttpPut]
        [Route("update")]
        public Item UdpateItem(JObject data) {
            dynamic json = data;
            Item item = new Item() {
                ItemId = json.ItemId,
                Name = json.ItemName,
                Description = json.ItemDescription,
                Price = json.ItemPrice
            };
            Category category = new Category() {
                CategoryId = json.CategoryId
            };
            return itemRepository.UpdateItem(item.ItemId, item.Name, item.Description, item.Price, category.CategoryId);
        }

        [HttpDelete]
        [Route("delete/{itemId}")]
        public Item DeleteItem(int itemId) {
            return itemRepository.DeleteItem(itemId);
        }

        [HttpGet]
        [Route("all")]
        public IList<Item> GetAllItems() {
            return itemRepository.GetAllItems();
        }

        [HttpGet]
        [Route("all/{categoryId}")]
        public IList<Item> GetallItemsByCategory(int categoryId) {
            return itemRepository.GetAllItemsByCategory(categoryId);
        }

        [HttpGet]
        [Route("getitem/{itemId}")]
        public Item GetItem(int itemId) {
            return itemRepository.GetItem(itemId);
        }

        [HttpGet]
        [Route("getcategory/{categoryName}")]
        public Category GetCategory(string categoryName) {
            return itemRepository.GetCategory(categoryName);
        }
    }
}
