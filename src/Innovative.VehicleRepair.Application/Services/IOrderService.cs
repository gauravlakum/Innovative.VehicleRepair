using Innovative.VehicleRepair.Application.Enums;
using Innovative.VehicleRepair.Application.Models;

namespace Innovative.VehicleRepair.Application.Services
{
    public interface IOrderService
    {
        OrderStatus ProcessOrder(OrderInput orderInput);
        OrderStatus ProcessOrderV2(OrderInput orderInput);
    }
}