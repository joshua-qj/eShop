using eShop.CoreBusinees.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System.Collections.Generic;

namespace eShop.UseCases.CustomerPortal.SearchProductScreen
{
    public class SearchProductUseCase : ISearchProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public SearchProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public IEnumerable<Product> Execute(string filter)
        {
            return _productRepository.GetProducts(filter);
        }
    }
}
