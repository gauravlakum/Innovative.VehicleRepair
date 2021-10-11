using System.Collections.Generic;
using Innovative.VehicleRepair.Application.Enums;
using Innovative.VehicleRepair.Application.Models;

namespace Innovative.VehicleRepair.Application.Data
{
    public class RuleEngine
    {
        public static List<OrderRule> OrderRules = new List<OrderRule>
        {
            
            //Large repair orders for new customers should be closed
            new OrderRule{ Priority = 1, IsLargeOrder = true,  OrderType = OrderType.Repair, IsNewCustomer = true, OrderStatus =  OrderStatus.Closed},

            //Large rush hire orders should always be closed
            new OrderRule{ Priority = 2, IsLargeOrder = true,  IsRushOrder = true, OrderType = OrderType.Hire, OrderStatus =  OrderStatus.Closed},

            //Large repair orders always require authorisation
            new OrderRule{ Priority = 3, IsLargeOrder = true,  OrderType = OrderType.Repair, OrderStatus =  OrderStatus.AuthorisationRequired},

            //All rush orders for new customers always require authorisation
            new OrderRule{ Priority = 4, IsRushOrder = true, IsNewCustomer = true, OrderStatus =  OrderStatus.AuthorisationRequired}
        };

        //public Dictionary<RuleNames, OrderRule> Rules = new Dictionary<RuleNames, OrderRule>();

        //public bool IsLargeOrder => Rules.ContainsKey(RuleNames.IsLargeOrder) && GetRuleValue<bool>(Rules[RuleNames.IsLargeOrder]);
        //public bool IsNewCustomer => Rules.ContainsKey(RuleNames.IsNewCustomer) && GetRuleValue<bool>(Rules[RuleNames.IsNewCustomer]);
        //public bool IsRushOrder => Rules.ContainsKey(RuleNames.IsRushOrder) && GetRuleValue<bool>(Rules[RuleNames.IsRushOrder]);
        //public OrderType OrderType => Rules.ContainsKey(RuleNames.OrderType) ? GetRuleValue < OrderType> (Rules[RuleNames.OrderType]) :Enums.OrderType.All;

        //public T GetRuleValue<T>(OrderRule orderRule)
        //{
        //    return (T)orderRule.RuleValue;
        //}

        
    }
}