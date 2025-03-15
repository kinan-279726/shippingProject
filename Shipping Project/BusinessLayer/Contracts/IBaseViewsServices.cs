using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts;

public interface IBaseViewsServices<T , Dto> where T : class where Dto : class
{
    public List<Dto> GetAll();
}
