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

public class ShipmentItemsServices : BaseServices<TbShipmentItems, ShipmentItemsDto>,  IShipmentItemsServices
{
    private readonly IMapper Omapper;
    private readonly ItablsGenericRepositorys<TbShipmentItems> Orepo;
    private readonly ILogger<BaseServices<TbShipmentItems, ShipmentItemsDto>> Ologger;
    public ShipmentItemsServices(ItablsGenericRepositorys<TbShipmentItems> repo, ILogger<ShipmentItemsServices> logger, IMapper mapper, IUsersServices usersServices) : base(repo, logger, mapper, usersServices)
    {
        this.Orepo = repo;
        this.Ologger = logger;
        this.Omapper = mapper;
    }
    public List<ShipmentItemsDto> GetByShipmentItems(string shipmentItemId)
    {
        try
        {
            List<ShipmentItemsDto> items = Omapper.Map<List<TbShipmentItems>, List<ShipmentItemsDto>>(Orepo.GetAll().Where(a => a.ShipmentId == shipmentItemId).ToList());
            return items;
        }
        catch 
        {
           return new List<ShipmentItemsDto>();
        } 
    }
}
