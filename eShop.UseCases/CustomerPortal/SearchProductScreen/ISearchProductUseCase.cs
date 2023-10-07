using eShop.CoreBusinees.Models;
using System.Collections.Generic;

namespace eShop.UseCases.CustomerPortal.SearchProductScreen
{
    public interface ISearchProductUseCase
    {
        IEnumerable<Product> Execute(string filter = null);
    }
}