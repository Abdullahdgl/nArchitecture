using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Devs.Application.Features.SoftwareProgrammingLanguages.Models;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.SoftwareProgrammingLanguages.Queries.GetListSPL
{
	public class GetListSPLOuery : IRequest<SPLListModel>
	{
		public PageRequest PageRequest { get; set; }
		public class GetListSPLQueryHandler : IRequestHandler<GetListSPLOuery, SPLListModel>
		{
			private readonly ISoftwareProgrammingLanguageRepository _softwareProgrammingLanguageRepository;
			private readonly IMapper _mapper;

			public GetListSPLQueryHandler(ISoftwareProgrammingLanguageRepository softwareProgrammingLanguageRepository, IMapper mapper)
			{
				_softwareProgrammingLanguageRepository = softwareProgrammingLanguageRepository;
				_mapper = mapper;
			}

			public async Task<SPLListModel> Handle(GetListSPLOuery request, CancellationToken cancellationToken)
			{
				IPaginate<SoftwareProgrammingLanguage> softwareProgrammingLanguages = await _softwareProgrammingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
				SPLListModel mappedSPLListModel = _mapper.Map<SPLListModel>(softwareProgrammingLanguages);
				return mappedSPLListModel;	
			}
		}

	}
}
