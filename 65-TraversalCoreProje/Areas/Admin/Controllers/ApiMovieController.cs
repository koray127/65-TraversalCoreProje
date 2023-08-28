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
    [Area("Admin")]
    [AllowAnonymous]
    public class ApiMovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
			List<ApiMovieViewModel> apiMovies = new List<ApiMovieViewModel>();
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
				Headers =
	{
		{ "X-RapidAPI-Key", "561a744b9cmshe0f9cf83e6a9bd7p1e4a62jsn69d7aeca69e1" },
		{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				apiMovies = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
				return View(apiMovies);
			}
		}
    }
}
