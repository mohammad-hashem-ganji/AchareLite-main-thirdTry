using App.Domain.Core.Member.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.OrderAgg.Entities
{
    public class Bid 
    {
        public int Id { get; set; }
        public string ExprtSujestFee { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
