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

namespace Devs.Application.Features.SoftwareProgrammingLanguages.Commands.DeleteSPL
{
	public class DeleteSPLCommand :IRequest<DeletedSPLDto>
	{
		public int Id { get; set; }
		public class DeleteSPLHandler:IRequestHandler<DeleteSPLCommand, DeletedSPLDto>
		{
			private readonly ISoftwareProgrammingLanguageRepository _softwareProgrammingLanguageRepository;
			private readonly IMapper _mapper;
			private readonly SoftwareProgrammingLanguageBusinessRules _softwareProgrammingLanguageBusinessRules;

			public DeleteSPLHandler(ISoftwareProgrammingLanguageRepository softwareProgrammingLanguageRepository, IMapper mapper, SoftwareProgrammingLanguageBusinessRules softwareProgrammingLanguageBusinessRules)
			{
				_softwareProgrammingLanguageRepository = softwareProgrammingLanguageRepository;
				_mapper = mapper;
				_softwareProgrammingLanguageBusinessRules = softwareProgrammingLanguageBusinessRules;
			}

			public async Task<DeletedSPLDto> Handle(DeleteSPLCommand request, CancellationToken cancellationToken)
			{
				SoftwareProgrammingLanguage? softwareProgrammingLanguage = await _softwareProgrammingLanguageRepository.GetAsync(b=>b.Id == request.Id);
				_softwareProgrammingLanguageBusinessRules.SoftwareProgrammingLanguageShouldExistWhenRequested(softwareProgrammingLanguage);

				SoftwareProgrammingLanguage deletedLanguage = await _softwareProgrammingLanguageRepository.DeleteAsync(softwareProgrammingLanguage);
				DeletedSPLDto deletedSPLDto = _mapper.Map<DeletedSPLDto>(deletedLanguage);	
				return deletedSPLDto;	

			}
		}

	}
}
