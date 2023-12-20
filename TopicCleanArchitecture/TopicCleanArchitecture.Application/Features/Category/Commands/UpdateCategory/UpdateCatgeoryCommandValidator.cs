using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicCleanArchitecture.Application.Contracts.Persistence;

namespace TopicCleanArchitecture.Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCatgeoryCommandValidator:AbstractValidator<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCatgeoryCommandValidator(ICategoryRepository categoryRepository)
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(q => q)
                .MustAsync(CategoryNameUnique)
                .WithMessage("Category already exists");


            this._categoryRepository = categoryRepository;
        }

        private Task<bool> CategoryNameUnique(UpdateCategoryCommand command, CancellationToken token)
        {
            return _categoryRepository.IsLeaveTypeUnique(command.Name);
        }
    }
}
