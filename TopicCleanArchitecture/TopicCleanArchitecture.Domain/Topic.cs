using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicCleanArchitecture.Domain.Common;

namespace TopicCleanArchitecture.Domain
{
    public class Topic:BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
        public string RequestingEmployeeId { get; set; } = string.Empty;
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
