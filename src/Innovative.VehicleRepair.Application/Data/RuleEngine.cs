using System.Collections.Generic;
using System.Linq;
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

    public class RuleEngineV2
    {
        public static List<OrderRuleV2> OrderRules = new List<OrderRuleV2>
        {
            //Large repair orders for new customers should be closed
            new OrderRuleV2
            {
                OrderStatus = OrderStatus.Closed,
                Rules = new Dictionary<RuleNames, object>
                {
                    {RuleNames.IsLargeOrder, true} ,
                    {RuleNames.OrderType, OrderType.Repair} ,
                    {RuleNames.IsNewCustomer, true},
                    {RuleNames.Priority, 1}
                }
            },
            //Large rush hire orders should always be closed
            new OrderRuleV2
            {
                OrderStatus = OrderStatus.Closed,
                Rules = new Dictionary<RuleNames, object>
                {
                    {RuleNames.IsRushOrder, true} ,
                    {RuleNames.IsLargeOrder, true} ,
                    {RuleNames.OrderType, OrderType.Hire} ,
                    {RuleNames.Priority, 2}
                }
            },
            //Large repair orders always require authorisation
            new OrderRuleV2
            {
                OrderStatus = OrderStatus.AuthorisationRequired,
                Rules = new Dictionary<RuleNames, object>
                {
                    {RuleNames.IsLargeOrder, true} ,
                    {RuleNames.OrderType, OrderType.Repair} ,
                    {RuleNames.Priority, 3}
                }
            },
            //All rush orders for new customers always require authorisation
            new OrderRuleV2
            {
                OrderStatus = OrderStatus.AuthorisationRequired,
                Rules = new Dictionary<RuleNames, object>
                {
                    {RuleNames.IsRushOrder, true} ,
                    {RuleNames.IsNewCustomer, true} ,
                    {RuleNames.Priority, 4}
                }
            }
        };
    }

    public class OrderRuleV2
    {

        public bool IsLargeOrder => Rules.ContainsKey(RuleNames.IsLargeOrder) && GetRuleValue<bool>(Rules[RuleNames.IsLargeOrder]);
        public bool IsNewCustomer => Rules.ContainsKey(RuleNames.IsNewCustomer) && GetRuleValue<bool>(Rules[RuleNames.IsNewCustomer]);
        public bool IsRushOrder => Rules.ContainsKey(RuleNames.IsRushOrder) && GetRuleValue<bool>(Rules[RuleNames.IsRushOrder]);
        public OrderType OrderType => Rules.ContainsKey(RuleNames.OrderType) ? GetRuleValue<OrderType>(Rules[RuleNames.OrderType]) : Enums.OrderType.All;
        public int Priority => Rules.ContainsKey(RuleNames.Priority) ? GetRuleValue<int>(Rules[RuleNames.Priority]) : 0;

        public OrderStatus OrderStatus;

        public Dictionary<RuleNames,object> Rules = new Dictionary<RuleNames,object>();

        public T GetRuleValue<T>(object orderRule)
        {
            return (T)orderRule;
        }
    }

    public class RuleV2
    { 
        public RuleNames RuleName;
        public object RuleValue;

    }
}