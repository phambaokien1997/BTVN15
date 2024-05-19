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
    public class IOrderService : LibraryService , IOrder
    {
        public async Task<string> AddOrderAsync(int id, DateTime orderdate, int customerid, string shippingaddress, int totalamount, List<OrderDetails> orderdetails)
        {
            // Check if the customer exists
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.ID == customerid);
            if (customer == null)
            {
                return "Customer not found.";
            }

            // Check if the order ID already exists
            if (await _context.Orders.AnyAsync(o => o.ID == id))
            {
                return "Order ID already exists!";
            }

            // Create a new order
            var order = new Orders
            {
                ID = id,
                OrderDate = orderdate,
                CustomerID = customerid,
                ShippingAddress = shippingaddress,
                TotalAmount = totalamount,
                Customer = customer
            };

            // Add the order to the context
            await _context.Orders.AddAsync(order);

            // Add order details if any
            if (orderdetails != null && orderdetails.Any())
            {
                foreach (var detail in orderdetails)
                {
                    detail.OrderID = id; // Assume OrderDetails has a property OrderID
                    await _context.OrderDetails.AddAsync(detail);
                }
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            return "Order added successfully!";
        }
        public async Task<List<Orders>> GetOrdersAsync(int id)
        {
            var order = await _context.Orders.Include(o => o.Customer).Include(o => o.OrderDetails).Where(o => o.ID == id).ToListAsync();
            return order; 
        }
        public async Task<string> UpdateOrderAsync(int id, Orders updateorder)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.ID == id);
            if(order == null)
            {
                return "KHONG TIM THAY ORDER MA BAN MUON UPDATE";
            }

            order.CustomerID = updateorder.CustomerID;
            order.OrderDate = updateorder.OrderDate;
            order.ShippingAddress = updateorder.ShippingAddress;
            order.TotalAmount = updateorder.TotalAmount;
            if(updateorder.OrderDetails == null)
            {
                _context.OrderDetails.RemoveRange(order.OrderDetails);
                order.OrderDetails = updateorder.OrderDetails;
            }
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return "DA CAP NHAT THANH CONG ORDER";
        }
        public async Task<string> DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.ID == id);
            if (order == null)
            {
                return "KHONG TIM THAY ORDER MA BAN MUON DELETE";
            }
            if(order.OrderDetails != null)
            {
                _context.OrderDetails.RemoveRange(order.OrderDetails);
            }    
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return "DA XOA THANH CONG ORDER";
        }
    }
}
