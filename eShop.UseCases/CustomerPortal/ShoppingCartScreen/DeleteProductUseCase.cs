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
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IShoppingCartStateStore _shoppingCartStateStore;

        public DeleteProductUseCase(IShoppingCart shoppingCart, IShoppingCartStateStore shoppingCartStateStore)
        {
            _shoppingCart = shoppingCart;
            _shoppingCartStateStore = shoppingCartStateStore;
        }
        public async Task<Order> Execute(int productId)
        {
            var order = await _shoppingCart.DeleteProductAsync(productId);
            _shoppingCartStateStore.UpdateLineItemsCount();
            return order;
        }
    }
}
