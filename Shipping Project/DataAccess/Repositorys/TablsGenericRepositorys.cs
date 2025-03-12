using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DataAccess.Exceptions;
using DataAccess.Contracts;

namespace DataAccess.Repositorys;

public class TablsGenericRepositorys<T> : ItablsGenericRepositorys<T> where T : BaseTable
{
    private readonly DbContextShipment Ocontext;
    private readonly DbSet<T> OdbSet;
    private readonly ILogger<TablsGenericRepositorys<T>> Ologger;
    public TablsGenericRepositorys(DbContextShipment context , ILogger<TablsGenericRepositorys<T>> logger)
    {
        Ologger = logger;
        Ocontext = context;
        OdbSet = Ocontext.Set<T>();
    }
    public async Task Save ()
    {
        try
        {
        await Ocontext.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            throw new DataAccessException(ex, "error in save data ", Ologger);
        }
    }
    public T? GetById (string id)
    {
        try
        {
            var entity = OdbSet.AsNoTracking().SingleOrDefault(a => a.Id == id);

            return entity;
        }
        catch(Exception ex) 
        {
            throw new DataAccessException(ex, "NOT Found ! ", Ologger);
        }
    }
    public bool Delete (string id)
    {
        try
        {
            var entity = OdbSet.Where(a => a.Id == id);
            if (entity != null)
            {
                OdbSet.Remove((T)entity);
                Ocontext.SaveChangesAsync();
                //_ = Save();
            }
            return true;
        }
        catch(Exception ex) 
        {
            throw new DataAccessException(ex,"This Data you Wold To Delete it has a refrences on onther Data", Ologger);
        }
    }
    public bool Add (T entity , string userId)
    {
        try
        {
            entity.Id = Guid.NewGuid().ToString();
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            entity.CreatedBy = userId;
            entity.UpdatedBy = userId;
            entity.CurrentState = 0;

            OdbSet.Add(entity);
            Ocontext.SaveChangesAsync();
            //_ = Save();
            return true;
        }
        catch(Exception ex) 
        {
            throw new DataAccessException(ex, "Unvalid Data", Ologger);
        }
    }
    public  bool Update (T entity , string userId)
    {
        try
        {
            T oldEntity = GetById(entity.Id);
            if(oldEntity is not null)
            {
                entity.CreatedDate = oldEntity.CreatedDate;
                entity.UpdatedDate = DateTime.Now;
                entity.CreatedBy = oldEntity.CreatedBy;
                entity.UpdatedBy = userId;
            }
            Ocontext.Entry(entity).State = EntityState.Modified;
            Ocontext.SaveChangesAsync();
            //_ = Save();
            return true;
        }
        catch(Exception ex)
        {
            throw new DataAccessException(ex, "Unvalid Data", Ologger);
        }
    }
    public List<T> GetAll (bool deleted = false, bool all = false, bool unDeleted = true)
    {
        try
        {
            if (all || (deleted && unDeleted))
            {
            return OdbSet.ToList();
            }
            else if (deleted)
            {
                return OdbSet.Where(a=>a.CurrentState>0).ToList();
            }
            else
            {
                return OdbSet.Where(a => a.CurrentState == 0).ToList();
            }
        }
        catch (Exception ex) 
        {
            throw new DataAccessException(ex, "Pleas Try Again!!!" , Ologger);
        }
    }
    public bool ChangeCurrentStatus (string id , string userId)
    {
        try
        {
            T entity = GetById(id);
            if (entity != null)
            {

                entity.CurrentState++;
                if (entity.CurrentState >= 2)
                {
                   return Delete(id);
                }
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = userId;

                Ocontext.SaveChangesAsync();
                //_ = Save();
            }
            return true;
        }
        catch (Exception ex) 
        {
            throw new DataAccessException(ex, "Pleas Try Again", Ologger);
        }
    }
    public bool Restor(string id)
    {
        try
        {
            T entity = GetById(id);
            if (entity != null && entity.CurrentState > 0)
            {
                entity.CurrentState--;
                Ocontext.SaveChangesAsync();
            }
            return true;
        }
        catch (Exception ex)
        {
            throw new DataAccessException(ex , "" , Ologger );
        }
    }
}
