using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Resources;

namespace BusinessLayer.DTO;

public class ShipmentTypeDto : BaseDto
{
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    [MaxLength(100, ErrorMessageResourceName = "MaxLengthExceeded", ErrorMessageResourceType = typeof(ResMessages))]
    [RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessageResourceName = "NameMustBeArabic", ErrorMessageResourceType = typeof(ResMessages))]
    public required string TypeArabicName { get; set; }

    [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessageResourceName = "NameMustBeEnglish", ErrorMessageResourceType = typeof(ResMessages))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    [MaxLength(100, ErrorMessageResourceName = "MaxLengthExceeded", ErrorMessageResourceType = typeof(ResMessages))]
    public required string TypeEnglishName { get; set; }

    [RegularExpression(@"^-?\d+(\.\d+)?$", ErrorMessageResourceName = "FieldMustBeNumber", ErrorMessageResourceType = typeof(ResMessages))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    [Range(0.25 , 10 , ErrorMessageResourceName = "FactorRange", ErrorMessageResourceType = typeof(ResShipping))]
    public float ShippingFactor { get; set; }
}
