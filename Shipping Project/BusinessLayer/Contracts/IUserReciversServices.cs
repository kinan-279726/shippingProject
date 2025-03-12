using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using Domains;

namespace BusinessLayer.Contracts;

public interface IUserReciversServices : IBaseServices<TbUsersReceivers , UsersReceiversDto>
{
}
