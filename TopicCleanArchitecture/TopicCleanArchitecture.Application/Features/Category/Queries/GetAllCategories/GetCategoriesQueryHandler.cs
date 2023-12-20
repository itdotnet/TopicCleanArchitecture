﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicCleanArchitecture.Application.Contracts.Persistence;

namespace TopicCleanArchitecture.Application.Features.Category.Queries.GetAllCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            this._mapper = mapper;
            this._categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var categories = await _categoryRepository.GetAsync();

            // convert data objects to DTO objects
            var data = _mapper.Map<List<CategoryDto>>(categories);

            // return list of DTO object
            return data;
        }
    }
}
