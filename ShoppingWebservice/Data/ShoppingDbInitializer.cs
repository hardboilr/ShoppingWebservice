using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.Data {
    // source: http://www.entityframeworktutorial.net/code-first/seed-database-in-code-first.aspx
    // https://edspencer.me.uk/2012/10/30/seed-data-from-sql-scripts-using-entity-framework-migrations-ef-4-3/

    public class ShoppingDbInitializer : DropCreateDatabaseAlways<ShoppingContext> {
    }
}