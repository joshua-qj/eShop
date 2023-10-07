using eShop.CoreBusinees.Models;
using System.Threading.Tasks;

namespace eShop.UseCases.CustomerPortal.ShoppingCartScreen.Interfaces
{
    public interface IDeleteProductUseCase
    {
        Task<Order> Execute(int productId);
    }
}