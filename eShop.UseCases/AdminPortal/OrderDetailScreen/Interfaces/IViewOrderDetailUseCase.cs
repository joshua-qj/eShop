using eShop.CoreBusinees.Models;

namespace eShop.UseCases.AdminPortal.OutstandingOrderScreen.Interfaces
{
    public interface IViewOrderDetailUseCase
    {
        Order Execute(int orderId);
    }
}