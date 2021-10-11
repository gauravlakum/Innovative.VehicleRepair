using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innovative.VehicleRepair.Application.Enums;
using Innovative.VehicleRepair.Application.Resources;

namespace Innovative.VehicleRepair.Application.IoHandlers
{
    public class ConsoleInputHandler: IInputHandler
    {
        public ConsoleInputHandler(IOutputHandler outputHandler)
        {
            _outputHandler = outputHandler;
        }

        private static readonly Dictionary<char, bool> YesNoBoolMap = new Dictionary<char, bool>
        {
            { 'Y', true },
            { 'y', true },
            { 'N', false },
            { 'n', false },
        };

        private static readonly Dictionary<char, OrderType> CharOrderTypeMap = new Dictionary<char, OrderType>
        {
            { 'R', OrderType.Repair },
            { 'H', OrderType.Hire },
            { 'A', OrderType.All }, 
            { 'r', OrderType.Repair },
            { 'h', OrderType.Hire },
            { 'a', OrderType.All },
            
        };

        private readonly IOutputHandler _outputHandler;

 
        public async Task<bool> GetIsLargeOrderInput()
        {
            var key = await GetKeyInput(false, YesNoBoolMap.Keys.ToArray());
            return YesNoBoolMap[key];
        }

        public async Task<bool> GetIsRushOrderInput()
        {
            var key = await GetKeyInput(false, YesNoBoolMap.Keys.ToArray());
            return YesNoBoolMap[key];
        }

        public async Task<bool> GetIsNewCustomerInput()
        {
            var key = await GetKeyInput(false, YesNoBoolMap.Keys.ToArray());
            return YesNoBoolMap[key];
        }

        public async Task<OrderType> GetOrderTypeInput()
        {

            var key = await GetKeyInput(true, CharOrderTypeMap.Keys.ToArray());
            return CharOrderTypeMap[key];
        }

        public async Task<bool> GetExistAppInput()
        {
            var key = await GetKeyInput(false, YesNoBoolMap.Keys.ToArray());
            return YesNoBoolMap[key];

        }

        private async Task<char> GetKeyInput(bool hide, params char[] validInputs)
        {
            bool isValidResponse;
            char responseChar;
            do
            {
                responseChar = Console.ReadKey(hide).KeyChar;
                Console.WriteLine();
                isValidResponse = !validInputs.Any() || validInputs.Contains(responseChar);
                if (isValidResponse != true)
                {
                    await _outputHandler.DisplayInputError(
                        ApplicationResource.InvalidInputMessage,
                        string.Join(" or ", validInputs));
                }

            } while (isValidResponse == false );
            return responseChar;
        }
    }
}
