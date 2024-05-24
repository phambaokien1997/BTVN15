﻿using Microsoft.EntityFrameworkCore;
using ThuVien.Data.Dto;
using ThuVien.Data.Interface;
using ThuVien.Data.Models;

namespace ThuVien.Data.Services
{
    public class AuthorService : LibraryService , IAuthorService
    {
        public async Task<List<Authors>> GetAuthorsAsync(GetAuthorInput input)
        {
            var authorsQuery = _context.Authors.AsQueryable(); 
            if (!string.IsNullOrWhiteSpace(input.Name))
            {
                authorsQuery = authorsQuery.Where(a => a.AName == input.Name);
            }
            if (!string.IsNullOrWhiteSpace(input.Country))
            {
                authorsQuery = authorsQuery.Where(a => a.Country == input.Country);
            }
            var authors = await authorsQuery
            //.Select(x => new AuthorMini
            //{
            //    Ten = x.AName,
            //    QueQuan = x.Country
            //})
                .ToListAsync();

            //_context.Authors.Remove(author);
            _context.SaveChanges();

            return authors;
        }
        public async Task<string> AddAuthorAsync(string id, string aname, string country)
        {
            if (await _context.Authors.AnyAsync(a => a.ID == id))
            {
                return "BI TRUNG ROAI!";
            }

            var author = new Authors
            {
                ID = id,
                AName = aname,
                Country = country
            };

            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            UpdateAuthorAsync("124", "asd", "asd");
            DeleteAuthorAsync("id");
            return "THEM THANH CONG TAC GIA ROI";
            
        }
        
        public async Task<string> UpdateAuthorAsync(string id, string name, string country)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.ID == id);
            if(author == null)
            {
                return "Khong the tim thay ID can Update";
            }
            author.AName = name;
            author.Country = country;
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
            return $"Ban da cap nhat thanh cong tac gia co ID {id}";


        }
        public async Task<string> DeleteAuthorAsync(string id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.ID == id);
            if (author == null)
            {
                return "Khong the tim thay ID can Delete";

            }
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return $"Ban da xoa thanh cong tac gia co ID {id}";
        }
    }
}