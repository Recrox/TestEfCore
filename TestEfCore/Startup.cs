using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using testEfCore.Domains;
using testEfCore.Repositories;

namespace testEfCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BepContext>();

            services.AddTransient<IFinanceRepository, FinanceRepository>();
            services.AddTransient<FinanceDomain, FinanceDomain>();

            services.AddTransient<IBudgetRepository, BudgetRepository>();
            services.AddTransient<BudgetDomain, BudgetDomain>();
        }

        public void Configure(IApplicationBuilder app)
        {

        }
    }
}