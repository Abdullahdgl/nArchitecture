using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.SoftwareProgrammingLanguages.Commands.CreateSPL;
using Devs.Application.Features.SoftwareProgrammingLanguages.Commands.DeleteSPL;
using Devs.Application.Features.SoftwareProgrammingLanguages.Commands.UpdateSPL;
using Devs.Application.Features.Technologies.Commands.CreateTechnology;
using Devs.Application.Features.Technologies.Dtos;
using Devs.Application.Features.Technologies.Models;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Technologies.Profiles
{
	public class MappingProfiles:Profile

	  
	{
		public MappingProfiles()
		{
			//Create
			CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
			CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();

			//Get
			CreateMap<Technology, TechnologyListDto>().ForMember(c => c.SPLName,
				opt =>opt.MapFrom(c => c.SoftwareProgrammingLanguage.Name)).ReverseMap();
			CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();

			//Update
			CreateMap<UpdateSPLCommand, Technology>().ReverseMap();
			CreateMap<UpdatedTechnologyDto, Technology>().ReverseMap();

			//Delete
			CreateMap<Technology, DeletedTechnologyDto>().ReverseMap();
			CreateMap<Technology, DeleteSPLCommand>().ReverseMap();




		}

	}
}
