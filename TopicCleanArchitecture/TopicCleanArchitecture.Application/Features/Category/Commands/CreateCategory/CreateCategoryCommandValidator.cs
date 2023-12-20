using TopicCleanArchitecture.Application.Contracts.Persistence;
using FluentValidation;

namespace TopicCleanArchitecture.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(q => q)
                .MustAsync(CategoryNameUnique)
                .WithMessage("Leave type already exists");


            this._categoryRepository = categoryRepository;
        }

        private Task<bool> CategoryNameUnique(CreateCategoryCommand command, CancellationToken token)
        {
            return _categoryRepository.IsLeaveTypeUnique(command.Name);
        }
    }
}