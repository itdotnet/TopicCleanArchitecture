using AutoMapper;
using MediatR;
using TopicCleanArchitecture.Application.Contracts.Persistence;
using TopicCleanArchitecture.Application.Exceptions;

namespace TopicCleanArchitecture.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(IMapper mapper,ICategoryRepository categoryRepository)
        {
            this._mapper = mapper;
            this._categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateCategoryCommandValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Category", validationResult);

            // convert to domain entity object
            var categoryToCreate = _mapper.Map<Domain.Category>(request);

            // add to database
            await _categoryRepository.CreateAsync(categoryToCreate);

            // retun record id
            return categoryToCreate.Id;
        }
    }
}
