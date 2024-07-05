using App.Domain.Core.Member.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Member.Services
{
    public interface IExpertService
    {
        Task<ExpertDto?> GetById(int expertId, CancellationToken cancellationToken);
        Task<string?> GetExpertName(int expertId, CancellationToken cancellationToken);
    }
}
