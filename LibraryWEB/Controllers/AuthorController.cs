using LibraryWEB.Models;
using Microsoft.AspNetCore.Mvc;
using ThuVien.Data.Services;

namespace LibraryWEB.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorService _authorService;
        public AuthorController()
        {
            _authorService = new AuthorService();
        }
        [HttpGet]
        public async Task<IActionResult> GetAuthor(string name, string country)
        {
            var input = new ThuVien.Data.Dto.GetAuthorInput
            {

            };
            var authors = await _authorService.GetAuthorsAsync(input);

            var viewModel = new ListAuthorModel();
            viewModel.Authors = authors
                .Select(x => new AuthorModel
                {
                    Name = x.AName,
                    Country = x.Country,
                    Id = x.ID
                }).ToList();

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PostAddAuthor(AddAuthorModel addAuthorModel)
        {
            try
            {
                var id = Guid.NewGuid().ToString().Substring(0, 10);
                var message = await _authorService.AddAuthorAsync(id.ToString(), addAuthorModel.Ten, addAuthorModel.QueQuan);
                addAuthorModel.ThongBao = message;
                return View("AddAuthor", addAuthorModel);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
