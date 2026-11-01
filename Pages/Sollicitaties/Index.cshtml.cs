using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SollicitatieTracker.Models;
using System.Net.Http.Json;

namespace SollicitatieTracker.Pages.Sollicitaties
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<Sollicitatie> Sollicitaties { get; set; } = new();

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient("SollicitatieApi");
            var result = await client.GetFromJsonAsync<List<Sollicitatie>>("/api/sollicitaties");

            if (result != null)
            {
                Sollicitaties = result;
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("SollicitatieApi");
            await client.DeleteAsync($"/api/sollicitaties/{id}");

            return RedirectToPage();
        }
    }
}