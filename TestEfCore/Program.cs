﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using testEfCore.Domains;

namespace testEfCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseStartup<Startup>() // Utilisez la classe Startup pour configurer les services et le pipeline
                .Build();

            //host.Run();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                var financeDomain = services.GetRequiredService<FinanceDomain>();
                financeDomain.InsertDataFin().GetAwaiter().GetResult();
                financeDomain.ShowAllFinData().GetAwaiter().GetResult();

                var budgetDomain = services.GetRequiredService<BudgetDomain>();
                budgetDomain.InsertBudgetData().GetAwaiter().GetResult();
                budgetDomain.ShowAllBudgetData().GetAwaiter().GetResult();
            }
        }
    }
}



