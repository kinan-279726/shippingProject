using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using DataAccess.Contracts;
using DataAccess.Exceptions;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Services;

public class BaseViewsServices<T, Dto> : IBaseViewsServices<T , Dto> where T : class where Dto : class
{
    private readonly IviewsGenericRepositorys<T> Orepo;
    private readonly IMapper Omapper;
    public BaseViewsServices(IviewsGenericRepositorys<T> repo, IMapper omapper)
    {

        this.Orepo = repo;
        Omapper = omapper;
    }
    public List<Dto> GetAll()
    {
        try
        {
            return Omapper.Map<List<T>, List<Dto>>(Orepo.GetAll());
        }
        catch 
        {
            return new List<Dto>();
        }
    }
}
