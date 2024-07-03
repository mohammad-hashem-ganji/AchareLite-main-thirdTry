using App.Domain.Core.CategoryService.Entities;
using App.Domain.Core.OrderAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Member.DTOs
{
    public class ExpertDto
    {
        public int Id { get; set; }
        public string? NCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int ApplicationUserId { get; set; }
        public List<int> ServiceIds { get; set; }
        public List<int> CommentIds { get; set; }
    }
}
