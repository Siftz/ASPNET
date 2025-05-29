using System.Collections.Generic;
using System.Data;
using Dapper;
using Testing.Models;

namespace Testing.Data;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _conn;

    public ProductRepository(IDbConnection conn)
    {
        _conn = conn;
    }
        
    public IEnumerable<Product> GetAllProducts()
    {
        return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
    }

    public Product GetProduct(int id)
    {
        return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @ID;", new { ID = id }); 
    }

    public void UpdateProduct(Product product) // implement update product
    {
        _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
            new { name = product.Name, price = product.Price, id = product.ProductID });
        // found the error it was a '.' instead of a ',' after @name, and an extra space was added between @price,
        // also corrected ProductId to ProductID
        // re tested and this fixed the issue
        
    }

    public void InsertProduct(Product productToInsert) //insert product
    {
        _conn.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
            new {name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
    }

    public IEnumerable<Category> GetCategories() //get category
    {
            return _conn.Query<Category>("SELECT * FROM categories;");
    }
    

    public Product AssignCategory() //assign category
    {
        var categoryList = GetCategories();
        var product = new Product();
        product.Categories = categoryList;
        return product;
    }

    public void DeleteProduct(Product product) //implement for delete for covering
    {
        _conn.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;", new {id = product.ProductID });
        _conn.Execute("DELETE FROM Sales WHERE ProductID = @id;",  new { id = product.ProductID });
        _conn.Execute("DELETE FROM Products WHERE ProductID = @id;", new { id = product.ProductID });
    }
    
}