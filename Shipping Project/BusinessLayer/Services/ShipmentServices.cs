using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contracts;
using Domains;
using DataAccess.Exceptions;
using Microsoft.Extensions.Logging;
using BusinessLayer.Contracts;
using BusinessLayer.DTO;
using AutoMapper;

namespace BusinessLayer.Services;

public class ShipmentServices : BaseServices<TbShipments , ShipmentsDto> , IShipmentsServices
{
    public ShipmentServices(ItablsGenericRepositorys<TbShipments> Orepo, ILogger<ShipmentServices> logger , IMapper mapper) : base(Orepo , logger, mapper)
    {
    }
}
