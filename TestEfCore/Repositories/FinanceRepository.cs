using testEfCore.Models;
using testEfCore.Repositories.Factory;

namespace testEfCore.Repositories
{
    public class FinanceRepository : Repository<FinData>, IFinanceRepository
    {
        public FinanceRepository(BepContext bepContext) : base(bepContext) 
        {
        
        }
    }
}
