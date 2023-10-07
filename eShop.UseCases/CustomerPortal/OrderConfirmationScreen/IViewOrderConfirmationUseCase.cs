using eShop.CoreBusinees.Models;

namespace eShop.UseCases.CustomerPortal.OrderConfirmationScreen
{
    public interface IViewOrderConfirmationUseCase
    {
        Order Execute(string uniqueId);
    }
}