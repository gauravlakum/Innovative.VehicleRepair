using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innovative.VehicleRepair.Application.Enums;
using Innovative.VehicleRepair.Application.Models;
using Innovative.VehicleRepair.Application.Repositories;
using Innovative.VehicleRepair.Application.Services;
using NSubstitute;
using NUnit.Framework;

namespace Innovative.VehicleRepair.Application.Tests
{
 
    [TestFixture]
    public class OrderServiceTests
    {
        private IOrderService _sut;
        private IRuleRepository _ruleRepository;

        [SetUp]
        public void SetUp()
        {
            _ruleRepository = Substitute.For<IRuleRepository>();
            _sut = new OrderService(_ruleRepository);
        }

        [Test]
        public void ProcessProcessOrder_WhenRuleFoundForSpecifiedInputs_shouldReturnFoundRuleStatus()
        {
            //arrange
            var orderStatusToReturn = OrderStatus.Closed;
            var orderRuleToReturn = new OrderRule {OrderStatus = orderStatusToReturn};
            var orderRulesToReturn = new List<OrderRule>
                {
                    orderRuleToReturn
                };

            _ruleRepository.GetRule(Arg.Any<OrderInput>()).Returns(orderRulesToReturn);

            //act
            var result = _sut.ProcessOrder(new OrderInput
            {
                IsLargeOrder = true,
                IsNewCustomer = true,
                IsRushOrder = false,
                OrderType = OrderType.Repair
            });

            //assert
            Assert.AreEqual(orderStatusToReturn, result);
        }
        [Test]
        public void ProcessProcessOrder_WhenRuleNotFoundForSpecifiedInputs_shouldReturnConfirmStatus()
        {
            //arrange
            var orderStatusToReturn = OrderStatus.Confirmed;
            var orderRulesToReturn = new List<OrderRule>();

            _ruleRepository.GetRule(Arg.Any<OrderInput>()).Returns(orderRulesToReturn);

            //act
            var result = _sut.ProcessOrder(new OrderInput
            {
                IsLargeOrder = true,
                IsNewCustomer = true,
                IsRushOrder = false,
                OrderType = OrderType.Repair
            });

            //assert
            Assert.AreEqual(orderStatusToReturn, result);
        }

    }
}
