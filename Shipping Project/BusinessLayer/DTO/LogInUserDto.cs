using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources;

namespace BusinessLayer.DTO;

public class LogInUserDto : BaseDto
{
    [EmailAddress(ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(ResMessages))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    public required string Email { get; set; }

    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    [MinLength(8, ErrorMessageResourceName = "PasswordTooShort", ErrorMessageResourceType = typeof(ResMessages))]
    public required string Password { get; set; }

    [Display(Name = "Remember My ?")]
    public bool rememberMy { get; set; }

    public string? ReturnUrl { get; set; }
}
