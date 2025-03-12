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

public class CitiesServices : BaseServices<TbCities , CitesDto>, ICitiesServices
{
    public CitiesServices(ItablsGenericRepositorys<TbCities> Orepo, ILogger<CitiesServices> logger , IMapper mapper) : base(Orepo, logger ,mapper)
    {
    }
}
