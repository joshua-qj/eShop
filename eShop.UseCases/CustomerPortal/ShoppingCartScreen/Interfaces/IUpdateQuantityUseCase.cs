using eShop.CoreBusinees.Models;
using System.Threading.Tasks;

namespace eShop.UseCases.CustomerPortal.ShoppingCartScreen.Interfaces
{
    public interface IUpdateQuantityUseCase
    {
        Task<Order> Execute(int productId, int quantity);
    }
}