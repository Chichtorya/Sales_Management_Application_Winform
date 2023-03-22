using AutoMapper;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly DbContext _dbContext;

        public OrderDetailRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            return _dbContext.OrderDetail.ToList();
        }

        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return _dbContext.OrderDetail.Where(od => od.OrderId == orderId).ToList();
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _dbContext.OrderDetail.Add(orderDetail);
            _dbContext.SaveChanges();
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _dbContext.Entry(orderDetail).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteOrderDetail(int orderId, int productId)
        {
            var orderDetail = _dbContext.OrderDetail.FirstOrDefault(od => od.OrderId == orderId && od.ProductId == productId);
            _dbContext.OrderDetail.Remove(orderDetail);
            _dbContext.SaveChanges();
        }

        public OrderDetail GetOrderDetailById(int orderDetailId, int productId)
        {
            return _dbContext.OrderDetail.FirstOrDefault(o => o.OrderId == orderDetailId && o.ProductId == productId);
        }

    }



}
