using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicCleanArchitecture.Application.Contracts.Persistence;
using TopicCleanArchitecture.Application.Exceptions;

namespace TopicCleanArchitecture.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var categoryToDelete = await _categoryRepository.GetByIdAsync(request.Id);

            // verify that record exists
            if (categoryToDelete == null)
                throw new NotFoundException(nameof(Category), request.Id);

            // remove from database
            await _categoryRepository.DeleteAsync(categoryToDelete);

            // retun record id
            return Unit.Value;
        }
    }
}
