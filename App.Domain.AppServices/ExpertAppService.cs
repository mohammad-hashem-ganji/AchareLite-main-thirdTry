using App.Domain.Core.Member.AppServices;
using App.Domain.Core.Member.DTOs;
using App.Domain.Core.Member.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices
{
    public class ExpertAppService : IExpertAppService
    {
        private readonly IExpertService _expertService;

        public ExpertAppService(IExpertService expertService)
        {
            _expertService = expertService;
        }
        public async Task<ExpertDto?> GetById(int expertId, CancellationToken cancellationToken) => await _expertService.GetById(expertId, cancellationToken);

        public async Task<string?> GetExpertName(int expertId, CancellationToken cancellationToken) => await _expertService.GetExpertName(expertId, cancellationToken);

        public async Task<bool> Update(ExpertDto model, CancellationToken cancellationToken)
        {
            return await _expertService.Update(model, cancellationToken);
        }
    }
}
