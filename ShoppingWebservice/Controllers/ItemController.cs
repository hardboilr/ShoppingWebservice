using System;
using System.Net;
using System.Web.Http;
using ShoppingWebservice.DTO;
using ShoppingWebservice.ErrorHandling;
using ShoppingWebservice.Models;
using ShoppingWebservice.Repositories;

namespace ShoppingWebservice.Controllers {

    [RoutePrefix("api/item")]
    public class ItemController : ApiController {

        private readonly ItemRepository _itemRepository;

        public ItemController() {
            _itemRepository = new ItemRepository();
        }

        [HttpPost]
        public IHttpActionResult CreateItem(Item item) {
            ResponseDTO responseDto;
            if (!ModelState.IsValid) {
                responseDto = new ResponseDTO {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = GetJsonMessage(),
                    MessageDetail = GetJsonDetailMessage(),
                    Errors = ModelState.AllErrors()
                };
                return Content(HttpStatusCode.BadRequest, responseDto);
            }
            responseDto = _itemRepository.CreateItem(item);
            return Content(responseDto.StatusCode, responseDto);
        }

        [Route("all")]
        public IHttpActionResult GetAllItems() {
            ResponseDTO responseDto = _itemRepository.GetAllItems();
            return Content(responseDto.StatusCode, responseDto);
        }

        [Route("{itemId}")]
        public IHttpActionResult GetItem(int itemId) {
            ResponseDTO responseDto = _itemRepository.GetItem(itemId);
            return Content(responseDto.StatusCode, responseDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateItem(Item item) {
            ResponseDTO responseDto;
            if (!ModelState.IsValid) {
                responseDto = new ResponseDTO {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = GetJsonMessage(),
                    MessageDetail = GetJsonDetailMessage(),
                    Errors = ModelState.AllErrors()
                };
                return Content(HttpStatusCode.BadRequest, responseDto);
            }
            responseDto = _itemRepository.UpdateItem(item);
            return Content(responseDto.StatusCode, responseDto);
        }

        [Route("{itemId}")]
        public IHttpActionResult DeleteItem(int itemId) {
            ResponseDTO responseDto = _itemRepository.DeleteItem(itemId);
            return Content(responseDto.StatusCode, responseDto);
        }

        private static string GetJsonMessage() {
            return "Invalid JSON request";
        }

        private static string GetJsonDetailMessage() {
            return "One or more errors was detected in received JSON. Please correct errors and try again.";
        }
    }
}
