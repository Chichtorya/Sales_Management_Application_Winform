using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Weight { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public Product()
        {
        }

        public Product(int categoryId, string productName, string weight, decimal unitPrice, int unitsInStock)
        {
            CategoryId = categoryId;
            ProductName = productName;
            Weight = weight;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
        }

        public Product(int productId, int categoryId, string productName, string weight, int unitPrice, int unitInStock)
        {
            ProductId = productId;
            CategoryId = categoryId;
            ProductName = productName;

            this.Weight = weight;
            UnitPrice = unitPrice;
            UnitsInStock = unitInStock;
        }
        public bool IsValid()
        {
            // Check that all required fields are non-empty
            if (string.IsNullOrEmpty(ProductName) )
            {
                return false;
            }


            // All checks passed, the member is valid
            return true;
        }
    }

}
