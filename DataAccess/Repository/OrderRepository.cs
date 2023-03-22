using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;





using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;

   

        public OrderRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = _dbContext.Order.ToList();
            
            return orders;
        }

        public Order GetOrderById(int id)
        {
            return _dbContext.Order.FirstOrDefault(o => o.OrderId == id);
        }

        public void AddOrder(Order order)
        {
            _dbContext.Order.Add(order);
            _dbContext.SaveChanges();
        }

        public string UpdateOrder(Order order)
        {


            try
            {

                _dbContext.Entry(order).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {

                return e.ToString();
            }
            
        }

        public void DeleteOrder(int id)
        {
            var order = _dbContext.Order.FirstOrDefault(o => o.OrderId == id);
            _dbContext.Order.Remove(order);
            _dbContext.SaveChanges();
        }

       

       
      
        public IEnumerable<(int MemberId, decimal TotalSales)> GetSalesByPeriod(DateTime startDate, DateTime endDate)
        {
            var orders = _dbContext.Order
        .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
        .ToList();

            var salesByMember = orders
                .GroupBy(o => o.MemberId)
                .Select(g => new
                {
                    MemberId = g.Key,
                    TotalSales = g.Sum(o => o.Freight)
                })
                .OrderByDescending(s => s.TotalSales)
                .ToList();

            return salesByMember.Select(s => (s.MemberId, s.TotalSales));
        }

       

      

        List<Order> IOrderRepository.GetOrderListById(int memberid)
        {
            throw new NotImplementedException();
        }
    }
}
