using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicCleanArchitecture.Application.Contracts.Logging;
using TopicCleanArchitecture.Application.Contracts.Persistence;
using TopicCleanArchitecture.Application.Features.Category.Queries.GetAllCategories;
using TopicCleanArchitecture.Application.MappingProfiles;
using TopicCleanArchitecture.Application.UnitTests.Mocks;

namespace TopicCleanArchitecture.Application.UnitTests.Features.Categories.Queries
{
    public class GetCategoryListQueryHandlerTests
    {
        private readonly Mock<ICategoryRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetCategoriesQueryHandler>> _mockAppLogger;

        public GetCategoryListQueryHandlerTests()
        {
            _mockRepo = MockCategoryRepository.GetCategoryMockCategoryRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CategoryProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetCategoriesQueryHandler>>();
        }

        [Fact]
        public async Task GetCategoryListTest()
        {
            var handler = new GetCategoriesQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            var result = await handler.Handle(new GetCategoriesQuery(),CancellationToken.None);

            result.ShouldBeOfType<List<CategoryDto>>();
            result.Count.ShouldBe(3);
            if (result.Count > 0)
                result.Where(x => x.Id == 2).Single().Name = "test";
            result.FirstOrDefault(x=>x.Id==2).ShouldBeEquivalentTo(nameof(CategoryDto.Name),"test");
            //result.Skip(0).Take(1).FirstOrDefault(x=>x.Id==1).ShouldNotBeNull();
        }
    }
}
