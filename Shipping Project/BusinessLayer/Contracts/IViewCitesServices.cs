using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using DataAccess.Migrations;
using Domains;

namespace BusinessLayer.Contracts
{
    public interface IViewCitesServices : IBaseViewsServices<VwCiti ,VwCitesDto>
    {
    }
}
