using LibraryWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ThuVien.Data.Models;

namespace LibraryWEB.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{


			return View();
		}
		//public IActionResult ListBook()
		//{
		//	using (var dbContext = new AppDbContext(/*inject options here*/))
		//	{
		//		// Th?c hi?n truy v?n ?? l?y d? li?u sách t? c? s? d? li?u
		//		var booksFromDatabase = dbContext.Books; // ?ây ch? là m?t ví d?, b?n c?n thay th? nó b?ng truy v?n th?c s? c?a b?n

		//		// Chuy?n ??i d? li?u t? c? s? d? li?u thành các ??i t??ng mô hình và ti?p t?c x? lý nh? tr??c


		//		var listBook = new ListBookModel
		//		{
		//			Books = new List<BookModel>()
		//		};

		//		listBook.Books.Add(booksFromDatabase);
		//		//listBook.Director = "Ho Beo";
		//		listBook.BookStoreOwner = "Bao Kien";
		//		listBook.

		//			}
		//	return View(listBook);
		//}
		//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			var erro = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
			return View(erro);
		}
	}
}
