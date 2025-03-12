using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources;

namespace BusinessLayer.DTO;

public class CountriesDto : BaseDto
{
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    [RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessageResourceName = "NameMustBeArabic", ErrorMessageResourceType = typeof(ResMessages))]
    [MaxLength(100, ErrorMessageResourceName = "MaxLengthExceeded", ErrorMessageResourceType = typeof(ResMessages))]
    public required string CountryArabicName { get; set; }

    [MaxLength(100, ErrorMessageResourceName = "MaxLengthExceeded", ErrorMessageResourceType = typeof(ResMessages))]
    [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessageResourceName = "NameMustBeEnglish", ErrorMessageResourceType = typeof(ResMessages))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    public required string CountryEnglishName { get; set; }
}
