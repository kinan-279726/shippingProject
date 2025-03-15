using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DataAccess.Contracts;
using DataAccess.Exceptions;
using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositorys;

public class ViewsGenericRepositorys<T> : IviewsGenericRepositorys<T> where T : class
{
    private readonly DbContextShipment Ocontext;
    private readonly DbSet<T> OdbSet;
    public ViewsGenericRepositorys(DbContextShipment context )
    {
        Ocontext = context;
        OdbSet = Ocontext.Set<T>();
    }
    public List<T> GetAll()
    {
        try
        {
            return OdbSet.ToList();
        }
        catch (Exception ex)
        {
            return new List<T>();
        }
    }
}