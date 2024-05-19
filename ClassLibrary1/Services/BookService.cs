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
    public class BookService : LibraryService , IBook
    {
        public async Task<int> Book_InsertAsync(Books books)
        {
            _context.Books.Add(books);
            return await _context.SaveChangesAsync();
        }
        public async Task<List<Books>> Get_BookAsync(string? tenSach)
        {
            //var tonTai = await _context.Books.AnyAsync(b => b.Title == tenSach);

            var bookquery = _context.Books.Where(b => b.Title == tenSach);
            bookquery = bookquery.Where(b => b.ID >= 5);
            var books = await bookquery.ToListAsync();
            return books;
        }
        public async Task<string> AddBookAsync(int id, string title, string category, int price, int inventoryquantity, string authorid)
        {
            var tonTai = await _context.Books.AnyAsync(b => b.ID == id);
            if (tonTai)
            {
                return "THEM KHONG THANH CONG VI ID CUA BAN BI TRUNG ROAI";
            }

            var book = new Books
            {
                ID = id,
                Title = title,
                Category = category,
                Price = price,
                InventoryQuantity = inventoryquantity,
                AuthorID = authorid
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return "THEM THANH CONG SACH";
        }
        public async Task<string> UpdateBook(int id, string title , string category, int price, int inventoryquantity, string authorid)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ID == id);
            if (book == null)
            {
                return "KHONG TIM RA ID CUON SACH BAN MUON UPDATE";
            }
            book.Title = title;
            book.Category = category;
            book.Price = price;
            book.InventoryQuantity = inventoryquantity;
            book.AuthorID = authorid;
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return $"BAN DA UPDATE THANH CONG CUON SACH CO ID {id}";
        }
        public async Task<string> DeleteBook(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ID == id);
            if(book == null)
            {
                return "KHONG TIM RA ID CUON SACH BAN MUON XOA";
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return $"BAN DA XOA THANH CONG CUON SACH CO ID {id}";
        }
		public async Task<List<Books>> GetAllBookAsync()
		{
			//var tonTai = await _context.Books.AnyAsync(b => b.Title == tenSach);

			var bookquery = _context.Books;
			var books = await bookquery.ToListAsync();
			return books;
		}
	}
}
