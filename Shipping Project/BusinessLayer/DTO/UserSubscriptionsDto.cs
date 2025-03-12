using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO;

public class UserSubscriptionsDto : BaseDto
{
    public required string UserId { get; set; }
    public required string PackageId { get; set; }
    public DateTime SubscriptionDate { get; set; }
}
