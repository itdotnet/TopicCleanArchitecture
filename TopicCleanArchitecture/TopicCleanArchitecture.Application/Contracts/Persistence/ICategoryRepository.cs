using TopicCleanArchitecture.Domain;

namespace TopicCleanArchitecture.Application.Contracts.Persistence
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    }
}
