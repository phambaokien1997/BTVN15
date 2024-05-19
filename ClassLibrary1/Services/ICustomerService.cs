using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuVien.Data.Interface;
using ThuVien.Data.Models;

namespace ThuVien.Data.Services
{
    public class ICustomerService : LibraryService , ICustomer
    {
        public async Task<string> AddCustomerAsync(int id, string customername, string phonenumber, string gender)
        {
            if (await _context.Customers.AnyAsync(c => c.ID == id))
            {
                return "Customer ID already exists!";
            }

            var customer = new Customers
            {
                ID = id,
                CustomerName = customername,
                PhoneNumber = phonenumber,
                Gender = gender
            };

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return "DA THEM THANH CONG KHACHHANG";
        }
        public async Task<List<Customers>> GetCustomersAsync(string customername)
        {
            //var isExistCustomerName = await _context.Customers.AnyAsync(c => c.CustomerName == customername);
            //if (!isExistCustomerName) 
            //{
            //    return null;
            //}
            var customerQuery = await _context.Customers.Where(c => c.CustomerName == customername).ToListAsync();
            return customerQuery;
        }
        public async Task<string> UpdateCustomerAsync(int id, string ten, string sdt, string gioitinh)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.ID == id);
            if (customer == null)
            {
                return "KHONG TIM THAY KHACH HANG BAN MUON UPDATE";
            }
            customer.PhoneNumber = sdt;
            customer.Gender = gioitinh;
            customer.CustomerName = ten;
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return $"BAN DA UPDATE THANH CONG KHACH HANG CO ID {id}";
        }
        public async Task<string> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.ID == id);
            if (customer == null)
            {
                return "KHONG TIM THAY KHACH HANG BAN MUON DELETE";
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return $"BAN DA XOA THANH CONG KHACH HANG CO ID {id}";
        }
    }
}
