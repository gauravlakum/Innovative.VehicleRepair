using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innovative.VehicleRepair.Application.Enums;
using Innovative.VehicleRepair.Application.Models;

namespace Innovative.VehicleRepair.Application.Repositories
{
    public interface IRuleRepository
    {
        List<OrderRule> GetRule(OrderInput input);
    }
}
