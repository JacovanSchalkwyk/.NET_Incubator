namespace Pezza.Core
{
    using System.Reflection;
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Pezza.Common.Behaviours;
    using Pezza.Common.DTO;
    using Pezza.Common.Profiles;
    using Pezza.DataAccess.Contracts;
    using Pezza.DataAccess.Data;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddTransient(typeof(IDataAccess<OrderDTO>), typeof(OrderDataAccess));
            services.AddTransient(typeof(IDataAccess<StockDTO>), typeof(StockDataAccess));
            services.AddTransient(typeof(IDataAccess<NotifyDTO>), typeof(NotifyDataAccess));
            services.AddTransient(typeof(IDataAccess<ProductDTO>), typeof(ProductDataAccess));
            services.AddTransient(typeof(IDataAccess<CustomerDTO>), typeof(CustomerDataAccess));
            services.AddTransient(typeof(IDataAccess<RestaurantDTO>), typeof(RestaurantDataAccess));

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddLazyCache();

            return services;
        }
    }
}
