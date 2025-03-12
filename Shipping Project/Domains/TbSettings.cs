using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains;
public class TbSettings : BaseTable
{
    [Required]
    public float KiloMeterPrice {  get; set; }
    [Required]
    public float KilooGramPrice { get; set; }
    [Required]
    public required string  WebSiteName {  get; set; }
    [Required]
    public required string LogoPath { get; set; }
    [MaxLength(300)]
    public string InsatgrLink { get; set; } = string.Empty;
    [MaxLength(300)]
    public string FaceBookLink {  get; set; } = string.Empty;
    [MaxLength(300)]
    public string LinkedInLink {  get; set; } = string.Empty;
    [MaxLength(300)]
    public string TheardLink { get; set; } = string.Empty;
    [MaxLength(300)]
    public string Xlink { get; set; } = string.Empty;
    [MaxLength(50)]
    public string FaxNumber { get; set; } = string.Empty;
    [MaxLength(50)]
    public string PhoneNumber { get; set; } = string.Empty;

}
