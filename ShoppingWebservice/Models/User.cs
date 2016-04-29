using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ShoppingWebservice.Models {

    [Table("User")]
    public class User {

        [Key]
        public int UserId { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [StringLength(100)]
        [Required]
        public string Email { get; set; }

        [StringLength(200)]
        [Required]
        public string Address { get; set; } //ex. "Smallegade 46A, 2. th., 2000 Frederiksberg"

        public IList<Cart> Carts { get; set; } = new List<Cart>();

        public User() { }

        public User(string firstName, string lastName, string email, string address) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        }

        // will not serialize Carts, thereby not returning it in json-response body
        public bool ShouldSerializeCarts() {
            return false;
        }

    }
}