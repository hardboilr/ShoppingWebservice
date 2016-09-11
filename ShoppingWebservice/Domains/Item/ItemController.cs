using static ShoppingWebservice.Shared.Config.ClientMessages;
using static ShoppingWebservice.Shared.Config.ResponseHandler;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ShoppingWebservice.Domains.Item.Repository;
using ShoppingWebservice.ErrorHandling;
using ShoppingWebservice.Shared.DTOs;
using ShoppingWebservice.Shared.ErrorHandling;

namespace ShoppingWebservice.Domains.Item {

    [RoutePrefix("api/item")]
    public class ItemController : ApiController {

        private readonly ItemRepository repo;

        public ItemController() {
            repo = new ItemRepository();
        }

        [HttpPost]
        public IHttpActionResult CreateItem(Item item) {

            if (!ModelState.IsValid) {
                ResponseDto responseDto = new ResponseDto {
                    Message = GetJsonMessage(),
                    Errors = ModelState.AllErrors()
                };
                return Content(HttpStatusCode.BadRequest, responseDto);
            }

            ErrorDto error;
            repo.CreateItem(item, out error);

            if (error != null) {
                return ErrorResponse(error, this);
            }

            return SuccessResponse(new ResponseDto {Message= SuccessCreate(repo.DomainNameSingular)}, this);
        }

        [Route("all")]
        public IHttpActionResult GetAllItems() {
            ErrorDto error;
            List<Item> result = repo.GetAllItems(out error);

            if (error != null) {
                return ErrorResponse(error, this);
            }

            List<ItemDto> dtos = result
                .Select(item => new ItemDto {
                    ItemId = item.ItemId,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Tag = item.Tag,
                    CartItems = item.CartItems
                }).ToList();

            return SuccessResponse(new ResponseDto { Message = ContentMsg(repo.DomainNamePlural), Data = dtos }, this);
        }

        [Route("{itemId}")]
        public IHttpActionResult GetItem(int itemId) {
            ErrorDto error;
            Item item = repo.GetItem(itemId, out error);

            if (error != null) {
                return ErrorResponse(error, this);
            }

            ItemDto dto = new ItemDto {
                ItemId = item.ItemId,
                Description = item.Description,
                Name = item.Name,
                Price = item.Price,
                Tag = item.Tag,
                CartItems = item.CartItems
            };

            return SuccessResponse(new ResponseDto { Message = ContentMsg(repo.DomainNameSingular, item.Name)}, this);
        }

        [HttpPut]
        public IHttpActionResult UpdateItem(Item item) {

            if (!ModelState.IsValid) {
                ResponseDto dto = new ResponseDto {
                    Message = GetJsonMessage(),
                    Errors = ModelState.AllErrors()
                };
                return Content(HttpStatusCode.BadRequest, dto);
            }

            ErrorDto error;
            repo.UpdateItem(item, out error);

            if (error != null) {
                return ErrorResponse(error, this);
            }

            return SuccessResponse(new ResponseDto {Message = SuccessUpdate(item.Name)}, this);
        }

        [Route("{itemId}")]
        public IHttpActionResult DeleteItem(int itemId) {
            ErrorDto error;

            repo.DeleteItem(itemId, out error);

            if (error != null) {
                return ErrorResponse(error, this);
            }

            return SuccessResponse(new ResponseDto {Message = SuccessDelete(itemId.ToString())}, this);
        }

        private static string GetJsonMessage() {
            return "Invalid JSON request";
        }

        private static string GetJsonDetailMessage() {
            return "One or more errors was detected in received JSON. Please correct errors and try again.";
        }
    }
}
