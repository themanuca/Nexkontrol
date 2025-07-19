using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid? ParentCategoryId { get; set; } // Para subcategorias
        public Category? ParentCategory { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public List<Category> Subcategories { get; set; }
    }

}
