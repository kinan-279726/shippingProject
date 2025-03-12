using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains;
public class TbCities : BaseTable
{
    [Required, MaxLength(100)]
    public required string CityArabicName { get; set; }
    [Required, MaxLength(100)]
    public required string CityEnglithName { get; set; }
    [Required]
    public required string  CountryId { get; set; }
    public virtual TbCountries? Countries { get; set; }
    public ICollection<TbUsersSender> Senders { get; set; } = new List<TbUsersSender>();
    public ICollection<TbUsersReceivers> Receivers { get; set; } = new List<TbUsersReceivers>();
}
