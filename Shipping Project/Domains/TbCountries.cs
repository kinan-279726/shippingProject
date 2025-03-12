using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domains;
public class TbCountries : BaseTable
{
    [Required ,MaxLength(100)]
    public required string CountryArabicName { get; set; }
    [Required ,MaxLength(100)]
    public required string CountryEnglishName { get; set; }
    public ICollection<TbCities> Cities { get; set; } = new List<TbCities>();
}

