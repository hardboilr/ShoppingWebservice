using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ShoppingWebservice.Models {
    public class AuthContex : IdentityDbContext<IdentityUser>
    {
        public AuthContex() : base("AuthContext") {
            
        }
    }
    
}