using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuVien.Data.Services;

namespace ThuVien.Data.Interface
{
    public interface ICustomer
    {
        Task<string> AddCustomerAsync(int id, string customername, string phonenumber, string gender);
    }
}
