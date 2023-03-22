using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
        
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        string UpdateProduct(Product product);
        void DeleteProduct(int id);
        public IEnumerable<Product> SearchProducts(string keyword, int? productId, int? unitPrice, int? unitInStock);
    }
}
