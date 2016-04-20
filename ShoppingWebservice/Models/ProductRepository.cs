using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingWebservice.Models {
    public class ProductRepository : IProductRepository {
        private List<Product> products = new List<Product>();
        private int _nextId = 1;

        public ProductRepository() {
            Add(new Product { Id = 1, Name = "Tomato Soup", Category = Category.FOOD, Price = 1 });
            Add(new Product { Id = 2, Name = "Milk", Category = Category.DAIRY, Price = 3.75M });
            Add(new Product { Id = 3, Name = "Cheese", Category = Category.DAIRY, Price = 16.99M });
        }

        public IEnumerable<Product> GetAll() {
            
            return products;
        }

        public Product Get(int id) {
            return products.Find(p => p.Id == id);
        }

        public Product Add(Product item) {
            if (item == null) {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            products.Add(item);
            return item;
        }

        public void Remove(int id) {
            products.RemoveAll(p => p.Id == id);
        }

        public bool Update(Product item) {
            if (item == null) {
                throw new ArgumentNullException("item");
            }
            int index = products.FindIndex(p => p.Id == item.Id);
            if (index == -1) {
                return false;
            }
            products.RemoveAt(index);
            products.Add(item);
            return true;
        }

        public IEnumerable<Product> GetAllByCategory(Category category) {
            return null;
        }
    }
}