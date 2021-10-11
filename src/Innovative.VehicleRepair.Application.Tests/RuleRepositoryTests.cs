using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innovative.VehicleRepair.Application.Enums;
using Innovative.VehicleRepair.Application.Models;
using Innovative.VehicleRepair.Application.Repositories;
using NUnit.Framework;

namespace Innovative.VehicleRepair.Application.Tests
{
    [TestFixture]
    public class RuleRepositoryTests
    {
        private IRuleRepository _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new RuleRepository();
        }

        [TestCaseSource(typeof(OrderRuleTestCaseFactory), nameof(OrderRuleTestCaseFactory.OrderRuleCases))]
        public void GetRule_WhenMatchingInputProvided_ShouldReturnRelevantRule(OrderInput input, IList<OrderRule> output)
        {
            //Act
            var result = _sut.GetRule(input);

            //assert
            Assert.AreEqual(result.First().IsNewCustomer,output.First().IsNewCustomer);
            Assert.AreEqual(result.First().IsRushOrder,output.First().IsRushOrder);
            Assert.AreEqual(result.First().IsLargeOrder,output.First().IsLargeOrder);
            Assert.AreEqual(result.First().OrderType,output.First().OrderType);
            Assert.AreEqual(result.First().OrderStatus,output.First().OrderStatus);
        }

        [TestCaseSource(typeof(OrderRuleTestCaseFactory), nameof(OrderRuleTestCaseFactory.DefaultRuleCase))]
        public void GetRule_WhenNoMatchingInputProvided_ShouldNotReturnAnyRule(OrderInput input, IList<OrderRule> output)
        {
            //act
            var result = _sut.GetRule(input);

            //assert
            Assert.IsTrue(!result.Any());
        }

        private class OrderRuleTestCaseFactory
        {
            public static IEnumerable OrderRuleCases
            {
                get
                {
                    //Large repair orders for new customers should be closed
                    var largeRepairForNewCustomerRule = new OrderRule
                    {
                        Priority = 1, IsLargeOrder = true, 
                        OrderType = OrderType.Repair, 
                        IsNewCustomer = true,
                        OrderStatus = OrderStatus.Closed
                    };

                    //Large rush hire orders should always be closed
                    var largeRushHireRule = new OrderRule
                    {
                        Priority = 2, IsLargeOrder = true, IsRushOrder = true, OrderType = OrderType.Hire,
                        OrderStatus = OrderStatus.Closed
                    };

                    //Large repair orders always require authorisation
                    var largeRepairOrder = new OrderRule
                    {
                        Priority = 3, IsLargeOrder = true, OrderType = OrderType.Repair,
                        OrderStatus = OrderStatus.AuthorisationRequired
                    };

                    //All rush orders for new customers always require authorisation
                    var allRushOrderForNewCustomerRule = new OrderRule
                    {
                        Priority = 4, IsRushOrder = true, IsNewCustomer = true,
                        OrderStatus = OrderStatus.AuthorisationRequired
                    };

                    yield return new TestCaseData(new OrderInput{IsLargeOrder = true, IsNewCustomer = true, OrderType = OrderType.Repair}, new List<OrderRule> { largeRepairForNewCustomerRule });
                    yield return new TestCaseData(new OrderInput{IsLargeOrder = true, IsRushOrder = true, OrderType = OrderType.Hire}, new List<OrderRule> { largeRushHireRule });
                    yield return new TestCaseData(new OrderInput{IsLargeOrder = true, OrderType = OrderType.Repair}, new List<OrderRule> { largeRepairOrder });
                    yield return new TestCaseData(new OrderInput{IsRushOrder = true, IsNewCustomer = true}, new List<OrderRule> { allRushOrderForNewCustomerRule });

                }
            }

            public static IEnumerable DefaultRuleCase
            {
                get
                {
                    yield return new TestCaseData(new OrderInput { }, new List<OrderRule> { });

                }
            }
        }
    }
}
