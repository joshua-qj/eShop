using eShop.CoreBusinees.Models;
using eShop.UseCases.CustomerPortal.ShoppingCartScreen.Interfaces;
using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.UseCases.PluginInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.CustomerPortal.ShoppingCartScreen
{
    public class UpdateQuantityUseCase : IUpdateQuantityUseCase
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IShoppingCartStateStore _shoppingCartStateStore;

        public UpdateQuantityUseCase(IShoppingCart shoppingCart, IShoppingCartStateStore shoppingCartStateStore)
        {
            _shoppingCart = shoppingCart;
            _shoppingCartStateStore = shoppingCartStateStore;
        }

        public async Task<Order> Execute(int productId, int quantity)
        {
            var order = await _shoppingCart.UpdateQuantityAsync(productId, quantity);
            _shoppingCartStateStore.UpdateProductQuantity();
            return order;
        }
    }
}
