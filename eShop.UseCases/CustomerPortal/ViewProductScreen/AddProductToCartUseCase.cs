using eShop.UseCases.CustomerPortal.ViewProductScreen.Interfaces;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.UseCases.PluginInterfaces.UI;

namespace eShop.UseCases.CustomerPortal.ViewProductScreen
{
    public class AddProductToCartUseCase : IAddProductToCartUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IShoppingCartStateStore _shoppingCartStateStore;
        private readonly IShoppingCart _shoppingCart;

        public AddProductToCartUseCase(IProductRepository productRepository,
            IShoppingCartStateStore shoppingCartStateStore,
            IShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCartStateStore = shoppingCartStateStore;
            _shoppingCart = shoppingCart;
        }
        public async void Execute(int productId)
        {
            var product = _productRepository.GetProduct(productId);
            await _shoppingCart.AddProductAsync(product);

            //HOOK UP TO shoppingCartStateStore
            _shoppingCartStateStore.UpdateLineItemsCount();
        }
    }
}
