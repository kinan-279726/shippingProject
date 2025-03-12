using System.ComponentModel.DataAnnotations.Schema;
using BusinessLayer.Contracts;
using BusinessLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using UIProject.Controllers;

namespace UIProject.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            model.Id = Guid.NewGuid().ToString();
            if (ModelState.IsValid)
            {
                 OShipmentTypeServices.Add(model, Guid.NewGuid().ToString()); 
            }else
            {
                return View(model);
            }
            return View();
        }
        public IActionResult ChangeStatus(string id )
        {
            OShipmentTypeServices.ChangeCurrentStatus(id,Guid.NewGuid().ToString());
            return RedirectToAction("Index");
        }
        public IActionResult Edit(string id)
        {
            return View(OShipmentTypeServices.GetById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditShipmentType(ShipmentTypeDto model)
        {
            OShipmentTypeServices.Update(model , Guid.NewGuid().ToString());
            return RedirectToAction("Index");
        }
    }
}
