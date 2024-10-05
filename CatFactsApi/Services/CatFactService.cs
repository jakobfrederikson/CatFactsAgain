using CatFactsApi.Interfaces;
using CatFactsApi.Models;

namespace CatFactsApi.Services
{
	public class CatFactService
	{
		private readonly IExternalCatClient _catClient;
		
		public CatFactService (IExternalCatClient catClient)
		{
			_catClient = catClient;
		}

		public async Task<CatFact> GetCatFact()
		{
			CatFact catFact = await _catClient.GetCatFactFromExternalService();

			return catFact;
		}
	}
}
