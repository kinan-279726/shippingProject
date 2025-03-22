using System.Linq.Expressions;
using System.Security.Claims;
using BusinessLayer.Contracts;
using BusinessLayer.DTO;
using DataAccess.Exceptions;
using DataAccess.Repositorys;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Resources;

namespace BusinessLayer.Services;

public class UserServices : BaseTable, IUsersServices
{
    private readonly SignInManager<TbUsers> OsignInManager;
    private readonly UserManager<TbUsers> OuserManager;
    private readonly HttpContextAccessor OhttpContextAccessor;

    public UserServices(SignInManager<TbUsers> osignInManager, UserManager<TbUsers> ouserManager , HttpContextAccessor httpContextAccessor)
    {
        OhttpContextAccessor = httpContextAccessor;
        OsignInManager = osignInManager;
        OuserManager = ouserManager;
    }

    public async Task<List<UsersDto>> GetAllUsersAsync()
    {
        return await OuserManager.Users.Select(user => new UsersDto
        {

            Id = user.Id,
            Email  = user.Email,
            UserName = user.UserName
        }).ToListAsync();
    }

    public async Task<UsersDto> GetUserByIdAsync(string id)
    {
       TbUsers? user =  await OuserManager.FindByIdAsync(id);
        if (user is not null)
        {
            return new UsersDto()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName
            };
        }
        else return null;
    }

    public async Task<UserResultDto> LogInAsync(LogInUserDto model)
    {
        TbUsers ? user = await OuserManager.FindByEmailAsync(model.Email);
        if (user is not null)
        {
            var result = await OsignInManager.PasswordSignInAsync(user.UserName, model.Password, model.rememberMy, true);
            if (result.Succeeded)
            {
                return new UserResultDto() { IsSuccess = result.Succeeded };
            }
        }
        return new UserResultDto() { IsSuccess = false ,Errors = new List<string> { ResMessages.InvalidUsernameOrPassword } };
    }

    public async Task LogOutAsync()
    {
        await OsignInManager.SignOutAsync();
    }

    public async Task<UserResultDto> RegisterAsync(RegisterUserDto model)
    {
        TbUsers user = new TbUsers()
        {
            UserName = model.UserName,
            Email = model.Email,
        };
    
        var result = await OuserManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await OuserManager.AddToRoleAsync(user, "user");
            await OsignInManager.PasswordSignInAsync(user, model.Password, true, true);
            return new UserResultDto() {IsSuccess = true};
        }
        else
        {
            return new UserResultDto()
            {
                IsSuccess = result.Succeeded,
                Errors = result.Errors?.Select(a => a.Description).ToList()
            };
        }
        
    }
    public string GetCrruntUser()
    { 
        return OhttpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
    public async Task<UserResultDto> CheckEmailAndUsername(UsersDto model)
    {
        TbUsers? user = await OuserManager.FindByEmailAsync(model.Email);
        if (user is not null)
        {
            if (user.Email == model.Email && user.UserName == model.UserName)
            {
                return new UserResultDto { IsSuccess = true };
            }
        }
        return new UserResultDto { IsSuccess = false, Errors = new List<string>() { ResMessages.InvalidUsernameOrEmail } };
    }
    public async Task<UserResultDto> ChangePasswordAsync(ChangePasswordDto model)
    {
        TbUsers? user = await OuserManager.FindByEmailAsync(model.Email);
        if (user is not null)
        {
           var result = await OuserManager.RemovePasswordAsync(user);
            if(result.Succeeded)
            {
                result = await OuserManager.AddPasswordAsync(user, model.Password);
                if (result.Succeeded)
                {
                return new UserResultDto { IsSuccess = true };
                }
                else
                {
                    return new UserResultDto()
                    {
                        IsSuccess = result.Succeeded,
                        Errors = result.Errors?.Select(a => a.Description).ToList()
                    };
                }
            }
            else
            {
                return new UserResultDto()
                {
                    IsSuccess = result.Succeeded,
                    Errors = result.Errors?.Select(a => a.Description).ToList()
                };
            }
        }
        return new UserResultDto { IsSuccess = false, Errors = new List<string>() { ResMessages.InvalidUsernameOrEmail } };
    }
}

