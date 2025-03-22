using BusinessLayer.Contracts;
using BusinessLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UIProject.Controllers;

namespace UIProject.Areas.Admin.Controllers;

[Area("Admin"), Authorize(Roles = "admin")]
public class CountriesController : BaseController
{
    private readonly ICountriesServices OcountriesServices;
    public CountriesController(ICountriesServices countriesServices)
    {
        OcountriesServices = countriesServices;
    }
    public IActionResult Index()
    {
        var list = OcountriesServices.GetAll(true);
        return View(list);
    }
    public IActionResult Add()
    {

        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(CountriesDto model)
    {

        if (ModelState.IsValid)
        {
            OcountriesServices.Add(model);
        }
        else
        {
            return View(model);
        }
        return View();
    }
    public IActionResult ChangeStatus(string id)
    {
        OcountriesServices.ChangeCurrentStatus(id);
        return RedirectToAction("Index");
    }
    public IActionResult Edit(string id)
    {
        return View(OcountriesServices.GetById(id));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CountriesDto model)
    {
        if (ModelState.IsValid)
        {
            OcountriesServices.Update(model);
            return RedirectToAction("Index");
        }
        else
        {
            return View(model);
        }
    }
}
