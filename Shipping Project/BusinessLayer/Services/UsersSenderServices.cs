using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.DTO;
using DataAccess.Contracts;
using Domains;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Services;

public class UsersSenderServices : BaseServices<TbUsersSender , UsersSenderDto>, IUsersSenderServices
{
    public UsersSenderServices(ItablsGenericRepositorys<TbUsersSender> Orepo, ILogger<UsersSenderServices> logger , IMapper mapper, IUsersServices usersServices) : base(Orepo, logger, mapper, usersServices)
    {
    }
}
