using System.ComponentModel.DataAnnotations;

namespace TopicCleanArchitecture.BlazorUI.Models.Categories
{
    public class CategoryVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
