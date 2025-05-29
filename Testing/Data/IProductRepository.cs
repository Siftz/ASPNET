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
        //adding stubbed out method for start of exercise 5
        public void DeleteProduct(Product product);
    }
}