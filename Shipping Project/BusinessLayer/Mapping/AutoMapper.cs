using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.DTO;
using Domains;

namespace BusinessLayer.Mapping;

public class AutoMapper<Tsource, TDetination> : IAutoMapper<Tsource, TDetination>
{
    private readonly IMapper Omapper;
    public AutoMapper(IMapper mapper)
    {
        Omapper = mapper;
    }
    public TDetination Map<Tsource , TDetination>(Tsource s)
    {
        return Omapper.Map<Tsource, TDetination>(s);
    }
}
