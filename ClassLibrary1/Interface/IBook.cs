using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuVien.Data.Models;
using ThuVien.Data.Services;

namespace ThuVien.Data.Interface
{
    public interface IBook 
    {
        Task<string> AddBookAsync(int id, string title, string category, int price, int inventoryquantity, string authorid);
        Task<List<Books>> Get_BookAsync(string? tenSach);
        Task<int> Book_InsertAsync(Books books);
        Task<List<Books>> GetAllBookAsync();

	}
}
