using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicCleanArchitecture.Application.Contracts.Persistence;
using TopicCleanArchitecture.Domain;

namespace TopicCleanArchitecture.Application.UnitTests.Mocks
{
    public class MockCategoryRepository
    {
        public static Mock<ICategoryRepository> GetCategoryMockCategoryRepository() {
            var categories = new List<Category>
            {
                new Category { Id = 1,Name="Test Cat 1"},
                new Category { Id = 2,Name="Test Cat 2"},
                new Category { Id = 3,Name="Test Cat 3"}
            };

            var mockRepo= new Mock<ICategoryRepository>();

            mockRepo.Setup(r=>r.GetAsync()).ReturnsAsync(categories);

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<Category>()))
                .Returns((Category category) =>
                {
                    categories.Add(category);
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}
