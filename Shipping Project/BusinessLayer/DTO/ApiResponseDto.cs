using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO;

public class ApiResponseDto
{
    public object ? Data { get; set; }
    public bool IsSuccess { get; set; } = true;
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}
