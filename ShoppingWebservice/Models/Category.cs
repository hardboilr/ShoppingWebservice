using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingWebservice.Models {
    public class Category {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; } 

        public Category() { }

        public Category(string categoryName, string description) {
            CategoryName = categoryName;
            Description = description;
        }
    }
}