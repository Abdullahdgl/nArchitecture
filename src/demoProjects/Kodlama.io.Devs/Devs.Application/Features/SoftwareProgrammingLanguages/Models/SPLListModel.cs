
using Core.Persistence.Paging;
using Devs.Application.Features.SoftwareProgrammingLanguages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.SoftwareProgrammingLanguages.Models
{
	public class SPLListModel : BasePageableModel
	{
		public IList<SPLListDto> Items { get; set; }
	}
}
