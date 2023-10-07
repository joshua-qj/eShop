using eShop.CoreBusinees.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.AdminPortal.ProcessedOrdersScreen {
    public class ViewProcessedOrdersUseCase : IViewProcessedOrdersUseCase {
        private readonly IOrderRepository _orderRepository;

        public ViewProcessedOrdersUseCase(IOrderRepository orderRepository) {
            _orderRepository = orderRepository;
        }
        public IEnumerable<Order> Execute() {
            return _orderRepository.GetProcessedOrders();
        }
    }
}
