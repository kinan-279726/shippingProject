using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains;

namespace DataAccess.Contracts
{
    public interface IviewsGenericRepositorys<T> where T : class
    {
        public List<T> GetAll();
    }
}
