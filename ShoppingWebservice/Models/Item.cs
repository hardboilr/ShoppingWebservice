using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using ShoppingWebservice.JsonConverters;

namespace ShoppingWebservice.Models {

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

        public Item(string name, string description, float price) {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}