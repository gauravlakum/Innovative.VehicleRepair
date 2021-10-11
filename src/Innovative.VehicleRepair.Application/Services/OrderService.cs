using System.Linq;
using Innovative.VehicleRepair.Application.Enums;
using Innovative.VehicleRepair.Application.Models;
using Innovative.VehicleRepair.Application.Repositories;

namespace Innovative.VehicleRepair.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRuleRepository _ruleRepository;

        public OrderService(IRuleRepository ruleRepository)
        {
            _ruleRepository = ruleRepository;
        }

        public OrderStatus ProcessOrder(OrderInput orderInput)
        {
            var rule =  _ruleRepository.GetRule(orderInput).FirstOrDefault();
            return rule?.OrderStatus ?? OrderStatus.Confirmed;
        }
        
        public OrderStatus ProcessOrderV2(OrderInput orderInput)
        {
            var rule =  _ruleRepository.GetRuleV2(orderInput).FirstOrDefault();
            return rule?.OrderStatus ?? OrderStatus.Confirmed;
        }
    }
}