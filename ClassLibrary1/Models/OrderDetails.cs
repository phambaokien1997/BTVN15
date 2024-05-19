using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuVien.Data.Models
{
    public class OrderDetails
    {
        public int ID { get; set; } // ID chi tiết đơn đặt hàng làm khóa chính
        public int BookID { get; set; } // Khóa ngoại tham chiếu đến Book
        public int OrderID { get; set; } // Khóa ngoại tham chiếu đến Order
        public int CustomerID { get; set; } // Khóa ngoại tham chiếu đến Customer
        public int Quantity { get; set; }
        public int PriceAtOrder { get; set; }

        public Books? Book { get; set; } // Một chi tiết đơn đặt hàng thuộc về một cuốn sách
        public Orders? Order { get; set; } // Một chi tiết đơn đặt hàng thuộc về một đơn đặt hàng
        public Customers? Customer { get; set; } // Một chi tiết đơn đặt hàng thuộc về một khách hàng
    }
}
