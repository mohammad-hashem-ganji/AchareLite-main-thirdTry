        using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Member.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string? NCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Mobile { get; set; }
        public IFormFile Image { get; set; }  
        public byte[] ImageData { get; set; }
        public int ApplicationUserId { get; set; }
        public List<int> OrderIds { get; set; }
    }
}
