using BusinessLayer.Contracts;
using BusinessLayer.DTO;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UIProject.Controllers;

namespace UIProject.Areas.Admin.Controllers;

[Area("Admin") , Authorize(Roles ="admin")]
public class ShipmentItemsController : BaseController
{
    private readonly IShipmentItemsServices OshipmentItemsServices;
    public ShipmentItemsController(IShipmentItemsServices shipmentItemsServices)
    {
        OshipmentItemsServices = shipmentItemsServices;
    }
    public IActionResult Index(string shipmentId)
    {
        List<ShipmentItemsDto> items = OshipmentItemsServices.GetByShipmentItems(shipmentId);
        return View(items);
    }
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(ShipmentItemsDto model)
    {

        if (ModelState.IsValid)
        {
            OshipmentItemsServices.Add(model);
        }
        else
        {
            return View(model);
        }
        return View();
    }
    public IActionResult ChangeStatus(string id)
    {
        OshipmentItemsServices.ChangeCurrentStatus(id);
        return RedirectToAction("Index");
    }
    public IActionResult Edit(string id)
    {
        return View(OshipmentItemsServices.GetById(id));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(ShipmentItemsDto model)
    {
        if (ModelState.IsValid)
        { 
            OshipmentItemsServices.Update(model);
            return RedirectToAction("Index", "ShipmentItems");
        }
        else
        {
            return View(model);
        }
    }
}
