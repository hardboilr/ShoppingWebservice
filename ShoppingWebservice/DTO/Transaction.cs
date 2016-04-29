using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.DTO {
    public class Transaction {

        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }
        public Cart Cart { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
