using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains;
public class TbShipments : BaseTable
{
    [Required]
    public required string  SenderId { get; set; } 
    [Required]
    public required string  ReceiverId { get; set; }
    [Required]
    public DateTime ShipmentDate { get; set; }
    [Required]
    public required string  ShippingTypeId { get; set; }
    [Required]
    public float Width { get; set; }
    [Required]
    public float Height { get; set; }
    [Required]
    public float Weight { get; set; }
    [Required]
    public float Length { get; set; }
    [Required]
    public float PackageValue { get; set; }
    public float ? ShipmentRate { get; set; }
    public required string  ? PaymentMethodId { get; set; }
    public required string  ? UserSubscriptionId { get; set; }
    [Required]
    public required string TrackingNumber { get; set; }
    public required string  ? ReferencesId { get; set; }
    public virtual TbUsersSender? tbSenders { get; set; }
    public virtual TbUsersReceivers? tbReceivers { get; set; }
    public virtual TbShipmentType? tbShipmentType { get; set; }
    public virtual TbShipmentStatus? tbShipmentStatus { get; set; }
    public virtual TbUserSubscriptions? tbUserSubscriptions { get; set; }
    public virtual TbPaymentMethod? tbPaymentMethod { get; set; }
}
