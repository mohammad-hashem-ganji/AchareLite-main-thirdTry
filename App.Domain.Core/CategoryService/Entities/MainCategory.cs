using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryService.Entities
{
    public class MainCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
