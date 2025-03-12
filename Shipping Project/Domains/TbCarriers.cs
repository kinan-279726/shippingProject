using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains;
public class TbCarriers : BaseTable
{
    [Required]
    public required string  UserId { get; set; }
    public virtual TbUsers? tbUsers { get; set; }
    public ICollection<TbShipmentStatus> ShipmentStatus { get; set; } = new List<TbShipmentStatus>();
}
