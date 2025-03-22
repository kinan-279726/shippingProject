using BusinessLayer.DTO;

namespace UIProject.Models
{
    public class ShipmentViewModel
    {
        public UsersSenderDto SenderInfo { get; set; }
        public UsersReceiversDto receiversInfo { get; set; }
        public ShipmentsDto shipments { get; set; }
    }
}
