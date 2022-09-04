using Core.Application.Requests;
using Devs.Application.Features.SoftwareProgrammingLanguages.Commands.CreateSPL;
using Devs.Application.Features.SoftwareProgrammingLanguages.Commands.DeleteSPL;
using Devs.Application.Features.SoftwareProgrammingLanguages.Commands.UpdateSPL;
using Devs.Application.Features.SoftwareProgrammingLanguages.Dtos;
using Devs.Application.Features.SoftwareProgrammingLanguages.Models;
using Devs.Application.Features.SoftwareProgrammingLanguages.Queries.GetByIdSPL;
using Devs.Application.Features.SoftwareProgrammingLanguages.Queries.GetListSPL;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace Devs.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SoftwareProgrammingLanguagesController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
		{
			GetListSPLOuery getListSPLOuery = new() { PageRequest = pageRequest };
			SPLListModel result = await Mediator.Send(getListSPLOuery);
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			GetByIdSLPOuery getByIdSLPOuery = new() { Id = id };
			SPLGetByIdDto result = await Mediator.Send(getByIdSLPOuery);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CreateSPLCommand createSPLCommand)
		{
			CreatedSPLDto result = await Mediator.Send(createSPLCommand);
			return Created("", result);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateSPLCommand updateSPLCommand)
		{
			UpdatedSPLDto result = await Mediator.Send(updateSPLCommand);
			return Ok(result);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete([FromQuery] int id)
		{
			DeleteSPLCommand deleteSPLCommand = new() { Id = id };
			DeletedSPLDto result = await Mediator.Send(deleteSPLCommand);
			return Ok(result);
		}
	}
}
