﻿using LibraryWEB.Models;
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
        public async Task<IActionResult> GetAuthor()
        {
            var authors = await _authorService.GetAuthorsAsync();

            var viewModel = new ListAuthorModel();
            //viewModel.Authors = authors
            //    .Select(x => new AuthorModel
            //    {
            //        Name = x.AName,
            //        Country = x.Country,
            //        Id = x.ID
            //    }).ToList();

            viewModel.Authors = new List<AuthorModel>();
            foreach (var x in authors)
            {
                viewModel.Authors.Add(new AuthorModel
                {
                    Name = x.AName,
                    Country = x.Country,
                    Id = x.ID
                });
            }

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
            var authors = await _authorService.AddAuthorAsync("", "", "");
            //var authorService = new AuthorService();
            //var authors = await authorService.GetAuthorsAsync(null, null);

            //var viewModel = new ListAuthorModel();
            //viewModel.Authors = authors.Select(x => new AuthorModel
            //{
            //    Name = x.AName,
            //    Country = x.Country,
            //    Id = x.ID
            //}).ToList();

            return View();
        }
    }
}