using eShop.CoreBusinees.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.UI;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace eShop.ShoppingCart.LocalStorage {
    public class ShoppingCart : IShoppingCart {
        private readonly IJSRuntime _jSRuntime;
        private readonly IProductRepository _productRepository;
        private const string cstrShoppingCart = "eShop.ShoppingCart";

        public ShoppingCart(IJSRuntime jSRuntime, IProductRepository productRepository) {
            _jSRuntime = jSRuntime;
            _productRepository = productRepository;
        }
        public async Task<Order> AddProductAsync(Product product) {
            var order = await GetOrder();
            order.AddProudct(product.ProductId, 1, product.Price);
            await SetOrderAsync(order);
            return order;
        }

        public async Task<Order> DeleteProductAsync(int productId) {
            var order = await GetOrder();
            order.RemoveProduct(productId);
            await SetOrderAsync(order);
            return order;
        }

        public Task EmptyAsync() {
            return SetOrderAsync(null);
            /*
             * it will cstrShoppingCart value to a string "null".
             *         private async Task SetOrderAsync(Order order) {
            await _jSRuntime.InvokeAsync<string>("localStorage.setItem", cstrShoppingCart,JsonConvert.SerializeObject(order));
        }
             
             */
        }

        public async Task<Order> GetOrderAsync() {
            return await GetOrder();
        }

        public Task<Order> PlaceOrderAsync() {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateOrderAsync(Order order) {
            await SetOrderAsync(order);
            return order;
        }

        public async Task<Order> UpdateQuantityAsync(int productId, int quantity) {
            var order = await GetOrder();
            if (quantity < 0) { return order; } else if (quantity == 0) {
                return await DeleteProductAsync(productId);
            }
            var lineItem = order.LineItems.SingleOrDefault(x => x.ProductId == productId);
                if (lineItem != null) { lineItem.Quantity = quantity; }
            await SetOrderAsync(order);
            return order;
        }

        private async Task<Order> GetOrder() {
            Order order = null;
            var strOrder = await _jSRuntime.InvokeAsync<string>("localStorage.getItem", cstrShoppingCart);
            if (!string.IsNullOrWhiteSpace(strOrder) && strOrder.ToLower() != "null") {
                order = JsonConvert.DeserializeObject<Order>(strOrder);
            } else {
                order = new Order();
                await SetOrderAsync(order);
            }
            //get all of proudct object loaded
            foreach (var item in order.LineItems) {
                item.Product = _productRepository.GetProduct(item.ProductId);
            }
            return order;
        }

        private async Task SetOrderAsync(Order order) {
            await _jSRuntime.InvokeAsync<string>("localStorage.setItem", cstrShoppingCart, JsonConvert.SerializeObject(order));
        }
    }
}
