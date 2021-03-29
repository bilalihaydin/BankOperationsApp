using BankOperations.Model.Entity;
using BankOperations.Repository.Base;
using BankOperations.Service.Services.AccountService;
using BankOperations.Service.Services.TransactionService;
using BankOperationsApp.Cache;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankOperationsApp
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
            services.AddMemoryCache();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRepository<Account>, Repository<Account>>();

            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IRepository<Transaction>, Repository<Transaction>>();

            services.AddSingleton<ICache, MemoryCacheManager>();
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
