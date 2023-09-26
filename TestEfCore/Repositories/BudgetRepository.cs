using System;
using testEfCore.Models;
using testEfCore.Repositories.Factory;

namespace testEfCore.Repositories
{
    public class BudgetRepository : Repository<BudgetData>, IBudgetRepository
    {
        public BudgetRepository(BepContext bepContext) : base(bepContext) 
        {

        }

        public Task methodRandomBudget()
        {
            throw new NotImplementedException();
        }
    }
}
