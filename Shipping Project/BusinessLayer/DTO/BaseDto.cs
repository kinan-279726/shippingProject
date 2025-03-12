using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BusinessLayer.DTO;

public class BaseDto
{
    [ValidateNever]
    public required string Id { get; set; }
}
