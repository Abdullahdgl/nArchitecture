using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.SoftwareProgrammingLanguages.Commands.CreateSPL;
using Devs.Application.Features.SoftwareProgrammingLanguages.Dtos;
using Devs.Application.Features.SoftwareProgrammingLanguages.Models;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.SoftwareProgrammingLanguages.Profiles
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<SoftwareProgrammingLanguage, CreatedSPLDto>().ReverseMap();
			CreateMap<SoftwareProgrammingLanguage, CreateSPLCommand>().ReverseMap();
			CreateMap<IPaginate<SoftwareProgrammingLanguage>, SPLListModel>().ReverseMap();
			CreateMap<SoftwareProgrammingLanguage, SPLListDto>().ReverseMap();
			CreateMap<SoftwareProgrammingLanguage, SPLGetByIdDto>().ReverseMap();

		}
	}
}
