using App.Domain.Core.Member.Data.Repositories;
using App.Domain.Core.Member.DTOs;
using App.Domain.Core.Member.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class ExpertService : IExpertService
    {
        private readonly IExpertRepository _expertRepository;
public ExpertService(IExpertRepository expertRepository)
        {
            _expertRepository = expertRepository;
        }

        public async Task<ExpertDto?> GetById(int expertId, CancellationToken cancellationToken) => await _expertRepository.GetById(expertId, cancellationToken);

    }
}
