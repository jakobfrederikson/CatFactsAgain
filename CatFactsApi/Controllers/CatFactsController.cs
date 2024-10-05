using CatFactsApi.Interfaces;
using CatFactsApi.Models;
using CatFactsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatFactsApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CatFactsController : ControllerBase
	{
		private readonly IExternalCatClient _externalCatClient;

		public CatFactsController (IExternalCatClient externalCatClient)
		{
			_externalCatClient = externalCatClient;
		}

		[HttpGet]
		public async Task<CatFact> Get()
		{
			CatFactService catFactService = new CatFactService(_externalCatClient);
			CatFact catFact = await catFactService.GetCatFact();
			return catFact;
		}
	}
}
