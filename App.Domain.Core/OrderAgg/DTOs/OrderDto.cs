using App.Domain.Core.OrderAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.OrderAgg.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string ServiceName { get; set; }
        public int ServiseId { get; set; }
        public int StatusId { get; set; }
        public int CustomerId { get; set; }
        public List<int>? BidsId { get; set; }
        public string CustomerName { get; set; }
    }
}
