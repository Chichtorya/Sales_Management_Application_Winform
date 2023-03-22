using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        Order GetOrderById(int id);
        IEnumerable<Order> GetAllOrders();
        void AddOrder(Order order);
        string UpdateOrder(Order order);
        void DeleteOrder(int id);
        public List<Order> GetOrderListById(int memberid);
        public IEnumerable<(int MemberId, decimal TotalSales)> GetSalesByPeriod(DateTime startDate, DateTime endDate);
    }
}
