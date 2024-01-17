using Blazored.LocalStorage;
using TopicCleanArchitecture.BlazorUI.Contracts;
using TopicCleanArchitecture.BlazorUI.Services.Base;

namespace TopicCleanArchitecture.BlazorUI.Services
{
    public class TopicService : BaseHttpService, ITopicService
    {
        public TopicService(IClient client,ILocalStorageService storageService) : base(client, storageService)
        {
        }
    }
}
