using CatFactsApi.Models;
using Newtonsoft.Json;

namespace CatFactsApi.Interfaces
{
	public interface IExternalCatClient
	{
		public async Task<CatFact> GetCatFactFromExternalService()
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://catfact.ninja/");

			// Request 100 breeds from catfact
			HttpResponseMessage response = await client.GetAsync("fact");
			response.EnsureSuccessStatusCode();

			// Convert the response into JSON
			string jsonResponse = await response.Content.ReadAsStringAsync();

			// Deserialize the JSON response
			CatFact catFact = JsonConvert.DeserializeObject<CatFact>(jsonResponse);

			return catFact;
		}
	}
}
