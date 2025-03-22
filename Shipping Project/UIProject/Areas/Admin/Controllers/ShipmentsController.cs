using BusinessLayer.Contracts;
using BusinessLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UIProject.Controllers;

namespace UIProject.Areas.Admin.Controllers;

[Area("Admin"), Authorize(Roles ="admin")]
public class ShipmentsController : BaseController
{
    private readonly IViewShipmentsServices OviewShipmentsServices;
    private readonly IShipmentsServices OshipmentsServices;
    private readonly ICitiesServices OcitiesServices;
    private readonly IUsersServices OusersServices;
    public ShipmentsController(IUsersServices usersServices, ICitiesServices citiesServices, IShipmentsServices shipmentsServices1, IViewShipmentsServices viewShipmentsServices , IShipmentsServices shipmentsServices)
    {
        OusersServices = usersServices;
        OcitiesServices = citiesServices;
        OshipmentsServices = shipmentsServices1;
        OshipmentsServices = shipmentsServices;
        OviewShipmentsServices = viewShipmentsServices;
    }
    public IActionResult Index()
    {
        List<VwShipmentDto> list = OviewShipmentsServices.GetAll();
        return View(model: list);
    }
    public async Task<IActionResult> Add()
    {
        ViewBag.users = await OusersServices.GetAllUsersAsync();

        ViewBag.cites = OcitiesServices.GetAll();

        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(ShipmentsDto model)
    {
        if (ModelState.IsValid)
        {
            //OshipmentsServices.Add(model);
        }

        return View();
    }
}
