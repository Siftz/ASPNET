using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers;

public class ClassController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}