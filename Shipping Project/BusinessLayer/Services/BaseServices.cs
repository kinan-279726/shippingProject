using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.DTO;
using BusinessLayer.Mapping;
using DataAccess.Contracts;
using DataAccess.Exceptions;
using Domains;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Services;

public class BaseServices<T , Dto> : IBaseServices<T , Dto> where T : BaseTable where Dto : BaseDto
{
    private readonly ItablsGenericRepositorys<T> Orepo;
    private readonly ILogger<BaseServices<T , Dto>> Ologger;
    private readonly IMapper  Omapper;
    private readonly IUsersServices OusersServices;
    public BaseServices(ItablsGenericRepositorys<T> repo, ILogger<BaseServices<T,Dto>> logger , IMapper mapper , IUsersServices usersServices) 
    {
        this.OusersServices = usersServices;
        this.Orepo = repo;
        this.Ologger = logger;
        this.Omapper = mapper;
    }
    public List<Dto> GetAll(bool deleted = false, bool all = false, bool unDeleted = true)
    {
        try
        {
            return Omapper.Map<List<T>, List<Dto>>(Orepo.GetAll(deleted , all , unDeleted));
        }
        catch (Exception ex)
        {
            throw new DataAccessException(ex, "", Ologger);
        }
    }
    public Dto? GetById(string id)
    {
        try
        {
            return Omapper.Map<T,Dto>(Orepo.GetById(id));
        }
        catch (Exception ex)
        {
            throw new DataAccessException(ex, "", Ologger);
        }
    }
    public bool Update(Dto entity , string userId = "")
    {
        try
        {
             userId = OusersServices.GetCrruntUser();
            Orepo.Update(Omapper.Map<Dto, T>(entity), userId);
            return true;
        }
        catch (Exception ex)
        {
            throw new DataAccessException(ex, "", Ologger);
        }
    }
    public bool Add(Dto entity , string userId = "")
    {
        try
        {
             userId = OusersServices.GetCrruntUser();
            Orepo.Add(Omapper.Map<Dto, T>(entity), userId);
            return true;
        }
        catch (Exception ex)
        {
            throw new DataAccessException(ex, "", Ologger);
        }
    }
    public bool ChangeCurrentStatus(string id , string userId = "")
    {
        try
        {
             userId = OusersServices.GetCrruntUser();
            Orepo.ChangeCurrentStatus(id, userId);
            return true;
        }
        catch (Exception ex)
        {
            throw new DataAccessException(ex, "", Ologger);
        }
    }
    public bool Restor(string id)
    {
        try
        {
            Orepo.Restor(id);
            return true; ;
        }
        catch (Exception ex)
        {
            throw new DataAccessException(ex, "", Ologger);
        }
    }
}
