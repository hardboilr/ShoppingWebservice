using System.Collections.Generic;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.Domains.Item {

    public class ItemDto {

        public int ItemId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public string Tag { get; set; }

        public List<CartItem> CartItems { get; set; }

    }
}