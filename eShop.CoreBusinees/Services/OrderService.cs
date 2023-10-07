using eShop.CoreBusinees.Models;
using eShop.CoreBusinees.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.CoreBusinees.Services
{
    public class OrderService : IOrderService {
        public bool ValidateCustomerInformation(
            string name,
            string address,
            string city,
            string province,
            string country
            ) {
            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(city) ||
                string.IsNullOrEmpty(province) ||
                string.IsNullOrEmpty(country)
                ) { return false; }
            return true;
        }


        public bool ValidateCreateOrder(Order order) {
            //order has to exist
            if (order is null) {
                return false;
            }
            //order has to have order line items
            if (order.LineItems is null || order.LineItems.Count <= 0) {
                return false;
            }
            //validating line items
            foreach (var item in order.LineItems) {
                if (item.ProductId <= 0 ||
                    item.Price < 0 ||
                        item.Quantity <= 0) {
                    return false;
                }
            }
            //validate customer info
            if (!ValidateCustomerInformation(
                order.CustomerName,
                order.CustomerAddress,
                order.CustomerCity,
                order.CustomerState,
                order.CustomerCountry
                )) {
                return false;
            }
            return true;
        }
        public bool ValidateUpdateOrder(Order order) {
            //order has to exist
            if (order is null) {
                return false;
            }
            if (!order.OrderId.HasValue) {
                return false;
            }
            //order has to have order line items
            if (order.LineItems is null || order.LineItems.Count <= 0) {
                return false;
            }
            //Place date has to be populated
            if (!order.DatePlaced.HasValue) {
                return false;
            }
            // other dates
            if (order.DateProcessed.HasValue || order.DateProcessing.HasValue) {
                return false;
            }

            //validating uniqueId
            if (string.IsNullOrWhiteSpace(order.UniqueId)) {
                return false;
            }
            //validating line items
            foreach (var item in order.LineItems) {
                if (item.ProductId <= 0 ||
                    item.Price < 0 ||
                        item.Quantity <= 0) {
                    return false;
                }
            }
            //validate customer info
            if (!ValidateCustomerInformation(
                order.CustomerName,
                order.CustomerAddress,
                order.CustomerCity,
                order.CustomerState,
                order.CustomerCountry
                )) {
                return false;
            }
            return true;
        }

        public bool ValidateProcessOrder(Order order) {
            if (!order.DateProcessed.HasValue ||
                string.IsNullOrWhiteSpace(order.AdminUser)) {
                return false;
            }
            return true;
        }
    }
}
