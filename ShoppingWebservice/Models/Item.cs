using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingWebservice.Models {
    public class Item {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public Category Category { get; set; }

        public Item() { }

        public Item(string name, string description, float price, Category category) {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}