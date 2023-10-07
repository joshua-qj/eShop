using eShop.CoreBusinees.Models;
using System.Collections.Generic;

namespace eShop.UseCases.AdminPortal.ProcessedOrdersScreen {
    public interface IViewProcessedOrdersUseCase {
        IEnumerable<Order> Execute();
    }
}