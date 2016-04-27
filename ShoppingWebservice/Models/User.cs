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

        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

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

        public User(string userName, string passWord, string firstName, string lastName, string email, string address) {
            UserName = userName;
            Password = passWord;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        }

        public override string ToString() {
            return base.ToString();
        }
    }
}