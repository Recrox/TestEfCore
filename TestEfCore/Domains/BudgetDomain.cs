﻿using Microsoft.IdentityModel.Tokens;
using testEfCore.Models;
using testEfCore.Repositories;

namespace testEfCore.Domains
{
    public class BudgetDomain
    {
        private readonly IBudgetRepository budgetRepository;

        public BudgetDomain(IBudgetRepository budgetRepository)
        {
            this.budgetRepository=budgetRepository;
        }

        public async Task InsertBudgetData()
        {
            // Exemple d'ajout d'une entité à la base de données
            var finDataToAdd = new BudgetData
            {
                Name = $"name: {Guid.NewGuid().ToString()}",

            };

            await budgetRepository.AddAsync(finDataToAdd);
        }

        public async Task ShowAllBudgetData()
        {
            var datas = await this.budgetRepository.GetAllAsync();
            foreach (var data in datas)
            {
                Console.WriteLine($"{data.Id} {data.Name}");
            }
        }

        public async Task GetBudgetData(int id)
        {
            var datas = await this.budgetRepository.GetAllAsync();
            if (datas.IsNullOrEmpty())
            {
                return;
            }
            var existingId = datas.FirstOrDefault()!.Id;
            var data = await this.budgetRepository.GetAsync(existingId);
            Console.WriteLine($"{data.Id} {data.Name}");
        }
    }
}
