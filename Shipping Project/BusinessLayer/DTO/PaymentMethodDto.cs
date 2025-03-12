using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources;

namespace BusinessLayer.DTO;

public class PaymentMethodDto : BaseDto
{
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    [MaxLength(100, ErrorMessageResourceName = "MaxLengthExceeded", ErrorMessageResourceType = typeof(ResMessages))]
    [RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessageResourceName = "NameMustBeArabic", ErrorMessageResourceType = typeof(ResMessages))]
    public required string MethodArabicName { get; set; }

    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    [MaxLength(100, ErrorMessageResourceName = "MaxLengthExceeded", ErrorMessageResourceType = typeof(ResMessages))]
    [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessageResourceName = "NameMustBeEnglish", ErrorMessageResourceType = typeof(ResMessages))]
    public required string MethodEnglishName { get; set; }

    [RegularExpression(@"^-?\d+(\.\d+)?$", ErrorMessageResourceName = "FieldMustBeNumber", ErrorMessageResourceType = typeof(ResMessages))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    public float Commission { get; set; }
}
