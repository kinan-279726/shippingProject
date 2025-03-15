using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.DTO;
using DataAccess.Contracts;
using Domains;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Services;

public class PaymentMethodServices : BaseServices<TbPaymentMethod, PaymentMethodDto>, IPaymentMethodServices
{
    public PaymentMethodServices(ItablsGenericRepositorys<TbPaymentMethod> Orepo, ILogger<PaymentMethodServices> logger , IMapper mapper, IUsersServices usersServices) : base(Orepo, logger, mapper, usersServices)
    {
    }
}
