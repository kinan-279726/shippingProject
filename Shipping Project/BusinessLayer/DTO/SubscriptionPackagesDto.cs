using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources;

namespace BusinessLayer.DTO;

public class SubscriptionPackagesDto : BaseDto
{
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    public required string PackageName { get; set; }

    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    public int ShipmentCount { get; set; }

    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    [RegularExpression(@"^-?\d+(\.\d+)?$", ErrorMessageResourceName = "FieldMustBeNumber", ErrorMessageResourceType = typeof(ResMessages))]
    public float NumberOfKiloMeters { get; set; }

    [RegularExpression(@"^-?\d+(\.\d+)?$", ErrorMessageResourceName = "FieldMustBeNumber", ErrorMessageResourceType = typeof(ResMessages))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    public float TotalWeight { get; set; }
}
