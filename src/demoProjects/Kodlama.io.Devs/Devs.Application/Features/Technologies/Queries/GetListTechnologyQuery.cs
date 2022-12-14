using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Devs.Application.Features.Technologies.Models;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Technologies.Queries
{
	public class GetListTechnologyQuery : IRequest<TechnologyListModel>
	{
		public PageRequest PageRequest { get; set; }
		public class GetListTechnologyQueryHandler :IRequestHandler<GetListTechnologyQuery, TechnologyListModel>
		{
			private readonly ITechnologyRepository _technologyRepository;
			private readonly IMapper _mapper;

			public GetListTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
			{
				_technologyRepository = technologyRepository;
				this._mapper = mapper;
			}

			public async Task<TechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
			{
				IPaginate<Technology> technology = await _technologyRepository.GetListAsync(
					include:
					m=>m.Include(c=>c.SoftwareProgrammingLanguage),
					index: request.PageRequest.Page,
					size: request.PageRequest.PageSize);
				TechnologyListModel model = _mapper.Map<TechnologyListModel>(technology);
				return model;	
			}
		}
	}
}
