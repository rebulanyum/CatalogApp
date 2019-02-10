using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using rebulanyum.CatalogApp.Business;
using Microsoft.AspNetCore.Mvc.Versioning;
using Swashbuckle.AspNetCore.Swagger;

namespace rebulanyum.CatalogApp.WebAPI
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()));

            services.AddMvc(/*o => o.Conventions.Add(new APIRoutePrefixConvention("api"))*/)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            var connection = Configuration.GetConnectionString("rebulanyum.CatalogApp");
            services.AddDbContext<CatalogAppContext>(options => options.UseSqlServer(connection));
            services.AddCatalogAppBusiness();

            services.AddApiVersioning(options => {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                //options.Conventions.Add(new APIRoutePrefixConvention($"v{{version:{options.RouteConstraintName}}}", true));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("CatalogApp", new Info {
                    Title = "CatalogApp API", Version = "v1.0",
                    Contact = new Contact() { Name = "Izzet Sapkalioglu Ojalvo", Url = "https://github.com/rebulanyum/CatalogApp" },
                    Description = "With this API you can retrieve, create, update & delete Product entities."
                });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(options =>
                options.RouteTemplate = "api-docs/{documentName}/swagger.json"
            );

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api-docs/CatalogApp/swagger.json", "CatalogApp");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors("CorsPolicy");

            app.UseMvc();
        }
    }
}
