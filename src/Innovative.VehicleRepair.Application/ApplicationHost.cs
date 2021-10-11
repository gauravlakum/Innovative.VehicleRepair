using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Innovative.VehicleRepair.Application.Enums;
using Innovative.VehicleRepair.Application.IoHandlers;
using Innovative.VehicleRepair.Application.Models;
using Innovative.VehicleRepair.Application.Resources;
using Innovative.VehicleRepair.Application.Services;
using Microsoft.Extensions.Hosting;

namespace Innovative.VehicleRepair.Application
{
    public class ApplicationHost
    {
        private readonly IOrderService _orderService;
        private readonly IOutputHandler _outputHandler;
        private readonly IInputHandler _inputHandler;

        public ApplicationHost(IOrderService orderService,
            IOutputHandler outputHandler,
            IInputHandler inputHandler)
        {
            _orderService = orderService;
            _outputHandler = outputHandler;
            _inputHandler = inputHandler;
        }

        public async Task Run()
        {
            bool existApp;
            do
            {

                await _outputHandler.DisplayWelcomeMessage();

                await _outputHandler.DisplayRushOrderInputMessage();
                var isRushOrder = await _inputHandler.GetIsRushOrderInput();

                await _outputHandler.DisplayOrderTypeInputMessage();
                var orderType = await _inputHandler.GetOrderTypeInput();

                await _outputHandler.DisplayLargeOrderInputMessage();
                var isLargeOrder = await _inputHandler.GetIsLargeOrderInput();

                await _outputHandler.DisplayNewCustomerInputMessage();
                var isNewCustomer = await _inputHandler.GetIsNewCustomerInput();

                var orderStatus = _orderService.ProcessOrderV2(new OrderInput
                {
                    IsRushOrder = isRushOrder,
                    OrderType = orderType,
                    IsNewCustomer = isNewCustomer,
                    IsLargeOrder = isLargeOrder
                });

                Console.WriteLine(ApplicationResource.OrderStatusMessage, orderStatus);

                await _outputHandler.DisplayExistAppInputMessage();
                existApp = await _inputHandler.GetExistAppInput();

            } while (!existApp);

        }

    }
}
