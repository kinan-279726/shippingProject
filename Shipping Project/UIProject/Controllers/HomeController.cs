using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UIProject.Models;
using BusinessLayer.DTO;
using BusinessLayer.Mapping;
using BusinessLayer.Contracts;
using Domains;

namespace UIProject.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> Ologger;
        private readonly  IShipmentTypeServices Oshipments;

        public HomeController(ILogger<HomeController> logger , IShipmentTypeServices shipments)
        {
            this.Oshipments = shipments;
            Ologger = logger;
        }

        public IActionResult Index()
        {
           var x =  Oshipments.GetAll();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
