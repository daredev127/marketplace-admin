using FastExpressionCompiler;
using FluentValidation;
using Mapster;
using Marketplace.Admin.Application.Behaviors;
using Marketplace.Admin.Application.Common;
using Marketplace.Admin.Application.Features.AccountManagement.Admin.BlockAdminAccount;
using Marketplace.Admin.Application.Features.AccountManagement.Admin.CreateAdminAccount;
using Marketplace.Admin.Application.Features.AccountManagement.Admin.GetAdminAccounts;
using Marketplace.Admin.Application.Features.AccountManagement.Admin.UnblockAdminAccount;
using Marketplace.Admin.Application.Features.AccountManagement.Buyer.BlockBuyerAccount;
using Marketplace.Admin.Application.Features.AccountManagement.Buyer.CreateBuyerAccount;
using Marketplace.Admin.Application.Features.AccountManagement.Buyer.GetBuyerAccounts;
using Marketplace.Admin.Application.Features.AccountManagement.Buyer.UnblockBuyerAccount;
using Marketplace.Admin.Application.Features.AccountManagement.LogisticsStaff.BlockLogisticsStaffAccount;
using Marketplace.Admin.Application.Features.AccountManagement.LogisticsStaff.CreateLogisticsStaffAccount;
using Marketplace.Admin.Application.Features.AccountManagement.LogisticsStaff.GetLogisticsStaffAccounts;
using Marketplace.Admin.Application.Features.AccountManagement.LogisticsStaff.UnblockLogisticsStaffAccount;
using Marketplace.Admin.Application.Features.AccountManagement.Seller.BlockSellerAccount;
using Marketplace.Admin.Application.Features.AccountManagement.Seller.CreateSellerAccount;
using Marketplace.Admin.Application.Features.AccountManagement.Seller.GetSellerAccounts;
using Marketplace.Admin.Application.Features.AccountManagement.Seller.UnblockSellerAccount;
using Marketplace.Admin.Application.Features.Auth;
using Marketplace.Admin.Application.Features.Auth.Admin;
using Marketplace.Admin.Application.Features.Auth.Buyer;
using Marketplace.Admin.Application.Features.Auth.LogisticsStaff;
using Marketplace.Admin.Application.Features.Auth.Seller;
using Marketplace.Admin.Application.Features.Demographics.Buyer;
using Marketplace.Admin.Application.Features.Demographics.Seller;
using Marketplace.Admin.Application.Features.Price;
using Marketplace.Admin.Application.Features.Rating.AddProductRating;
using Marketplace.Admin.Application.Features.Rating.GetProductRating;
using Marketplace.Admin.Application.Features.Sales.Common;
using Marketplace.Admin.Application.Features.Sales.MarketplaceSummary;
using Marketplace.Admin.Application.Features.Sales.ProductSalesDetails;
using Marketplace.Admin.Application.Features.Sales.SalesByLocation;
using Marketplace.Admin.Application.Features.Sales.SalesByQuantity;
using Marketplace.Admin.Application.Features.Sales.SalesBySeller;
using Marketplace.Admin.Application.Features.Sales.SalesHistory;
using Marketplace.Admin.Application.Features.Sales.SalesSummary;
using Marketplace.Admin.Application.MappingConfig;
using Marketplace.Admin.Infrastructure.Persistence.Database;
using MassTransit;
using MassTransit.NewIdProviders;
using MediatR;
using System.Reflection;

namespace Marketplace.Admin.API.Configurations
{

