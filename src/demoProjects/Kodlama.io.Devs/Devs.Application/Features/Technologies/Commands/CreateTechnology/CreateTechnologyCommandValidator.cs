using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Technologies.Commands.CreateTechnology
{
	public class CreateTechnologyCommandValidator : AbstractValidator<CreateTechnologyCommand>
	{
		public CreateTechnologyCommandValidator()
		{
			RuleFor(p => p.Name).NotEmpty();
			RuleFor(p => p.SPLId).NotEmpty();
			RuleFor(p => p.SPLId).NotEmpty().GreaterThan(0);
		}
	}
}
