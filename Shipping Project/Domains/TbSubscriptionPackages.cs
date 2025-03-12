using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains;
public class TbSubscriptionPackages : BaseTable
{
    [Required, MaxLength(100)]
    public required string PackageName { get; set; } 
    [Required]
    public int ShipmentCount { get; set; }
    [Required]
    public float NumberOfKiloMeters { get; set; }
    [Required]
    public float TotalWeight { get; set; }
    public ICollection<TbUserSubscriptions> Subscriptions { get; set; } = new List<TbUserSubscriptions>();
}

