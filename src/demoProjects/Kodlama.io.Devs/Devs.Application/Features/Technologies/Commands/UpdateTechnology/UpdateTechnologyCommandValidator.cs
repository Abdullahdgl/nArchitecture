using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Technologies.Commands.UpdateTechnology
{
	public class UpdateTechnologyCommandValidator : AbstractValidator<UpdateTechnologyCommand>
	{
		public UpdateTechnologyCommandValidator()
		{
			RuleFor(p => p.Id).NotEmpty();
			RuleFor(p => p.Name).NotEmpty();
			RuleFor(p => p.Id).GreaterThan(0);
			RuleFor(p => p.SPLId).GreaterThan(0);
			RuleFor(p => p.SPLId).NotEmpty();
		}
	}
}
