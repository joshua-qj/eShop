﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShop.CoreBusinees.Models {
    public class Order {
        public Order()
        {
            LineItems = new List<OrderLineItem>();
        }
        public int? OrderId { get; set; }
        public DateTime? DatePlaced { get; set; }
        public DateTime? DateProcessing { get; set; }
        public DateTime? DateProcessed { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress{ get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string CustomerCountry { get; set; }
        public string AdminUser{ get; set; }
        public List<OrderLineItem>LineItems { get; set; }
        public string UniqueId { get; set; }

        public void AddProudct(int productId,int qty,double price) {
            var item=LineItems.FirstOrDefault(x=>x.ProductId==productId);
            if (item!=null) {
                item.Quantity += qty;
            }
            else {
                LineItems.Add(new OrderLineItem {  ProductId = productId,Quantity = qty, Price = price });
            }
        }

        public void RemoveProduct(int productId) {
            var item=LineItems.FirstOrDefault(x=>x.ProductId==productId);
            if (item !=null) {
                LineItems.Remove(item);
            }

            //same way
            //foreach (var item in LineItems) {
            //    if (item.ProductId==productId) {
            //        LineItems.Remove(item);
            //        break;
            //    }
            //}
        }
    }
}
