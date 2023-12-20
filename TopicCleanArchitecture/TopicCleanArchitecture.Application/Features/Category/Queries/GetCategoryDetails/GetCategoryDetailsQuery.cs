using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicCleanArchitecture.Application.Features.Category.Queries.GetAllCategories;

namespace TopicCleanArchitecture.Application.Features.Category.Queries.GetCategoryDetails
{
    public record GetCategoryDetailsQuery(int Id):IRequest<CategoryDetailsDto>;
}
