using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicCleanArchitecture.Domain.Common;

namespace TopicCleanArchitecture.Domain
{
    public class Category:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
