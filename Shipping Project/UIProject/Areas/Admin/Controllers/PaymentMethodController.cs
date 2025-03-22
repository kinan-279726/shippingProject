using BusinessLayer.Contracts;
using BusinessLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using UIProject.Controllers;

namespace UIProject.Areas.Admin.Controllers;

[Area("Admin"), Authorize(Roles = "admin")]

public class PaymentMethodController : BaseController
{
    private readonly IPaymentMethodServices OpaymentMethodServices;
    public PaymentMethodController(IPaymentMethodServices paymentMethodServices)
    {
        OpaymentMethodServices = paymentMethodServices;
    }
    public IActionResult Index()
    {
        var list = OpaymentMethodServices.GetAll(true);
        return View(list);
    }
    public IActionResult Add()
    {

        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(PaymentMethodDto model)
    {

        if (ModelState.IsValid)
        {
            OpaymentMethodServices.Add(model);
        }
        else
        {
            return View(model);
        }
        return View();
    }
    public IActionResult ChangeStatus(string id)
    {
        OpaymentMethodServices.ChangeCurrentStatus(id);
        return RedirectToAction("Index");
    }
    public IActionResult Edit(string id)
    {
        return View(OpaymentMethodServices.GetById(id));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(PaymentMethodDto model)
    {
        if (ModelState.IsValid)
        {
            OpaymentMethodServices.Update(model);
            return RedirectToAction("Index");
        }
        else
        {
            return View(model);
        }
    }
}
