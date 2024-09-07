using SQL_Last_Assignment.DbContexts;
using SQL_Last_Assignment.IRepositories;

namespace SQL_Last_Assignment.Repositories
{
    public class OrderDetailRepo : IOrderDetailRepo
    {
        private readonly CompanyDbContext _companydbcontext;

        public OrderDetailRepo(CompanyDbContext companydbcontext)
        {
            _companydbcontext = companydbcontext;
        }
    }
}
