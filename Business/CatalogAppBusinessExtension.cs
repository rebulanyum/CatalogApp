using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using rebulanyum.CatalogApp.Data;

namespace rebulanyum.CatalogApp.Business
{
    public static class CatalogAppBusinessExtension 
    {
        /// <summary>
        /// Simplified business extension for adding all services defined in this library.
        /// </summary>
        /// <param name="services">The services collection</param>
        /// <returns>The services collection</returns>
        public static IServiceCollection AddCatalogAppBusiness(this IServiceCollection services)
        {
            services.AddScoped<IProductBusiness, ProductBusiness>();
            services.AddScoped<Data.V2.IProductBusiness, V2.ProductBusiness>();
            return services;
        }
    }
}
