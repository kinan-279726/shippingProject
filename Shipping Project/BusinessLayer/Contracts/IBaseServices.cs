using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using Domains;

namespace BusinessLayer.Contracts;
public interface IBaseServices<T, Dto> where T : BaseTable where Dto : BaseDto
{
    public List<Dto> GetAll(bool deleted = false, bool all = false, bool unDeleted = true);
    public Dto? GetById(string id);
    public bool Update(Dto entity, string userId = "");
    public bool Add(Dto entity, string userId = "");
    public bool ChangeCurrentStatus(string id, string userId = "");
}
