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

namespace BusinessLayer.Services;

public class ViewShipmentsServices : BaseViewsServices<VwShipment, VwShipmentDto>, IViewShipmentsServices
{
    public ViewShipmentsServices(IviewsGenericRepositorys<VwShipment> Orepo, IMapper mapper) : base(Orepo, mapper)
    {
    }
}
