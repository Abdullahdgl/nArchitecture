using Devs.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.SoftwareProgrammingLanguages.Commands.UpdateSPL
{
	public class UpdateSPLCommandValidator : AbstractValidator<SoftwareProgrammingLanguage>
	{
		public UpdateSPLCommandValidator()
		{
			RuleFor(x => x.Name).NotEmpty();

		}
	}
}
