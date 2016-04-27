using System.Collections.Generic;
using System.Net;
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

        [Route("create")]
        public IHttpActionResult CreateItem(Item item) {
            if (ModelState.IsValid) {
                string message = _itemRepository.CreateItem(item);
                dynamic responseBody = new JObject();

                if (message.Length <= 0) {
                    responseBody.message = item.Name + " created successfully.";
                    return Content(HttpStatusCode.OK, responseBody);
                } else {
                    responseBody.message = message;
                    return Content(HttpStatusCode.BadRequest, responseBody);
                }
            } else {
                return Content(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route("all")]
        public IHttpActionResult GetAllItems() {
            List<Item> items = _itemRepository.GetAllItems();

            if (items.Count == 0) {
                dynamic responseBody = new JObject();
                responseBody.message = "No items found in database.";
                return Content(HttpStatusCode.BadRequest, responseBody);
            } else {
                return Content(HttpStatusCode.OK, items);
            }
        }

        [Route("{itemId}")]
        public IHttpActionResult GetItem(int itemId) {
            Item item = _itemRepository.GetItem(itemId);

            if (item == null) {
                dynamic responseBody = new JObject();
                responseBody.message = "No item found with itemId: " + itemId + ".";
                return Content(HttpStatusCode.BadRequest, responseBody);
            } else {
                return Content(HttpStatusCode.OK, item);
            }
        }

        [Route("update")]
        public IHttpActionResult UpdateItem(Item item) {
            bool success = _itemRepository.UpdateItem(item);
            dynamic responseBody = new JObject();

            if (success) {
                responseBody.message = "Successfully updated: " + item.Name + ".";
                return Content(HttpStatusCode.OK, responseBody);
            } else {
                responseBody.message = "Item with id: " + item.ItemId + " not found.";
                return Content(HttpStatusCode.BadRequest, responseBody);
            }
        }

        [Route("delete/{itemId}")]
        public IHttpActionResult DeleteItem(int itemId) {
            bool success = _itemRepository.DeleteItem(itemId);
            dynamic responseBody = new JObject();

            if (success) {
                responseBody.message = "Successfully deleted item with id: " + itemId + ".";
                return Content(HttpStatusCode.OK, responseBody);
            } else {
                responseBody.message = "Item with id: " + itemId + " not found.";
                return Content(HttpStatusCode.BadRequest, responseBody);
            }
        }

    }
}
