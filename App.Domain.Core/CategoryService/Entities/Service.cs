using App.Domain.Core.Member.Entities;

namespace App.Domain.Core.CategoryService.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<Expert>? Experts { get; set; }
    }
}
