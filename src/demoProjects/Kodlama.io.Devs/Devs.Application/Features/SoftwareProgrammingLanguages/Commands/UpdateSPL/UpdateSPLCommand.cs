using AutoMapper;
using Devs.Application.Features.SoftwareProgrammingLanguages.Dtos;
using Devs.Application.Features.SoftwareProgrammingLanguages.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.SoftwareProgrammingLanguages.Commands.UpdateSPL
{
	public class UpdateSPLCommand :IRequest<UpdatedSPLDto>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public class UpdateSPLCommandHandler: IRequestHandler<UpdateSPLCommand, UpdatedSPLDto>
		{
			private readonly ISoftwareProgrammingLanguageRepository _softwareProgrammingLanguageRepository;
			private readonly IMapper _mapper;
			private readonly SoftwareProgrammingLanguageBusinessRules _softwareProgrammingLanguageBusinessRules;

			public UpdateSPLCommandHandler(ISoftwareProgrammingLanguageRepository softwareProgrammingLanguageRepository, IMapper mapper, SoftwareProgrammingLanguageBusinessRules softwareProgrammingLanguageBusinessRules)
			{
				_softwareProgrammingLanguageRepository = softwareProgrammingLanguageRepository;
				_mapper = mapper;
				_softwareProgrammingLanguageBusinessRules = softwareProgrammingLanguageBusinessRules;
			}

			public async Task<UpdatedSPLDto> Handle(UpdateSPLCommand request, CancellationToken cancellationToken)
			{
				await _softwareProgrammingLanguageBusinessRules.SoftwareProgrammingLanguageNameCanNotBeSooDuplicatedWhenInserted(request.Name);
				SoftwareProgrammingLanguage mappedSPL = _mapper.Map<SoftwareProgrammingLanguage>(request.Name);
				SoftwareProgrammingLanguage updatedSPL = await _softwareProgrammingLanguageRepository.UpdateAsync(mappedSPL);
				UpdatedSPLDto updatedSPLDto = _mapper.Map<UpdatedSPLDto>(updatedSPL);
				return updatedSPLDto;


			}
		}

	}
}
