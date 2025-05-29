using System.Collections.Generic;
using Testing.Models;

namespace Testing.Data
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();

        //exercise 2 start
        Product GetProduct(int id);

        //exercise 3 start
        void UpdateProduct(Product product);
        
        //exercise 4 insert
        public void InsertProduct(Product productToInsert);
        public IEnumerable<Category> GetCategories();
        public Product AssignCategory();
    }
}