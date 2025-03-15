using System.ComponentModel.DataAnnotations.Schema;
using BusinessLayer.Contracts;
using BusinessLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UIProject.Controllers;

namespace UIProject.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Roles ="admin")]
    public class ShippingTypeController : BaseController
    {
        private readonly IShipmentTypeServices OShipmentTypeServices;
        public ShippingTypeController(IShipmentTypeServices ShipmentTypeServices)
        {
            OShipmentTypeServices = ShipmentTypeServices;
        }
        public IActionResult Index()
        {
            var list = OShipmentTypeServices.GetAll(true);
            return View(list);
        }
        public IActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ShipmentTypeDto model)
        {
            
            if (ModelState.IsValid)
            {
                 OShipmentTypeServices.Add(model); 
            }else
            {
                return View(model);
            }
            return View();
        }
        public IActionResult ChangeStatus(string id )
        {
            OShipmentTypeServices.ChangeCurrentStatus(id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(string id)
        {
            return View(OShipmentTypeServices.GetById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ShipmentTypeDto model)
        {
            OShipmentTypeServices.Update(model );
            return RedirectToAction("Index");
        }
    }
}
