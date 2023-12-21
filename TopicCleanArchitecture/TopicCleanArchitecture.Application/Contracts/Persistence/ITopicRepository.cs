using TopicCleanArchitecture.Domain;

namespace TopicCleanArchitecture.Application.Contracts.Persistence
{
    public interface ITopicRepository:IGenericRepository<Topic>
    {
        Task<Topic> GetTopicWithDetails(int id);
        Task<List<Topic>> GetTopicsWithDetails();
        Task<List<Topic>> GetTopicsWithDetails(string userId);
        Task<bool> TopicExists(string userId);
        Task AddTopics(List<Topic> topics);
        Task<Topic> GetUserTopics(string userId);
    }
}
