﻿using eShop.CoreBusinees.Models;
using System.Collections.Generic;

namespace eShop.UseCases.AdminPortal.OutstandingOrderScreen
{
    public interface IViewOutstandingOrdersUseCase
    {
        IEnumerable<Order> Execute();
    }
}