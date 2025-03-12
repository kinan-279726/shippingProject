using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains;
public class TbUserSubscriptions : BaseTable
{

    [Required]
    public required string  UserId { get; set; }
    [Required]
    public required string  PackageId { get; set; }
    [Required]
    public DateTime SubscriptionDate { get; set; }
    public virtual TbUsers? tbUsers { get; set; }
    public virtual TbSubscriptionPackages? tbSubscriptionsPackages { get; set; }
    public virtual TbShipments? tbShipments { get; set; }

}

