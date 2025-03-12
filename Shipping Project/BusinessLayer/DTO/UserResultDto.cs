using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO;

public class UserResultDto
{
    public bool IsSuccess { get; set; }
    public string Token { get; set; } = string.Empty;
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}
