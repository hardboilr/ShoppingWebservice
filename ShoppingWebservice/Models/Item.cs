using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using ShoppingWebservice.JsonConverters;

namespace ShoppingWebservice.Models {

    [JsonConverter(typeof(ItemJson))]
    [Table("Item")]
    public class Item {

        [Key]
        public int ItemId { get; set; }

        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();

        public Item() { }

        public Item(string name, string description, float price, List<Category> categories) {
            Name = name;
            Description = description;
            Price = price;
            Categories = categories;
        }

        public override string ToString() {
            string categories = "";
            foreach (Category category in Categories) {
                categories += "\n";
                categories += category.CategoryName;
                categories += ", " + category.Description;
            }

            return base.ToString() + ": " + ItemId + ", " + Name + ", " + Description + ", " + Price + ", Categories: " + categories;
        }
    }
}