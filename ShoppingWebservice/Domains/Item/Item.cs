using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.Domains.Item {

    [Table("Item")]
    public class Item {

        //[Key]
        public int ItemId { get; set; }

        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        // http://stackoverflow.com/questions/9558549/validate-decimal-value-to-2-decimal-places-with-data-annotations
       
        //[Range(0.01, 100000000)]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Price can't have more than 2 decimal places")]
        [Required]
        public decimal? Price { get; set; }

        [Required]
        public string  Tag { get; set; }

        public List<CartItem> CartItems { get; set; } 

        public Item() { }

        public Item(string name, string description, decimal price, string tag) {
            Name = name;
            Description = description;
            Price = price;
            Tag = tag;
        }

        // http://www.newtonsoft.com/json/help/html/SerializationGuide.htm
        // will not serialize CartItems, thereby not returning it in json-response body
        public bool ShouldSerializeCartItems() {
            return false;
        }

        public override string ToString() {
            return "Item: " + ItemId + ", " + Name + ", " + Description + ", " + Price + ", " + Tag;
        }
    }
}