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

            await financeRepository.AddAsync(finDataToAdd);
            await financeRepository.UpdateAsync(finDataToAdd);
        }

        public async Task ShowAllFinData()
        {
            var datas = await this.financeRepository.GetAllAsync();
            foreach (var data in datas)
            {
                await financeRepository.GetAsync(data.Id);
                Console.WriteLine($"{data.Id} {data.ENVIRO} {data.REALIZED}");
            }

        }

        public async Task GetFinData(int id)
        {
            var datas = await this.financeRepository.GetAllAsync();
            if (datas.IsNullOrEmpty())
            {
                return;
            }
            var existingId = datas.FirstOrDefault()!.Id;
            var data = await this.financeRepository.GetAsync(existingId);
            Console.WriteLine($"{data.Id} {data.ENVIRO} {data.REALIZED}");
        }

        public async Task Delete(int id)
        {
            try
            {
                var existingData = await this.financeRepository.GetAsync(id);
                await this.financeRepository.DeleteAsync(existingData);
                Console.WriteLine($"{existingData.Id} {existingData.ENVIRO} {existingData.REALIZED} DELETED");
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        public async Task Update(FinData finDataToUpdate)
        {
            // Exemple d'ajout d'une entité à la base de données
            finDataToUpdate = new FinData
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

            var oldFinData = await this.financeRepository.GetAsync(finDataToUpdate.Id);

            finDataToUpdate.ENVIRO = finDataToUpdate.ENVIRO + Guid.NewGuid();
            await this.financeRepository.UpdateAsync(finDataToUpdate);
            Console.WriteLine($"{finDataToUpdate.Id} {finDataToUpdate.ENVIRO} {finDataToUpdate.REALIZED} UPDATED");
        }
    }
}
