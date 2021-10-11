using System;
using System.Collections.Generic;
using Innovative.VehicleRepair.Application.Enums;

namespace Innovative.VehicleRepair.Application.Models
{
    public class OrderRule
    {
        public byte Priority;
        public bool IsRushOrder;
        public OrderType OrderType;
        public bool IsNewCustomer;
        public bool IsLargeOrder;
        public OrderStatus OrderStatus;


        //public string RuleName;
        //public object RuleValue;
        //public Type RuleValueType;

    }

    public enum RuleNames
    {
        Priority,
        IsRushOrder,
        OrderType,
        IsNewCustomer,
        IsLargeOrder,
        OrderStatus

    }
}