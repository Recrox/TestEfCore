using testEfCore.Models;
using testEfCore.Repositories.Factory;

namespace testEfCore.Repositories
{
    public interface IBudgetRepository : IRepository<BudgetData>
    {
        Task methodRandomBudget();
    }
}