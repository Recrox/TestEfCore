using Microsoft.IdentityModel.Tokens;
using testEfCore.Models;
using testEfCore.Repositories;

namespace testEfCore.Domains
{
    public class FinanceDomain
    {
        private readonly IFinanceRepository financeRepository;
        public FinanceDomain(IFinanceRepository financeRepository)
        {
            this.financeRepository = financeRepository;
        }

        public async Task InsertDataFin()
        {
            // Exemple d'ajout d'une entité à la base de données
            var finDataToAdd = new FinData
            {
                PERIOD = "2023-09",
                ANAACCCD = "XYZ",
                GENACCCD = "ABC",
                ENVIRO = "Env1",
                FOLDER = "Folder1",
                PROJECT = 1,
                PERSON = 2,
                REALIZED = 1000.50m,
                ACCDS1AC = "AC001",
            };

            await financeRepository.Add(finDataToAdd);
            await financeRepository.Update(finDataToAdd);
        }

        public async Task ShowAllFinData()
        {
            var datas = await this.financeRepository.GetAll();
            foreach (var data in datas)
            {
                await financeRepository.Get(data.Id);
                Console.WriteLine($"{data.Id} {data.ENVIRO} {data.REALIZED}");
            }
            
        }

        public async Task GetFinData(int id)
        {
            var datas = await this.financeRepository.GetAll();
            if (datas.IsNullOrEmpty())
            {
                return;
            }
            var existingId = datas.FirstOrDefault()!.Id;
            var data = await this.financeRepository.Get(existingId);
            Console.WriteLine($"{data.Id} {data.ENVIRO} {data.REALIZED}");
        }
    }
}
