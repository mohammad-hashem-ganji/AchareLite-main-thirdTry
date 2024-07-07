using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.OrderAgg.DTOs
{
    public class BidDto
    {
        public int Id { get; set; }
        public string ExprtSujestFee { get; set; }
        public int OrderId { get; set; }
        public int ExpertId { get; set; }
        public int StatusId { get; set; }
    }
}
