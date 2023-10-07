using eShop.CoreBusinees.Models;
using System.Threading.Tasks;

namespace eShop.UseCases.CustomerPortal.ShoppingCartScreen.Interfaces
{
    public interface IViewShoppingCartUseCase
    {
        Task<Order> Execute();
    }
}