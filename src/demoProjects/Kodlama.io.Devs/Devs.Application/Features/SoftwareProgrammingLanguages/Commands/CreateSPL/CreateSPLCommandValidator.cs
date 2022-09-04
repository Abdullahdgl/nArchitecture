using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.SoftwareProgrammingLanguages.Commands.CreateSPL
{
	public class CreateSPLCommandValidator : AbstractValidator<CreateSPLCommand>
	{
		public CreateSPLCommandValidator()
		{
			RuleFor(c => c.Name).NotEmpty();
			//RuleFor(c => c.Name).MinimumLength(2);
		}
	}
}
