using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddSingleton<ICarServices,CarManager>();
            //services.AddTransient<ICarDal,EfCarDal>();
            
            //services.AddSingleton<IColorServices, ColorManager>();
            //services.AddTransient<IColorDal, EfColorDal>();

            //services.AddSingleton<IBrandServices, BrandManager>();
            //services.AddTransient<IBrandDal, EfBrandDal>();

            //services.AddSingleton<ICustomerServices, CustomerManager>();
            //services.AddTransient<ICustomerDal, EfCustomerDal>();

            //services.AddSingleton<IRentalServices, RentalManager>();
            //services.AddTransient<IRentalDal, EfRentalDal>();

            //services.AddSingleton<IUserServices, UserManager>();
            //services.AddTransient<IUserDal, EfUserDal>();

            //IOC yap�land�r�lmas�
            //Biz Autofac kullancaz. ��nk� AOP sa�l�yor



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
