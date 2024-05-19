using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuVien.Data.Interface
{
    public interface IOrderDetails 
    {
        Task<string> AddOrderDetailsAsync(int id, int bookId, int orderId, int customerId, int quantity, int priceAtOrder);
    }
}
