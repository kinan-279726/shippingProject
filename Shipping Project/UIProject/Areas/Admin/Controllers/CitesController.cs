using BusinessLayer.Contracts;
using BusinessLayer.DTO;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIProject.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "admin")]
    public class CitesController : Controller
    {
        private readonly IViewCitesServices OviewCitesServices;
        private readonly ICitiesServices OcitiesServices;
        private readonly ICountriesServices OcountriesServices;
        public CitesController(IViewCitesServices viewCitesServices , ICitiesServices citiesServices , ICountriesServices countriesServices  )
        {
            OcountriesServices = countriesServices;
            OcitiesServices = citiesServices;
            OviewCitesServices = viewCitesServices;
        }
        public IActionResult Index()
        {
            
            var list = OviewCitesServices.GetAll().OrderBy(a => a.CountryArabicName).ToList();
            return View(list);
        }
        public IActionResult Add()
        {
            ViewBag.Countries = OcountriesServices.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(VwCitesDto model)
        {

            if (ModelState.IsValid)
            {
                OcitiesServices.Add(new CitesDto
                {
                    Id = model.CityId,
                    CityArabicName = model.CityArabicName,
                    CityEnglithName = model.CityEnglithName,
                    CountryId = model.CountryId
                });
            }
            else
            {
                return View( "Add", model);
            }
            return RedirectToAction("Add");
        }
        public IActionResult ChangeStatus(string id)
        {
            OcitiesServices.ChangeCurrentStatus(id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(string id)
        {
            ViewBag.Countries = OcountriesServices.GetAll();
            var model = OviewCitesServices.GetAll().FirstOrDefault(a => a.CityId == id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VwCitesDto model)
        {
            if (ModelState.IsValid)
            {
                OcitiesServices.Update(new CitesDto
                {
                    Id = model.CityId,
                    CityArabicName = model.CityArabicName,
                    CityEnglithName = model.CityEnglithName,
                    CountryId = model.CountryId
                });
            }
            else
            {
                return View("Add", model);
            }
            return RedirectToAction("Index");
        }
    }
}
