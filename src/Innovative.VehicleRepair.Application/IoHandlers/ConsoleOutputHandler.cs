using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innovative.VehicleRepair.Application.Resources;

namespace Innovative.VehicleRepair.Application.IoHandlers
{
    public class ConsoleOutputHandler: IOutputHandler
    {
        public Task DisplayWelcomeMessage()
        {
            Console.WriteLine(ApplicationResource.WellcomeMessage);
            return Task.CompletedTask;
        }

        public Task DisplayLargeOrderInputMessage()
        {
            Console.WriteLine(ApplicationResource.LargeOrderInputMessage);
            return Task.CompletedTask;
        }

        public Task DisplayInputError(string errorTemplate, params object[] errorArgs)
        {
            Console.WriteLine(errorTemplate, errorArgs);
            return Task.CompletedTask;
        }

        public Task DisplayRushOrderInputMessage()
        {
            Console.WriteLine(ApplicationResource.RushOrderInputMessage);
            return Task.CompletedTask;
        }

        public Task DisplayNewCustomerInputMessage()
        {
            Console.WriteLine(ApplicationResource.NewCustomerInputMessage);
            return Task.CompletedTask;
        }

        public Task DisplayOrderTypeInputMessage()
        {
            Console.WriteLine(ApplicationResource.OrderTypeInputMessage);
            return Task.CompletedTask;
        }

        public Task DisplayExistAppInputMessage()
        {
            Console.WriteLine(ApplicationResource.ExistAppInputMessage);
            return Task.CompletedTask;
        }
    }
}
