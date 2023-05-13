using FastExpressionCompiler;
using FluentValidation;
using Mapster;
using Marketplace.Admin.Application.AccountManagement.Admin.BlockAdminAccount;
using Marketplace.Admin.Application.AccountManagement.Admin.CreateAdminAccount;
using Marketplace.Admin.Application.AccountManagement.Admin.GetAdminAccounts;
using Marketplace.Admin.Application.AccountManagement.Admin.UnblockAdminAccount;
using Marketplace.Admin.Application.AccountManagement.Buyer.BlockBuyerAccount;
using Marketplace.Admin.Application.AccountManagement.Buyer.CreateBuyerAccount;
using Marketplace.Admin.Application.AccountManagement.Buyer.GetBuyerAccounts;
using Marketplace.Admin.Application.AccountManagement.Buyer.UnblockBuyerAccount;
using Marketplace.Admin.Application.AccountManagement.LogisticsStaff.BlockLogisticsStaffAccount;
using Marketplace.Admin.Application.AccountManagement.LogisticsStaff.CreateLogisticsStaffAccount;
using Marketplace.Admin.Application.AccountManagement.LogisticsStaff.GetLogisticsStaffAccounts;
using Marketplace.Admin.Application.AccountManagement.LogisticsStaff.UnblockLogisticsStaffAccount;
using Marketplace.Admin.Application.AccountManagement.Seller.BlockSellerAccount;
using Marketplace.Admin.Application.AccountManagement.Seller.CreateSellerAccount;
using Marketplace.Admin.Application.AccountManagement.Seller.GetSellerAccounts;
using Marketplace.Admin.Application.AccountManagement.Seller.UnblockSellerAccount;
using Marketplace.Admin.Application.Behaviors;
using Marketplace.Admin.Application.Common;
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
