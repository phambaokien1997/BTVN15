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
    public class IOrderDeTailsService : LibraryService , IOrderDetails
    {
        public async Task<string> AddOrderDetailsAsync(int id, int bookId, int orderId, int customerId, int quantity, int priceAtOrder)
        {
            // Check if the order detail ID already exists
            if (await _context.OrderDetails.AnyAsync(od => od.ID == id))
            {
                return "Order detail ID already exists!";
            }

            // Check if the book exists
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ID == bookId);
            if (book == null)
            {
                return "Book not found.";
            }

            // Check if the order exists
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.ID == orderId);
            if (order == null)
            {
                return "Order not found.";
            }

            // Check if the customer exists
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.ID == customerId);
            if (customer == null)
            {
                return "Customer not found.";
            }

            // Create a new order detail
            var orderDetail = new OrderDetails
            {
                ID = id,
                BookID = bookId,
                OrderID = orderId,
                CustomerID = customerId,
                Quantity = quantity,
                PriceAtOrder = priceAtOrder,
                Book = book,
                Order = order,
                Customer = customer
            };

            // Add the order detail to the context
            await _context.OrderDetails.AddAsync(orderDetail);

            // Save changes to the database
            await _context.SaveChangesAsync();

            return "Order detail added successfully!";
        }
        public async Task<List<OrderDetails>> GetOrderDetailsAsync(int oddid)
        {
            var orderDetails = await _context.OrderDetails.Include(o => o.Book).Include(o => o.OrderID).Include(o => o.Customer).Where(o => o.OrderID == oddid).ToListAsync();
            return orderDetails;
        }
        public async Task<string> UpdateOrderDetails(int id, OrderDetails orderDetails)
        {
            var orderdetails = await _context.OrderDetails.Include(o => o.Book).Include(o => o.Order).Include(o => o.Customer).FirstOrDefaultAsync(o => o.ID == id);
            if (orderdetails == null)
            {
                return "KHONG TIM THAY ID CUA ORDERDETAILS MA BAN MUON UPDATE";
            }
            orderdetails.OrderID = orderDetails.OrderID;
            orderdetails.CustomerID = orderDetails.CustomerID;
            orderdetails.BookID = orderDetails.BookID;
            orderdetails.Quantity = orderDetails.Quantity;
            orderdetails.PriceAtOrder= orderdetails.PriceAtOrder;

            _context.OrderDetails.Update(orderdetails);
            await _context.SaveChangesAsync(); // Lưu xong mới tham chiếu -->
            await _context.Entry(orderdetails).Reference(o => o.Book).LoadAsync();
            await _context.Entry(orderdetails).Reference(o => o.Customer).LoadAsync();
            await _context.Entry(orderdetails).Reference(o => o.Order).LoadAsync();

            return "DA CAP NHAT THANH CONG ORDERDETAILS";
        }
        public async Task<string> DeleteOrderDetails(int id)
        {
            var orderdetails = await _context.OrderDetails.FirstOrDefaultAsync(o => o.ID == id);
            if (orderdetails == null)
            {
                return "KHONG TIM THAY ORDERDETAILS CAN XOA";
            }
            _context.OrderDetails.Remove(orderdetails);
            await _context.SaveChangesAsync();
            return "DA XOA VA CAP NHAT THANH CONG ORDERDETAILS";
        }
    }
}
