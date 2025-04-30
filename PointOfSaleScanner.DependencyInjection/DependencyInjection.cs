using Microsoft.Extensions.DependencyInjection;
using PointOfSaleScanner.Core;

namespace PointOfSaleScanner.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddPointOfSaleScanner(this IServiceCollection services)
    {
        services.AddSingleton<IPriceSheetRepository, PriceSheetRepository>();
        services.AddSingleton<ICartItemPriceCalculator, StandardCartItemPriceCalculator>();
        services.AddSingleton<IShoppingCart, ShoppingCart>();

        services.AddSingleton<PointOfSaleTerminal>();

        return services;
    }
}
