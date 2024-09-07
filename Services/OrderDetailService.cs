using SQL_Last_Assignment.IRepositories;
using SQL_Last_Assignment.IServices;

namespace SQL_Last_Assignment.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepo _iorderdetailrepo;

        public OrderDetailService(IOrderDetailRepo iorderdetailrepo)
        {
            _iorderdetailrepo = iorderdetailrepo;
        }
    }
}
