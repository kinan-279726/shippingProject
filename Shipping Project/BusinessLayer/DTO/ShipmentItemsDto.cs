using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources;

namespace BusinessLayer.DTO;

public class ShipmentItemsDto : BaseDto
{
    [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessageResourceName = "NameMustBeEnglish", ErrorMessageResourceType = typeof(ResMessages))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    [MaxLength(100, ErrorMessageResourceName = "MaxLengthExceeded", ErrorMessageResourceType = typeof(ResMessages))]
    public required string ItemName { get; set; }
    [RegularExpression(@"^-?\d+(\.\d+)?$", ErrorMessageResourceName = "FieldMustBeNumber", ErrorMessageResourceType = typeof(ResMessages))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    [Range(1, 1000, ErrorMessageResourceName = "QuantityRange", ErrorMessageResourceType = typeof(ResMessages))]
    public int Quantity { get; set; }
    [Required]
    public required string ShipmentId { get; set; }
}
