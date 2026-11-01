using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SollicitatieTracker.Models;
using System.Net.Http.Json;

namespace SollicitatieTracker.Pages.Sollicitaties
{
    public class EditModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EditModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public Sollicitatie Sollicitatie { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("SollicitatieApi");
            var response = await client.GetAsync($"/api/sollicitaties/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            Sollicitatie = await response.Content.ReadFromJsonAsync<Sollicitatie>();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient("SollicitatieApi");
            var response = await client.PutAsJsonAsync($"/api/sollicitaties/{Sollicitatie.Id}", Sollicitatie);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Bijwerken is mislukt.");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}