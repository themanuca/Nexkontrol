using Application.Interfaces;
using Contract.DTOs;
using Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<Guid> CreateCategory(CategorySummaryDto category)
        {
            if (category == null) {

                throw new Exception("Sem dados");
            }

            var categoryModel = new Domain.Models.Category
            {
                Id = Guid.NewGuid(),
                UserId = category.UserId,
                Name = category.CategoryName,
            };
            _context.Categories.Add(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel.Id;
        }

        public async Task<List<CategorySummaryDto>> GetAllCatgory()
        {
            return await _context.Categories
                .Select(x=>new CategorySummaryDto
                {
                    Id = x.Id,
                    CategoryName = x.Name,
                    UserId = x.UserId,
                })
                .ToListAsync();
        }
    }
}
