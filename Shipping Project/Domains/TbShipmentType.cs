using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains;
public class TbShipmentType : BaseTable
{
    [Required]
    public required string TypeArabicName { get; set; }
    [Required]
    public required string TypeEnglishName { get; set; }
    [Required]
    public float ShippingFactor { get; set; }
    public ICollection<TbShipments> Shipments { get; set; } = new List<TbShipments>();

}
