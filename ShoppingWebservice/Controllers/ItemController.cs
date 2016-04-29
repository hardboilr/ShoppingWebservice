using System.Net;
using System.Web.Http;
using ShoppingWebservice.DTO;
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
        public IHttpActionResult CreateItem(Item item) {
            if (!ModelState.IsValid) return Content(HttpStatusCode.BadRequest, ModelState);
            Transaction trans = _itemRepository.CreateItem(item);
            return Content(trans.StatusCode, trans);
        }

        [Route("all")]
        public IHttpActionResult GetAllItems() {
            Transaction trans = _itemRepository.GetAllItems();
            return Content(trans.StatusCode, trans);
        }

        [Route("{itemId}")]
        public IHttpActionResult GetItem(int itemId) {
            Transaction trans = _itemRepository.GetItem(itemId);
            return Content(trans.StatusCode, trans);
        }

        [HttpPut]
        public IHttpActionResult UpdateItem(Item item) {
            Transaction trans = _itemRepository.UpdateItem(item);
            return Content(trans.StatusCode, trans);
        }

        [Route("{itemId}")]
        public IHttpActionResult DeleteItem(int itemId) {
            Transaction trans = _itemRepository.DeleteItem(itemId);
            return Content(trans.StatusCode, trans);
        }
    }
}
