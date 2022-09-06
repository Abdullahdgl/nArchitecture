using AutoMapper;
using Devs.Application.Features.SoftwareProgrammingLanguages.Dtos;
using Devs.Application.Features.SoftwareProgrammingLanguages.Rules;
using Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devs.Domain.Entities;

namespace Devs.Application.Features.SoftwareProgrammingLanguages.Commands.CreateSPL
{
	public class CreateSPLCommand : IRequest<CreatedSPLDto>
	{
		public string Name { get; set; }

		public class CreateSPLCommandHandler : IRequestHandler<CreateSPLCommand, CreatedSPLDto>
			{
			private readonly ISoftwareProgrammingLanguageRepository _softwareProgrammingLanguageRepository;
			private readonly IMapper _mapper;
			private readonly SoftwareProgrammingLanguageBusinessRules _softwareProgrammingLanguageBusinessRules;

			public CreateSPLCommandHandler(ISoftwareProgrammingLanguageRepository softwareProgrammingLanguageRepository, IMapper mapper, SoftwareProgrammingLanguageBusinessRules softwareProgrammingLanguageBusinessRules)
			{
				_softwareProgrammingLanguageRepository = softwareProgrammingLanguageRepository;
				_mapper = mapper;
				_softwareProgrammingLanguageBusinessRules = softwareProgrammingLanguageBusinessRules;
			}
			public async Task<CreatedSPLDto> Handle(CreateSPLCommand request, CancellationToken cancellationToken)
			{
				await _softwareProgrammingLanguageBusinessRules.SoftwareProgrammingLanguageNameCanNotBeSooDuplicatedWhenInserted(request.Name);
				SoftwareProgrammingLanguage mappedSPL =_mapper.Map<SoftwareProgrammingLanguage>(request);	
				SoftwareProgrammingLanguage createdSPL = await _softwareProgrammingLanguageRepository.AddAsync(mappedSPL);
				CreatedSPLDto createdSPLDto = _mapper.Map<CreatedSPLDto>(createdSPL);
				return createdSPLDto;

			}
		}	
	}
}
