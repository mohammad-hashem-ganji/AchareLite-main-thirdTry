using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.OrderAgg.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }
        public bool IsAccept { get; set; }
        public int ExpertId { get; set; }
        public string ExpertName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
