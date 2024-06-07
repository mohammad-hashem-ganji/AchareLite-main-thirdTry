using App.Domain.Core.CategoryService.Entities;
using App.Domain.Core.OrderAgg.Entities;

namespace App.Domain.Core.Member.Entities
{
    public class Expert : User
    {
        public List<Service> Services { get; set; }
        public List<Comment>  Comments { get; set; }
    }
}
