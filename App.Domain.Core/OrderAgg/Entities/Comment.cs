using App.Domain.Core.Member.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.OrderAgg.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }

        public Expert Expert { get; set; }
        public int ExpertId { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
