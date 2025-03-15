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

public class VeiwCitesServices : BaseViewsServices<VwCiti , VwCitesDto> ,IViewCitesServices
{
    public VeiwCitesServices(IviewsGenericRepositorys<VwCiti> Orepo , IMapper mapper) : base(Orepo , mapper)
    {
    }
}
