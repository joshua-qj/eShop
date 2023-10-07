using eShop.CoreBusinees.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.AdminPortal.OutstandingOrderScreen
{
    public class ViewOutstandingOrdersUseCase : IViewOutstandingOrdersUseCase {
        private readonly IOrderRepository _orderRepository;

        public ViewOutstandingOrdersUseCase(IOrderRepository orderRepository) {
            _orderRepository = orderRepository;
        }
        public IEnumerable<Order> Execute() {
            return _orderRepository.GetOutstandingOrders();
        }
    }
}
