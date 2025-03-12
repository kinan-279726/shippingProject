using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains;
public class TbUsersReceivers : BaseTable
{
    [Required]
    public required string  UserId { get; set; }
    [Required, MaxLength(100)]
    public required string ReceiverName { get; set; }
    [Required, MaxLength(100)]
    public required string Email { get; set; }
    [Required, MaxLength(100)]
    public required string PhoneNumber { get; set; }
    [Required]
    public required string  CityId { get; set; }
    [MaxLength(100)]
    public string Address { get; set; } = string.Empty;
    public virtual TbUsers ? tbUsers { get; set; }
    public virtual TbCities? tbCities { get; set; }
    public ICollection<TbShipments> Shipments { get; set; } = new List<TbShipments>();
}