    public static class ApplicationSetup
    {
        public static IServiceCollection AddApplicationSetup(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
            services.AddScoped<IContext, DatabaseContext>();
            NewId.SetProcessIdProvider(new CurrentProcessIdProvider());
            ApplyAllMappingConfigFromAssembly();
            TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileFast();

            services.AddScoped<IPasswordUtils, PasswordUtils>();
            services.AddScoped<IJwtUtils, JwtUtils>();

            services.AddScoped<IGetAdminAccountsQueryHandler, GetAdminAccountsQueryHandler>();
            services.AddScoped<ICreateAdminAccountCommandHandler, CreateAdminAccountCommandHandler>();
            services.AddScoped<IBlockAdminAccountCommandHandler, BlockAdminAccountCommandHandler>();
            services.AddScoped<IUnblockAdminAccountCommandHandler, UnblockAdminAccountCommandHandler>();

            services.AddScoped<IGetBuyerAccountsQueryHandler, GetBuyerAccountsQueryHandler>();
            services.AddScoped<ICreateBuyerAccountCommandHandler, CreateBuyerAccountCommandHandler>();
            services.AddScoped<IBlockBuyerAccountCommandHandler, BlockBuyerAccountCommandHandler>();
            services.AddScoped<IUnblockBuyerAccountCommandHandler, UnblockBuyerAccountCommandHandler>();

            services.AddScoped<IGetSellerAccountsQueryHandler, GetSellerAccountsQueryHandler>();
            services.AddScoped<ICreateSellerAccountCommandHandler, CreateSellerAccountCommandHandler>();
            services.AddScoped<IBlockSellerAccountCommandHandler, BlockSellerAccountCommandHandler>();
            services.AddScoped<IUnblockSellerAccountCommandHandler, UnblockSellerAccountCommandHandler>();

            services.AddScoped<IGetLogisticsStaffAccountsQueryHandler, GetLogisticsStaffAccountsQueryHandler>();
            services.AddScoped<ICreateLogisticsStaffAccountCommandHandler, CreateLogisticsStaffAccountCommandHandler>();
            services.AddScoped<IBlockLogisticsStaffAccountCommandHandler, BlockLogisticsStaffAccountCommandHandler>();
            services.AddScoped<IUnblockLogisticsStaffAccountCommandHandler, UnblockLogisticsStaffAccountCommandHandler>();

            services.AddScoped<IAdminLoginCommandHandler, AdminLoginCommandHandler>();
            services.AddScoped<IBuyerLoginCommandHandler, BuyerLoginCommandHandler>();
            services.AddScoped<ISellerLoginCommandHandler, SellerLoginCommandHandler>();
            services.AddScoped<ILogisticsStaffLoginCommandHandler, LogisticsStaffLoginCommandHandler>();

            services.AddScoped<IMarketplaceSummaryAggregator, MarketplaceSummaryAggregator>();
            services.AddScoped<ISalesHistoryService, SalesHistoryService>();

            services.AddScoped<IGetBuyerDemographicsQueryHandler, GetBuyerDemographicsQueryHandler>();
            services.AddScoped<IGetSellerDemographicsQueryHandler, GetSellerDemographicsQueryHandler>();

            services.AddScoped<IGetProductSalesDetailsQueryHandler, GetProductSalesDetailsQueryHandler>();
            services.AddScoped<IGetSalesByLocationQueryHandler, GetSalesByLocationQueryHandler>();
            services.AddScoped<IGetSalesByQuantityQueryHandler, GetSalesByQuantityQueryHandler>();
            services.AddScoped<IGetSalesBySellerQueryHandler, GetSalesBySellerQueryHandler>();
            services.AddScoped<IGetSalesHistoryQueryHandler, GetSalesHistoryQueryHandler>();
            services.AddScoped<IGetSalesSummaryQueryHandler, GetSalesSummaryQueryHandler>();

            services.AddScoped<IGetPriceRangeQueryHandler, GetPriceRangeQueryHandler>();

            services.AddScoped<IGetProductRatingQueryHandler, GetProductRatingQueryHandler>();
            services.AddScoped<IAddProductRatingCommandHandler, AddProductRatingCommandHandler>();

            return services;
        }

        private static IEnumerable<Type> GetTypesWithInterface<TInterface>(Assembly asm)
        {
            var it = typeof(TInterface);
            return asm.GetTypes().Where(x => it.IsAssignableFrom(x) && x is { IsInterface: false, IsAbstract: false });
        }

        private static void ApplyAllMappingConfigFromAssembly()
        {
            var mappers = GetTypesWithInterface<IMappingConfig>(typeof(IMappingConfig).Assembly);
            foreach (var mapperType in mappers)
            {
                var instance = (IMappingConfig)Activator.CreateInstance(mapperType)!;
                instance.ApplyConfig();
            }
        }
    }
}
