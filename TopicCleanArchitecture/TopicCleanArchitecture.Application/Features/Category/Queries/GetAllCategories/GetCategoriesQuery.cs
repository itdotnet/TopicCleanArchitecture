using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopicCleanArchitecture.Application.Features.Category.Queries.GetAllCategories
{
    public record GetCategoriesQuery : IRequest<List<CategoryDto>>;
}
