using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GoogleAuth.Mvc.Models;
using Microsoft.AspNetCore.Authorization;

namespace GoogleAuth.Mvc.Controllers;

public class HomeController : Controller
{
    [AllowAnonymous]
    public IActionResult Index() => View();

    [Authorize]
    public IActionResult Privacy() => View();

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
