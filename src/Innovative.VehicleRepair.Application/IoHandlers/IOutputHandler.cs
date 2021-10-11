using System.Threading.Tasks;

namespace Innovative.VehicleRepair.Application.IoHandlers
{
    public interface IOutputHandler
    {
        Task DisplayWelcomeMessage();
        Task DisplayLargeOrderInputMessage();
        Task DisplayInputError(string errorTemplate, params object[] errorArgs);
        Task DisplayRushOrderInputMessage();
        Task DisplayNewCustomerInputMessage();
        Task DisplayOrderTypeInputMessage();
        Task DisplayExistAppInputMessage();
    }
}