using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains;
public class BaseTable 
{   
    [Key]
    public required string Id { get; set; }
    // start  security Coulmn 
    [AllowNull]
    public required string UpdatedBy { get; set; }
    [Required]
    public int CurrentState { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    [AllowNull]
    public DateTime UpdatedDate { get; set; }
    [Required]
    public required string CreatedBy { get; set; }
    // end  security Coulmn 
}
