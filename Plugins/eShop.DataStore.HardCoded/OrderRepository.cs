using eShop.CoreBusinees.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShop.DataStore.HardCoded {
    public class OrderRepository : IOrderRepository {
        private Dictionary<int, Order> _orders;
        public OrderRepository()
        {
                _orders = new Dictionary<int, Order>();
        }
        public int CreateOrder(Order order) {
            order.OrderId = _orders.Count + 1;
           // order.UniqueId = Guid.NewGuid().ToString();
            _orders.Add(order.OrderId.Value, order);
            return order.OrderId.Value;
        }

        public IEnumerable<OrderLineItem> GetLineItemsByOrderId(int orderId) {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id) {
            return _orders[id];
        }

        public Order GetOrderByUniqueId(string uniqueId) {
            foreach (var order in _orders) {
                if (order.Value.UniqueId==uniqueId) {
                    return order.Value;
                }
            }
            return null;
        }

        public IEnumerable<Order> GetOrders() {
            return _orders.Values;
        }

        public IEnumerable<Order> GetOutstandingOrders() {
            var allOrders=(IEnumerable<Order>) _orders.Values;
            return allOrders.Where(o => !o.DateProcessed.HasValue);
        }

        public IEnumerable<Order> GetProcessedOrders() {
            var allOrders = (IEnumerable<Order>)_orders.Values;
            return allOrders.Where(o => o.DateProcessed.HasValue);
        }

        public void UpdateOrder(Order order) {
            if (order is null || !order.OrderId.HasValue) {
                return;
            }
            var ord = _orders[order.OrderId.Value];
            if (ord is null) {
                return;
            }
            _orders[order.OrderId.Value] = order;
        }
    }
}
