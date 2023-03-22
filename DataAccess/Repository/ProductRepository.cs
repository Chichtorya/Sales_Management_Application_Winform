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
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _dbContext;
        public ProductRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _dbContext.Set<Product>().ToList();
            return products;
        }

        public Product GetProductById(int id)
        {
            var product = _dbContext.Set<Product>().FirstOrDefault(p => p.ProductId == id);
            return product;
        }

        public void AddProduct(Product product)
        {
            _dbContext.Set<Product>().Add(product);
            _dbContext.SaveChanges();
        }

        public string UpdateProduct(Product product)
        {
            try
            {
                _dbContext.Set<Product>().Update(product);
                _dbContext.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {

                return e.ToString();
            }
            
        }

        public void DeleteProduct(int id)
        {
            var product = _dbContext.Set<Product>().FirstOrDefault(p => p.ProductId == id);
            _dbContext.Set<Product>().Remove(product);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Product> SearchProducts(string keyword, int? productId, int? unitPrice, int? unitInStock)
        {
            var products = _dbContext.Set<Product>().AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                products = products.Where(p => p.ProductName.Contains(keyword));
            }

            if (productId.HasValue)
            {
                products = products.Where(p => p.ProductId == productId.Value);
            }

            if (unitPrice.HasValue)
            {
                products = products.Where(p => p.UnitPrice == unitPrice.Value);
            }

            if (unitInStock.HasValue)
            {
                products = products.Where(p => p.UnitsInStock == unitInStock.Value);
            }

            return products.ToList();
        }
    }
}
