using System.Threading.Tasks;
using Innovative.VehicleRepair.Application.Enums;

namespace Innovative.VehicleRepair.Application.IoHandlers
{
    public interface IInputHandler
    {
        Task<bool> GetIsLargeOrderInput();
        Task<bool> GetIsRushOrderInput();
        Task<bool> GetIsNewCustomerInput();
        Task<OrderType> GetOrderTypeInput();
        Task<bool> GetExistAppInput();
    }
}