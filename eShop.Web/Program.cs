
using eShop.CoreBusinees.Services;
using eShop.CoreBusinees.Services.interfaces;
using eShop.DataStore.HardCoded;
using eShop.ShoppingCart.LocalStorage;
using eShop.StateStore.DI;
using eShop.UseCases.AdminPortal.OrderDetailScreen;
using eShop.UseCases.AdminPortal.OrderDetailScreen.Interfaces;
using eShop.UseCases.AdminPortal.OutstandingOrderScreen;
using eShop.UseCases.AdminPortal.OutstandingOrderScreen.Interfaces;
using eShop.UseCases.AdminPortal.ProcessedOrdersScreen;
using eShop.UseCases.CustomerPortal.OrderConfirmationScreen;
using eShop.UseCases.CustomerPortal.SearchProductScreen;
using eShop.UseCases.CustomerPortal.ShoppingCartScreen;
using eShop.UseCases.CustomerPortal.ShoppingCartScreen.Interfaces;
using eShop.UseCases.CustomerPortal.ViewProductScreen;
using eShop.UseCases.CustomerPortal.ViewProductScreen.Interfaces;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.UseCases.PluginInterfaces.UI;
using eShop.Web.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddControllers();  this is a dependency by app.MapControllers();
//injection Authentication scheme
builder.Services.AddAuthentication("eShop.CookieAuth").AddCookie("eShop.CookieAuth", config => {
    config.Cookie.Name = "eShop.CookieAuth";
    config.LoginPath = "/authenticate";
});

builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<IProductRepository,ProductRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>();
builder.Services.AddScoped<IShoppingCartStateStore, ShopingCartStateStore>();

builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();
builder.Services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
builder.Services.AddTransient<IViewShoppingCartUseCase, ViewShoppingCartUseCase>();
builder.Services.AddTransient<IAddProductToCartUseCase,AddProductToCartUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IUpdateQuantityUseCase, UpdateQuantityUseCase>();
builder.Services.AddTransient<IPlaceOrderUseCase, PlaceOrderUseCase>();
builder.Services.AddTransient<IViewOrderConfirmationUseCase, ViewOrderConfirmationUseCase>();

builder.Services.AddTransient<IViewOutstandingOrdersUseCase, ViewOutstandingOrdersUseCase>();
builder.Services.AddTransient<IViewOrderDetailUseCase, ViewOrderDetailUseCase>();
builder.Services.AddTransient<IProcessOrderUseCase, ProcessOrderUseCase>();
builder.Services.AddTransient<IViewProcessedOrdersUseCase, ViewProcessedOrdersUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
// Summary:
//     Adds endpoints for controller actions to the Microsoft.AspNetCore.Routing.IEndpointRouteBuilder
//     without specifying any routes.
//
// Parameters:
//   endpoints:
//     The Microsoft.AspNetCore.Routing.IEndpointRouteBuilder.
//
// Returns:
//     An Microsoft.AspNetCore.Builder.ControllerActionEndpointConventionBuilder for
//     endpoints associated with controller actions.
// add mvc controller, one controller is a class, it has a bunch of methods and each method is 
//basically represents an endpoint .Blazor has everything points to the same endpoint, 
//within that endpoint, it would do own routing to different page components.
// Every controller has multiple methods and each method is action method and those methods
//has their own routing. In order to find which endpoint the URL maps to, we need to use MapControllers
//if doesnt have MapControllers, blazor will dispaly no page found to controller's endpoint.
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
