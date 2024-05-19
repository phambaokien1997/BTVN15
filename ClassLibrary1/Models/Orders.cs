using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuVien.Data.Models
{
    public class Orders
    {
        public int ID { get; set; } // ID đơn đặt hàng làm khóa chính
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; } // Khóa ngoại tham chiếu đến Customer
        public string? ShippingAddress { get; set; }
        public int TotalAmount { get; set; }

        public Customers? Customer { get; set; } // Một đơn đặt hàng chỉ thuộc về một khách hàng

        public List<OrderDetails>? OrderDetails { get; set; } // Một đơn đặt hàng có nhiều đơn đặt hàng chi tiết
    }
}
