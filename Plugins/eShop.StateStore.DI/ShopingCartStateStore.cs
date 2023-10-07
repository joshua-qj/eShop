﻿using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.UseCases.PluginInterfaces.UI;
using System.Threading.Tasks;

namespace eShop.StateStore.DI {
    public class ShopingCartStateStore : StateStoreBase, IShoppingCartStateStore {
        private readonly IShoppingCart _shoppingCart;

        public ShopingCartStateStore(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        public async Task<int> GetItemsCount() {
            var order=await _shoppingCart.GetOrderAsync(); 
            if (order != null && order.LineItems != null && order.LineItems.Count > 0) {
                return order.LineItems.Count;
            }
            return 0;
        }

        public void UpdateLineItemsCount() {
            base.BroadCastStateChange();
        }

        public void UpdateProductQuantity() {
            base.BroadCastStateChange();
        }
    }
}
