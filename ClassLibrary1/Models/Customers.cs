using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuVien.Data.Models
{
    public class Customers
    {
        public int ID { get; set; } // ID khách hàng làm khóa chính
        public string? CustomerName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }

        public List<Orders>?Orders { get; set; } // Một khách hàng có nhiều đơn đặt hàng
    }
}
