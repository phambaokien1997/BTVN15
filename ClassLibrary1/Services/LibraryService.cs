using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using ThuVien.Data.Interface;
using ThuVien.Data.Models;

namespace ThuVien.Data.Services
{
    
    public class LibraryService 
    {
        protected readonly AppDbContext _context;
        //public LibraryService()
        //{
        //    _context = new AppDbContext();
        //}
        public LibraryService() //public
        {
            _context = new AppDbContext();
        }


       
        

        
        
        //public int ID { get; set; } // ID đơn đặt hàng làm khóa chính
        //public DateTime OrderDate { get; set; }
        //public int CustomerID { get; set; } // Khóa ngoại tham chiếu đến Customer
        //public string ShippingAddress { get; set; }
        //public int TotalAmount { get; set; }

        //public Customers Customer { get; set; } // Một đơn đặt hàng chỉ thuộc về một khách hàng

        //public List<OrderDetails> OrderDetails { get; set; } // Một đơn đặt hàng có nhiều đơn đặt hàng chi tiết
        
        


    }
    public class AuthorMini
    {
        public string Ten { get; set; }
        public string QueQuan { get; set; }
    }
}

