using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshop.Api.Models;
using Bookshop.BussinesLogic.Services;
using Bookshop.DataAccess.MSSQL;
using Bookshop.DataAccess.MSSQL.Repository;
using Bookshop.Domain.Interface;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bookshop.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IShowcaseRepository, ShowcaseRepository>();
            services.AddTransient<IShowcaseService, ShowcaseService>();

            services.AddTransient<IBookService, BookService>();

            services.AddTransient<IValidator<CreateBookRequest>, CreateBookRequestValidation>();
            services.AddTransient<IValidator<CreateShowcaseRequest>, CreateShowcaseRequestValidator>();
            services.AddTransient<IValidator<BookDto>, BookDtoValidation>();
            services.AddTransient<IValidator<ShowcaseDto>, ShowcaseDtoValidation>();
            
            services.AddDbContext<BookshopContext>(x =>
                x.UseSqlServer(_configuration.GetConnectionString("BookshopContext")));
            services.AddAutoMapper(typeof(MssqlAutoMapperProfile),typeof(ApiAutoMapperProfile));

            
            services.AddControllers().AddFluentValidation();
            services.AddSwaggerGen();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V2");
                x.RoutePrefix = string.Empty;
            });
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    
}
