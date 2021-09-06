using ECommerce.Sevice.Interface;
using ECommerce.Sevice.service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.WebApi
{
    public static class StructureMapper
    {
        public static void InitializeStructureMapper(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductcategoryService, ProductcategoryService>();
        }
    }
}
