using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuVien.Data.Models;

namespace ThuVien.Data.Interface
{
    public interface IAuthor 
    {
        Task<string> AddAuthorAsync(string id, string aname, string country);
        Task<List<Authors>> GetAuthorsAsync(string name, string? country);
    }
}
