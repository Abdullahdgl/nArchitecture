using AutoMapper;
using Devs.Application.Features.SoftwareProgrammingLanguages.Dtos;
using Devs.Application.Features.SoftwareProgrammingLanguages.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.SoftwareProgrammingLanguages.Queries.GetByIdSPL
{
	public class GetByIdSLPOuery : IRequest<SPLGetByIdDto>
	{
		public int Id { get; set; }
		public class GetByIdSPLQueryHandler : IRequestHandler<GetByIdSLPOuery, SPLGetByIdDto>
		{
			private readonly ISoftwareProgrammingLanguageRepository _softwareProgrammingLanguageRepository;
			private readonly IMapper _mapper;
			private readonly SoftwareProgrammingLanguageBusinessRules _softwareProgrammingLanguageBusinessRules;

			public GetByIdSPLQueryHandler(ISoftwareProgrammingLanguageRepository softwareProgrammingLanguageRepository, IMapper mapper, SoftwareProgrammingLanguageBusinessRules softwareProgrammingLanguageBusinessRules)
			{
				_softwareProgrammingLanguageRepository = softwareProgrammingLanguageRepository;
				_mapper = mapper;
				_softwareProgrammingLanguageBusinessRules = softwareProgrammingLanguageBusinessRules;
			}

			public async Task<SPLGetByIdDto> Handle(GetByIdSLPOuery request, CancellationToken cancellationToken)
			{
				SoftwareProgrammingLanguage? softwareProgrammingLanguage = await _softwareProgrammingLanguageRepository.GetAsync(b => b.Id == request.Id);
				_softwareProgrammingLanguageBusinessRules.SoftwareProgrammingLanguageShouldExistWhenRequested(softwareProgrammingLanguage);
				SPLGetByIdDto sPLGetByIdDto = _mapper.Map<SPLGetByIdDto>(softwareProgrammingLanguage);	
				return sPLGetByIdDto;

			}
		}
	}
}
