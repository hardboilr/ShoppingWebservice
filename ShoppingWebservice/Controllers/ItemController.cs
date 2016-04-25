using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private readonly ItemRepository _itemRepository;

        public ItemController() {
            _itemRepository = new ItemRepository(); ;
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage CreateItem(Item item) {
            if (ModelState.IsValid) {
                _itemRepository.CreateItem(item);
                return new HttpResponseMessage(HttpStatusCode.OK);
            } else {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
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
                //CategoryId = json.CategoryId
            };
            //return _itemRepository.UpdateItem(item.ItemId, item.Name, item.Description, item.Price, category.CategoryId);
            return null;
        }

        [HttpDelete]
        [Route("delete/{itemId}")]
        public Item DeleteItem(int itemId) {
            return _itemRepository.DeleteItem(itemId);
        }

        [HttpGet]
        [Route("all")]
        public IList<Item> GetAllItems() {
            return _itemRepository.GetAllItems();
        }

        [HttpGet]
        [Route("all/{categoryId}")]
        public IList<Item> GetallItemsByCategory(int categoryId) {
            return _itemRepository.GetAllItemsByCategory(categoryId);
        }

        [HttpGet]
        [Route("{itemId}")]
        public Item GetItem(int itemId) {
            return _itemRepository.GetItem(itemId);
        }

        // todo: move to category controller
        //[HttpGet]
        //[Route("category/{categoryName}")]
        //public Category GetCategory(string categoryName) {
        //    return _itemRepository.GetCategory(categoryName);
        //}
    }
}
