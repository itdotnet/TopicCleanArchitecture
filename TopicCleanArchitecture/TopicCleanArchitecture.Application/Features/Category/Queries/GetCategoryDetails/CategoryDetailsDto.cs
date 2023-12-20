using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopicCleanArchitecture.Application.Features.Category.Queries.GetCategoryDetails
{
    public class CategoryDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
