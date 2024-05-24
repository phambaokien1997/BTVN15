using Microsoft.Identity.Client;
using System;
using System.Text;
using ThuVien.Data.Interface;
using ThuVien.Data.Models;
using ThuVien.Data.Services;

namespace MyLibraryApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //Console.WriteLine("Mời bạn nhập ID:");
            //var id = Console.ReadLine();

            //Console.WriteLine("Mời bạn nhập tên:");
            //var aName = Console.ReadLine();

            //Console.WriteLine("Mời bạn nhập quê quán:");
            //var country = Console.ReadLine();

            //// Khởi tạo một đối tượng LibraryService
            IAuthorService asd = new AuthorService();

            //// Gọi phương thức AddAuthor để thêm tác giả vào cơ sở dữ liệu
            //var result = libraryService.AddAuthorAsync(id, aName, country);
            //Console.WriteLine(result);

            //Console.WriteLine();

            //Console.WriteLine("Chương trình hiển thị danh sách các sách:");

            //// Khởi tạo một đối tượng LibraryService


            await Console.Out.WriteLineAsync("Mời bạn nhập tên tác giả: ");
            string? tenTacGia = Console.ReadLine();
            await Console.Out.WriteLineAsync("Mời bạn nhập quê quán: ");
            string? queQuan = Console.ReadLine();
            //var layTacGia = asd.GetAuthorsAsync(tenTacGia, queQuan);
            //var authors = await layTacGia;
            //var count = authors.Count();
            //if(count == 0)
            //{
            //    await Console.Out.WriteLineAsync("Đéo có thằng tác giả nào ở đây cả!!");
            //}    
            //foreach (var tacgia in authors)
            //{
            //    Console.WriteLine(tacgia);
            //}

            //IBook bookService = new BookService();
            //bookService.Get_BookAsync("Lam di");
            
            
            
            
            Console.ReadKey();
        }
    }
}