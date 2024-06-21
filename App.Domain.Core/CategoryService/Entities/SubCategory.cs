using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryService.Entities
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MainCategoryId { get; set; }
        public MainCategory MainCategory { get; set; }
        public ICollection<Service>? Services { get; set; }
    }
}
