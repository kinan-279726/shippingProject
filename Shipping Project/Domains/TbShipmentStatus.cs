using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Domains;
public class TbShipmentStatus : BaseTable
{
    [Required]
    public required string  ShipmentId { get; set; }
    [Required]
    public int Status { get; set; }
    [MaxLength(200)]
    public string Notes { get; set; } = string.Empty;
    [Required]
    public required string  CarrierId { get; set; }
    public virtual TbShipments? tbShipments { get; set; }
    public virtual TbCarriers ? tbCarriers { get; set; }
}
