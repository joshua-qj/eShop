using eShop.CoreBusinees.Models;
using eShop.UseCases.CustomerPortal.ShoppingCartScreen.Interfaces;
using eShop.UseCases.PluginInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.CustomerPortal.ShoppingCartScreen
{
    public class ViewShoppingCartUseCase : IViewShoppingCartUseCase
    {
        private readonly IShoppingCart _shoppingCart;

        public ViewShoppingCartUseCase(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        public Task<Order> Execute()
        {
            return _shoppingCart.GetOrderAsync();
        }
    }
}
