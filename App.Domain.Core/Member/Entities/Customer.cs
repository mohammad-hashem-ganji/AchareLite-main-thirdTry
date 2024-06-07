using App.Domain.Core.OrderAgg.Entities;

namespace App.Domain.Core.Member.Entities
{
    public class Customer : User
    {
        public List<Order> Orders { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
