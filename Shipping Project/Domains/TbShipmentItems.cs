using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains;

public class TbShipmentItems : BaseTable
{
    public required string ItemName { get; set; }
    public int Quantity { get; set; }

    public required string ShipmentId { get; set; }

    public virtual TbShipments? tbShipments { get; set; }
}
