using MyApp.DataAccessLayer.Infrastructure.IRepository;
using NTier_Architecture.Data;
using NTier_Architecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class CategoryRepository : Repository<CategoryModel>, ICategoryRepository
    {
        public ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context) { 
        
            _context = context;

        
        }
        public void Update(CategoryModel category)
        {
            _context.Category.Update(category);
            
        }
    }
}
