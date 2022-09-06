
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Devs.Application.Features.SoftwareProgrammingLanguages.Constants.Messages;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.SoftwareProgrammingLanguages.Rules
{
	public class SoftwareProgrammingLanguageBusinessRules
	{

		private readonly ISoftwareProgrammingLanguageRepository _softwareProgrammingLanguageRepository;

		public SoftwareProgrammingLanguageBusinessRules(ISoftwareProgrammingLanguageRepository softwareProgrammingLanguageRepository)
		{
			_softwareProgrammingLanguageRepository = softwareProgrammingLanguageRepository;
		}

		public async Task SoftwareProgrammingLanguageNameCanNotBeSooDuplicatedWhenInserted(string name)
		{
			IPaginate<SoftwareProgrammingLanguage> result = await _softwareProgrammingLanguageRepository.GetListAsync(prg => prg.Name == name);
			if (result.Items.Any()) throw new BusinessException(SPLMessages.ProgramingNamescannotberepeated);
		}



		public async Task SoftwareProgrammingLanguageShouldExistWhenRequested(SoftwareProgrammingLanguage softwareProgrammingLanguage)
		{
			if (softwareProgrammingLanguage == null) throw new BusinessException(SPLMessages.Programminglanguagecannotbeblank);
		}
	}
}
