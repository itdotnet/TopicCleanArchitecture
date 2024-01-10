using Microsoft.EntityFrameworkCore;
using Shouldly;
using TopicCleanArchitecture.Domain;
using TopicCleanArchitecture.Persistence.DatabaseContext;

namespace TopicCleanArchitecture.Persistence.IntegrationTests
{
    public class TopicDatabaseContextTests
    {
        private TopicDatabaseContext _topicDatabaseContext;

        public TopicDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<TopicDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _topicDatabaseContext = new TopicDatabaseContext(dbOptions);
        }

        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            //Arrange
            var category = new Category
            {
                Id = 1,Name="Test Cat 1"
            };

            //Act
            await _topicDatabaseContext.Categories.AddAsync(category);
            await _topicDatabaseContext.SaveChangesAsync();

            //Assert
            category.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            //Arrange
            var category = new Category
            {
                Id = 1,
                Name = "Test Cat 1"
            };

            //Act
            await _topicDatabaseContext.Categories.AddAsync(category);
            await _topicDatabaseContext.SaveChangesAsync();

            //Assert
            category.DateModified.ShouldNotBeNull();
        }
    }
}