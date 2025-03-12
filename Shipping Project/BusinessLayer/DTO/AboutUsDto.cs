using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Resources;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO;

public class AboutUsDto : BaseDto
{
    [Required(ErrorMessageResourceName = "RequiredField" , ErrorMessageResourceType = typeof(ResMessages))]
    [MaxLength(100, ErrorMessageResourceName = "MaxLengthExceeded", ErrorMessageResourceType = typeof(ResMessages))]
    public required string Title { get; set; }

    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages)),]
    [MaxLength(2000, ErrorMessageResourceName = "MaxLengthExceeded", ErrorMessageResourceType = typeof(ResMessages))]
    public required string Description { get; set; }

    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages)),]
    [RegularExpression(@"\.(jpg|jpeg|png|gif|bmp|webp)$", ErrorMessageResourceName = "InvalidFileFormat", ErrorMessageResourceType = typeof(ResMessages))]
    public required string ImagePath { get; set; }
}
