using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }

        public OrderDetail()
        {
        }

        public OrderDetail(int orderId, int productId, int unitPrice, int quantity, float discount)
        {
            OrderId = orderId;
            ProductId = productId;
   
            UnitPrice = unitPrice;
            Quantity = quantity;
            Discount = discount;
        }

    }


}
