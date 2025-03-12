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

public class CountriesServices : BaseServices<TbCountries , CountriesDto>, ICountriesServices
{
    public CountriesServices(ItablsGenericRepositorys<TbCountries> Orepo, ILogger<CountriesServices> logger , IMapper mapper) : base(Orepo, logger, mapper)
    {
    }
}
