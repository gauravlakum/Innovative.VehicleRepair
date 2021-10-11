using System.Collections.Generic;
using System.Linq;
using Innovative.VehicleRepair.Application.Data;
using Innovative.VehicleRepair.Application.Enums;
using Innovative.VehicleRepair.Application.Models;

namespace Innovative.VehicleRepair.Application.Repositories
{
    public class RuleRepository : IRuleRepository
    {
        public List<OrderRule> GetRule(OrderInput input)
        {
            return RuleEngine.OrderRules.Where(rule => rule.IsLargeOrder == input.IsLargeOrder &&
                                                                rule.IsNewCustomer == input.IsNewCustomer &&
                                                                rule.IsRushOrder == input.IsRushOrder &&
                                                                rule.OrderType == input.OrderType).OrderBy(rule => rule.Priority)
                .ToList();


        }

        public List<OrderRuleV2> GetRuleV2(OrderInput input)
        {
            return RuleEngineV2.OrderRules.Where(rule => rule.IsLargeOrder == input.IsLargeOrder &&
                                                       rule.IsNewCustomer == input.IsNewCustomer &&
                                                       rule.IsRushOrder == input.IsRushOrder &&
                                                       rule.OrderType == input.OrderType).OrderBy(rule => rule.Priority)
                .ToList();


        }
    }
}