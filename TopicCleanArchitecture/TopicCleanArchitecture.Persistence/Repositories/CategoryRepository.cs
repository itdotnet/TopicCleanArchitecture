using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicCleanArchitecture.Application.Contracts.Persistence;
using TopicCleanArchitecture.Domain;
using TopicCleanArchitecture.Persistence.DatabaseContext;

namespace TopicCleanArchitecture.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TopicDatabaseContext context) : base(context)
        {
        }
        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            return !await _context.Categories.AnyAsync(q => q.Name == name);
        }
    }
}
