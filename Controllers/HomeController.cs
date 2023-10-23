using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using fun_viewmodel.Models;

namespace fun_viewmodel.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        var model = new HomePageViewModel
        {
            Message = "¡Bienvenido a la página principal!"
        };
        return View("Index", model);
    }

    [HttpGet]
    [Route("numbers")]
    public IActionResult Numbers()
    {
        var model = new NumbersPageViewModel
        {
            Numbers = new int[] { 1, 2, 3, 4, 5 }
        };
        return View("Numbers", model);
    }

    [HttpGet]
    [Route("users")]
    public IActionResult Users()
    {
        var users = new List<UserModel>
        {
            new UserModel { FirstName = "John", LastName = "Doe" },
            new UserModel { FirstName = "Alice", LastName = "Johnson" },
            new UserModel { FirstName = "Bob", LastName = "Smith" }
        };

        var model = new UsersPageViewModel
        {
            Users = users
        };
        return View("Users", model);
    }

    [HttpGet]
    [Route("user")]
    public new IActionResult User()
    {
        var user = new UserModel
        {
            FirstName = "Jane",
            LastName = "Doe"
        };

        var model = new UserPageViewModel
        {
            User = user
        };
        return View("User", model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
