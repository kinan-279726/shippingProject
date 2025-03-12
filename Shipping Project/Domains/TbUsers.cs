using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domains;
public partial class TbUsers : IdentityUser
{
    public virtual TbUsersSender? tbUsersSender { get; set; }
    public virtual TbUsersReceivers? tbUsersReceivers { get; set; }
    public virtual TbCarriers? tbCarriers { get; set; }
    public virtual TbShipments? tbShipments { get; set; }
    public ICollection<TbUserSubscriptions> Subscriptions { get; set; } = new List<TbUserSubscriptions>();
}
