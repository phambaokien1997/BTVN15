using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuVien.Data.Models;

namespace ThuVien.Data.Interface
{
    public interface IOrder 
    {
        Task<string> AddOrderAsync(int id, DateTime orderdate, int customerid, string shippingaddress, int totalamount, List<OrderDetails> orderdetails);
    }
}
