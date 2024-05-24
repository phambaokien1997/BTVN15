using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using ThuVien.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace ThuVien.Data.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) 
        { 
        }
        public AppDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Thiết lập chuỗi kết nối đến cơ sở dữ liệu SQL Server
                //BKS - 20240209BOY (trên lap)
                //B

                string connectionString = "Server=localhost,1433;Database=KienGa;User Id=sa;Password=Strong!Passw0rd;TrustServerCertificate=True;";
                // Sử dụng SQL Server làm cơ sở dữ liệu
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
