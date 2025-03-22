using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO;

public class VwShipmentDto
{
    public string ShippmentId { get; set; } = null!;

    public string SenderId { get; set; } = null!;

    public string ReceiverId { get; set; } = null!;

    public string ShippingTypeId { get; set; } = null!;

    public string? PaymentMethodId { get; set; }

    public string SenderCityid { get; set; } = null!;

    public string ReceiverCityid { get; set; } = null!;

    public DateTime ShipmentDate { get; set; }

    public float Width { get; set; }

    public float Height { get; set; }

    public float Weight { get; set; }

    public float Length { get; set; }

    public float PackageValue { get; set; }

    public float? ShipmentRate { get; set; }

    public string TrackingNumber { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;

    public int CurrentState { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string SenderName { get; set; } = null!;

    public string SenderEmail { get; set; } = null!;

    public string SenderPhone { get; set; } = null!;

    public string ReceiverName { get; set; } = null!;

    public string ReceiverEmail { get; set; } = null!;

    public string ReceiverPhone { get; set; } = null!;

    public string TypeEnglishName { get; set; } = null!;

    public string MethodEnglishName { get; set; } = null!;

    public string SenderCityName { get; set; } = null!;

    public string ReceiverCityName { get; set; } = null!;
}
