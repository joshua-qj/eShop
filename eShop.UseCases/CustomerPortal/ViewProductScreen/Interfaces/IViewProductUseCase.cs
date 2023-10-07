using eShop.CoreBusinees.Models;

namespace eShop.UseCases.CustomerPortal.ViewProductScreen.Interfaces
{
    public interface IViewProductUseCase
    {
        Product Execute(int id);
    }
}