using System.ComponentModel.DataAnnotations.Schema;
using BusinessLayer.Contracts;
using BusinessLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace UIProject.Controllers;

public class AccountController : BaseController
{
    private readonly IUsersServices OuserServices;
    public AccountController(IUsersServices ouserServices)
    {
        OuserServices = ouserServices;
    }
    public  IActionResult LogIn(string? ReturnUrl)
    {
        TempData["ReturnUrl"] = ReturnUrl;
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LogIn(LogInUserDto model )
    {
        if (ModelState.IsValid)
        {
            UserResultDto result = await OuserServices.LogInAsync(model);
            if (result.IsSuccess)
            {
                string ? ReturnUrl = TempData["ReturnUrl"] as string;

                if (ReturnUrl is not null && ReturnUrl != "" && Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
        }
        return View(model);

    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterUserDto model)
    {
        if (ModelState.IsValid)
        {
            UserResultDto result = await OuserServices.RegisterAsync(model);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
        }
        return View(model);
    }

    [Authorize]
    public async Task<IActionResult> LogOut()
    {
        await OuserServices.LogOutAsync();
        return RedirectToAction("Index", "Home");
    }
    public IActionResult CheckEmailAndUsername()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CheckEmailAndUsername(UsersDto model)
    {
        if (ModelState.IsValid)
        {
            UserResultDto result = await OuserServices.CheckEmailAndUsername(model);
            if (result.IsSuccess)
            {
                TempData["AllowRestPassword"] = true;
                TempData["UserEmail"] = model.Email;
                return RedirectToAction("ChangePassword");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
        }
        return View(model);
        
    }
    public IActionResult ChangePassword( )
    {
        if (TempData["AllowRestPassword"] as bool? is true)
        {
            return View();
        }
        else
        {
            return RedirectToAction("AccessDenied");
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
    {
        if (ModelState.IsValid)
        {
            model.Email = TempData["UserEmail"] as string;
            UserResultDto result = await OuserServices.ChangePasswordAsync(model);
            if (result.IsSuccess)
            {
                return RedirectToAction("LogIn");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
        }
            return View(model);
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}
