using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Resources;

namespace BusinessLayer.DTO;

public class ChangePasswordDto
{
   [ValidateNever]
    public required string Email { get; set; }

    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    [RegularExpression(@"^(?=.*[^a-zA-Z0-9])(?=.*[A-Z])(?=.*[0-9]).{8,}$", ErrorMessageResourceName = "PasswordChar", ErrorMessageResourceType = typeof(ResMessages))]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ResMessages))]
    [Compare("Password", ErrorMessageResourceName = "PasswordsDoNotMatch", ErrorMessageResourceType = typeof(ResMessages))]
    [DataType(DataType.Password)]
    public required string ConfirmPassword { get; set; }
}
