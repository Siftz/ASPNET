using Mysqlx.Crud;
using Testing.Data;
using Testing.Models;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository repo;

    public ProductController(IProductRepository repo)
    {
        this.repo = repo;
    }

    public IActionResult Index()
    {
        var products = repo.GetAllProducts();
        return View(products);
    }

    public IActionResult ViewProduct(int id)
    {
        var product = repo.GetProduct(id);
        return View(product);
    }

    public IActionResult UpdateProduct(int id) // add controller method for update product
    {
        Product prod = repo.GetProduct(id);

        if (prod == null)
        {
            return View("ProductNotFound");
        }

        return View(prod);
    }

    public IActionResult UpdateProductToDatabase(Product product) //adding database update
    {
        repo.UpdateProduct(product);
        return RedirectToAction("ViewProduct", new { id = product.ProductID });
    }
    //exercise 4 added method for product insert
    public IActionResult InsertProduct()
    {
        var prod = repo.AssignCategory();
        return View(prod);
    }

    public IActionResult InsertProductToDatabase(Product productToInsert) // adds to database
    {
        repo.InsertProduct(productToInsert);
        return RedirectToAction("Index");
    }
}