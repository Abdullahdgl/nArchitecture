using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Technologies.Rules
{
	public class TechnologyBusinessRules
	{
		private readonly ITechnologyRepository _TechnologyRepository;
		public TechnologyBusinessRules(ITechnologyRepository TechnologyRepository)
		{
			_TechnologyRepository = TechnologyRepository;
		}
		public async Task TechnologyNameCanNotBeDuplicatedWhenInserted(string name)
		{
			IPaginate<Technology> result = await _TechnologyRepository.GetListAsync(b => b.Name == name);
			if (result.Items.Any()) throw new BusinessException("Technology name exists.");
		}
		public async Task TechnologyShouldExistWhenRequested(Technology Technology)
		{
			if (Technology == null) throw new BusinessException("Requested Technology does not exist.");
		}

	}
}
