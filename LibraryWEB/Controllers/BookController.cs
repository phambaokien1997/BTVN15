using Microsoft.AspNetCore.Mvc;
using ThuVien.Data.Interface;
using ThuVien.Data.Models;

namespace LibraryWEB.Controllers
{
	public class BookController : Controller
	{
		private readonly IBook _book;
		public BookController(IBook book)
		{
			_book = book;
		}
		public async Task<IActionResult> HienThiDanhSachAsync()
		{
			var books = await _book.GetAllBookAsync();
			return View(books);
		}
		public async Task<IActionResult> ThemSachAsync()
		{
			// Logic để thêm sách mới vào cơ sở dữ liệu
			var books = await _book.AddBookAsync(250, "Yeu em tu cai nhin dau tien", "ngon tinh", 200, 3, "To Dong Ho");
			return View(books);
		}
	}
}
