using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingWebservice.Models {
    public interface IProductRepository {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAllByCategory(Category category);
        Product Get(int id);
        Product Add(Product item);
        void Remove(int id);
        bool Update(Product item);
    }
}
