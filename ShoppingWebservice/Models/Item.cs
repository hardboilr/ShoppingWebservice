using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingWebservice.Models {

    [Table("Item")]
    public class Item {

        //[Key]
        public int ItemId { get; set; }

        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public string  Tag { get; set; }

        public List<CartItem> CartItems { get; set; } 

        public Item() { }

        public Item(string name, string description, float price, string tag) {
            Name = name;
            Description = description;
            Price = price;
            Tag = tag;
        }

        public override string ToString() {
            return "Item: " + ItemId + ", " + Name + ", " + Description + ", " + Price + ", " + Tag;
        }
    }
}