using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using Domains;

namespace BusinessLayer.Contracts;

public interface IUsersServices 
{
    Task<UserResultDto> RegisterAsync(RegisterUserDto user);
    Task<UserResultDto> LogInAsync (LogInUserDto user);
    Task LogOutAsync();
    Task<UsersDto> GetUserByIdAsync(string id);
    Task<List<UsersDto>> GetAllUsersAsync();
    string GetCrruntUser();
    Task<UserResultDto> CheckEmailAndUsername(UsersDto model);
    Task<UserResultDto> ChangePasswordAsync(ChangePasswordDto model);
}
