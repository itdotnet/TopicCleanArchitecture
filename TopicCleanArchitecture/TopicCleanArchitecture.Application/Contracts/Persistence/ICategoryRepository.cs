using TopicCleanArchitecture.Domain;

namespace TopicCleanArchitecture.Application.Contracts.Persistence
{
    public interface ICategoryRepository<T>:IGenericRepository<Category>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    }
}
