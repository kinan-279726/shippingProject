using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources;

namespace BusinessLayer.DTO;

public class UsersReceiversDto : BaseDto
{
    public required string UserId { get; set; }

    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    [MaxLength(50, ErrorMessageResourceName = "MaxLengthExceeded", ErrorMessageResourceType = typeof(ResMessages))]
    public required string ReceiverName { get; set; }

    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    [MaxLength(50, ErrorMessageResourceName = "MaxLengthExceeded", ErrorMessageResourceType = typeof(ResMessages))]
    [EmailAddress(ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(ResMessages))]
    public required string Email { get; set; }

    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    [MaxLength(50, ErrorMessageResourceName = "MaxLengthExceeded", ErrorMessageResourceType = typeof(ResMessages))]
    public required string PhoneNumber { get; set; }

    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    public required string CityId { get; set; }

    [AllowNull]
    public string Address { get; set; } = string.Empty;
}
