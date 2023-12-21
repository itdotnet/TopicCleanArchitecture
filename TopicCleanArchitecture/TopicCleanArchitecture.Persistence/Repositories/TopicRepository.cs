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
    public class TopicRepository:GenericRepository<Topic>,ITopicRepository
    {
        public TopicRepository(TopicDatabaseContext context) : base(context)
        {
        }

        public async Task AddTopics(List<Topic> topics)
        {
            await _context.AddRangeAsync(topics);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Topic>> GetTopicsWithDetails()
        {
            var topics = await _context.Topics
               .Include(q => q.Category)
               .ToListAsync();
            return topics;
        }

        public async Task<List<Topic>> GetTopicsWithDetails(string userId)
        {
            var topics = await _context.Topics.Where(x=>x.RequestingEmployeeId==userId)
               .Include(q => q.Category)
               .ToListAsync();
            return topics;
        }

        public async Task<Topic> GetTopicWithDetails(int id)
        {
            var topic = await _context.Topics
                .Include(q => q.Category)
                .FirstOrDefaultAsync(q => q.Id == id);

            return topic!;
        }

        public async Task<Topic> GetUserTopics(string userId)
        {
            var topic= await _context.Topics.FirstOrDefaultAsync(q => q.RequestingEmployeeId == userId);
            return topic!;
        }

        public async Task<bool> TopicExists(string userId)
        {
            return await _context.Topics.AnyAsync(q => q.RequestingEmployeeId == userId);
        }
    }
}
