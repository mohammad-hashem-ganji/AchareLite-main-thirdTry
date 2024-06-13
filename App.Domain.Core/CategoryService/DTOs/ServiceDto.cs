using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryService.DTOs
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SubCategoryId { get; set; }
    }
}
