using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingWebservice.Models {

    [Table("Category")]
    public class Category {

        [Key]
        public int CategoryId { get; set; }

        [StringLength(100)]
        [Required]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();

        public Category() { }

        public Category(string categoryName, string description) {
            CategoryName = categoryName;
            Description = description;
        }
    }
}