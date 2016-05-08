using System.Collections.Generic;
using System.Net;
using ShoppingWebservice.ErrorHandling;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.DTO {
    public class ResponseDTO {

        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }
        public IEnumerable<Error> Errors { get; set; }
        public Cart Cart { get; set; }
        public List<Cart> Carts { get; set; }
        public Item Item { get; set; }
        public List<Item> Items { get; set; }
    }
}
