using App.Domain.Core.CategoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryService.DTOs
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MainCategoryId { get; set; }
        public MainCategory MainCategory { get; set; }
    }
}
