using BusinessLayer.Contracts;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UIProject.Controllers;

namespace UIProject.Areas.Admin.Controllers;

[Area("Admin"), Authorize(Roles ="admin")]
public class HomeController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
