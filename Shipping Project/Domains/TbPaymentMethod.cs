using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains;
public class TbPaymentMethod : BaseTable
{
    [Required]
    public required string MethodArabicName { get; set; }
    [Required]
    public required string MethodEnglishName { get; set; }
    [Required]
    public float Commission { get; set; }
    public ICollection<TbShipments> Shipments { get; set; } = new List<TbShipments>();
}
