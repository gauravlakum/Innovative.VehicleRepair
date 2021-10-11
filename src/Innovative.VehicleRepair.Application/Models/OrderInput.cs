using Innovative.VehicleRepair.Application.Enums;

namespace Innovative.VehicleRepair.Application.Models
{
    public class OrderInput
    {
        public bool IsRushOrder { get; set; }
        public OrderType OrderType { get; set; }
        public bool IsNewCustomer { get; set; }
        public bool IsLargeOrder { get; set; }
    }
}