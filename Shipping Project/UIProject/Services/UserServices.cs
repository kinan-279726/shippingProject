using BusinessLayer.Contracts;
using BusinessLayer.DTO;
using DataAccess.Exceptions;
using DataAccess.Repositorys;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Resources;

namespace BusinessLayer.Services;

public class UserServices : BaseTable, IUsersServices
{
    private readonly SignInManager<TbUsers> OsignInManager;
    private readonly UserManager<TbUsers> OuserManager;

    public UserServices(SignInManager<TbUsers> osignInManager, UserManager<TbUsers> ouserManager)
    {
        OsignInManager = osignInManager;
        OuserManager = ouserManager;
    }

    public Task<IEnumerable<UsersDto>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<UsersDto> GetUserByIdAsync(string id)
    {
       var user =  await OuserManager.FindByIdAsync(id);
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
        var user = await OuserManager.FindByEmailAsync(model.Email);
        if (user is not null)
        {
            var result = await OsignInManager.PasswordSignInAsync(user.UserName, model.Password, model.rememberMy, true);
            if (result.Succeeded)
            {
                return new UserResultDto() { IsSuccess = result.Succeeded };
            }
        }
        List<string> error = new List<string>();
        error.Add(ResMessages.InvalidUsernameOrPassword);
        return new UserResultDto() { IsSuccess = false ,Errors = error };
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
            //var role = await OUserManager.AddToRoleAsync(identityUser, "User");
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
}

