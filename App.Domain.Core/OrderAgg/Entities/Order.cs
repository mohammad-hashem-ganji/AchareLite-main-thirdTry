using App.Domain.Core.CategoryService.Entities;
using App.Domain.Core.Member.Entities;

namespace App.Domain.Core.OrderAgg.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ServiseId { get; set; }
        public Service Service { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public ICollection<Bid>? Bids { get; set; }
    }
}