using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuVien.Data.Models
{
    public class Books
    {
        public int ID { get; set; } // ID cuốn sách làm khóa chính
        public string? Title { get; set; }
        public string? Category { get; set; }
        public int Price { get; set; }
        public int InventoryQuantity { get; set; }

        public string? AuthorID { get; set; } // Khóa ngoại tham chiếu đến Author
        public Authors? Author { get; set; } // Một cuốn sách chỉ có một tác giả

        public List<OrderDetails>? OrderDetails { get; set; } // Một cuốn sách có nhiều đơn đặt hàng chi tiết
        
    }
}
