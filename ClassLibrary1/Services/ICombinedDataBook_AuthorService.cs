using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuVien.Data.Interface;
using ThuVien.Data.Models;

namespace ThuVien.Data.Services
{
    public class ICombinedDataBook_AuthorService : LibraryService
    {
        public List<CombinedDataBook_Author> GetCombinedDataBook_Authors()
        {
            var combinedData = (from author in _context.Authors
                                join book in _context.Books on author.ID equals book.AuthorID
                                select new CombinedDataBook_Author
                                {
                                    AuthorName = author.AName,
                                    BookTitle = book.Title,
                                    Category = book.Category
                                }).ToList();
            return combinedData;
        }
       
    }
}
