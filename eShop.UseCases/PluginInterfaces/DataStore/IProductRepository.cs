using eShop.CoreBusinees.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.PluginInterfaces.DataStore {
    public interface IProductRepository {
        IEnumerable<Product> GetProducts(string filter=null);
        Product GetProduct(int id);
    }
}
