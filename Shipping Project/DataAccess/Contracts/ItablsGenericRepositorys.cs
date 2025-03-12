using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains;

namespace DataAccess.Contracts;

public interface ItablsGenericRepositorys<T> where T : BaseTable
{
    public List<T> GetAll(bool deleted = false , bool all = false , bool unDeleted = true);
    public T? GetById(string id);
    public bool Delete(string id);
    public bool Update(T entity, string userId);
    public bool Add(T entity , string userId);
    public bool ChangeCurrentStatus (string id , string userId);
    public bool Restor(string id);
}
