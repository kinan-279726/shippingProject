using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO;

public class ShipmentStatusDto : BaseDto
{
    [Required]
    public required string ShipmentId { get; set; }
    [Required]
    public int Status { get; set; }
    [MaxLength(200)]
    public string Notes { get; set; } = string.Empty;
    [Required]
    public required string CarrierId { get; set; }
}
