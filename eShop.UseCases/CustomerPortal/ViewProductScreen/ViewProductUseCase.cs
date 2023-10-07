using eShop.CoreBusinees.Models;
using eShop.UseCases.CustomerPortal.ViewProductScreen.Interfaces;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace eShop.UseCases.CustomerPortal.ViewProductScreen
{
    public class ViewProductUseCase : IViewProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public ViewProductUseCase(IProductRepository
             productRepository)
        {
            _productRepository = productRepository;
        }
        public Product Execute(int id)
        {
            return _productRepository.GetProduct(id);
        }
    }
}
