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
        public static IServiceCollection AddCatalogAppBusiness(this IServiceCollection services)
        {
            services.AddScoped<IProductBusiness, ProductBusiness>();
            return services;
        }
    }
}
