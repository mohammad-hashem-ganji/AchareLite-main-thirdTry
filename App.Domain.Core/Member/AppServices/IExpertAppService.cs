using App.Domain.Core.Member.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Member.AppServices
{
    public interface IExpertAppService
    {
        Task<ExpertDto?> GetById(int expertId, CancellationToken cancellationToken);
    }
}
