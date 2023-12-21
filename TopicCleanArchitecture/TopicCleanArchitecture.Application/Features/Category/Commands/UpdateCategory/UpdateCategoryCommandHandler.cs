using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicCleanArchitecture.Application.Contracts.Logging;
using TopicCleanArchitecture.Application.Contracts.Persistence;
using TopicCleanArchitecture.Application.Exceptions;

namespace TopicCleanArchitecture.Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAppLogger<UpdateCategoryCommandHandler> _logger;

        public UpdateCategoryCommandHandler(IMapper mapper,ICategoryRepository categoryRepository,IAppLogger<UpdateCategoryCommandHandler> logger)
        {
            this._mapper = mapper;
            this._categoryRepository = categoryRepository;
            this._logger = logger;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new UpdateCatgeoryCommandValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}",nameof(Category),request.Id);
                throw new BadRequestException("Invalid Category", validationResult);
            }

            // convert to domain entity object
            var categoryToUpdate = _mapper.Map<Domain.Category>(request);

            // add to database
            await _categoryRepository.UpdateAsync(categoryToUpdate);

            // return Unit value
            return Unit.Value;
        }
    }
}
