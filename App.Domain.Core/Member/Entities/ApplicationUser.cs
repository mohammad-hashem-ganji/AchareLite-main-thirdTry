using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Member.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public Customer? Customer { get; set; }
        public Expert? Expert { get; set; }
    }
}
