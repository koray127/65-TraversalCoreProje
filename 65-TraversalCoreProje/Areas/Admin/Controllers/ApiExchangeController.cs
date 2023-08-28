using _65_TraversalCoreProje.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace _65_TraversalCoreProje.Areas.Admin.Controllers
{
    public class ApiExchangeController : Controller
    {
        [Area("Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
			List<BookingExchangeViewModel2> bookingExchangeViewModels = new List<BookingExchangeViewModel2>(); 
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
				Headers =
	{
		{ "X-RapidAPI-Key", "561a744b9cmshe0f9cf83e6a9bd7p1e4a62jsn69d7aeca69e1" },
		{ "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var values= JsonConvert.DeserializeObject<BookingExchangeViewModel2>(body);
				return View(values.exchange_rates);
			}
		}
    }
}
