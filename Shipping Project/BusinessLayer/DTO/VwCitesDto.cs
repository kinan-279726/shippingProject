using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Resources;

namespace BusinessLayer.DTO;

public class VwCitesDto
{

    public string CountryId { get; set; } = null!;

    [ValidateNever]
    public string CityId { get; set; } = null!;

    [ValidateNever]
    public string CountryArabicName { get; set; } = null!;

    [ValidateNever]
    public string CountryEnglishName { get; set; } = null!;

    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    [RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessageResourceName = "NameMustBeArabic", ErrorMessageResourceType = typeof(ResMessages))]
    [MaxLength(100, ErrorMessageResourceName = "MaxLengthExceeded", ErrorMessageResourceType = typeof(ResMessages))]
    public string CityArabicName { get; set; } = null!;

    [MaxLength(100, ErrorMessageResourceName = "MaxLengthExceeded", ErrorMessageResourceType = typeof(ResMessages))]
    [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessageResourceName = "NameMustBeEnglish", ErrorMessageResourceType = typeof(ResMessages))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    public string CityEnglithName { get; set; } = null!;
}
