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

public class ShipmentTypeServices : BaseServices<TbShipmentType , ShipmentTypeDto>, IShipmentTypeServices
{
    public ShipmentTypeServices(ItablsGenericRepositorys<TbShipmentType> Orepo, ILogger<ShipmentTypeServices> logger , IMapper mapper, IUsersServices usersServices) : base(Orepo, logger, mapper, usersServices)
    {
    }
}
