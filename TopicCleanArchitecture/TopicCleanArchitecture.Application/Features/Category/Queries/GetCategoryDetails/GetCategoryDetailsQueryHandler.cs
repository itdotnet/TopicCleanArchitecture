using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicCleanArchitecture.Application.Contracts.Persistence;
using TopicCleanArchitecture.Application.Exceptions;
using TopicCleanArchitecture.Application.Features.Category.Queries.GetAllCategories;

namespace TopicCleanArchitecture.Application.Features.Category.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryDetailsQueryHandler(IMapper mapper,ICategoryRepository categoryRepository)
        {
            this._mapper = mapper;
            this._categoryRepository = categoryRepository;
        }

        public async Task<CategoryDetailsDto> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            // verify that record exists
            if (category == null)
                throw new NotFoundException(nameof(Category), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<CategoryDetailsDto>(category);

            // return DTO object
            return data;
        }
    }
}
