using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SollicitatieTracker.Models;
using System.Net.Http.Json;

namespace SollicitatieTracker.Pages.Sollicitaties
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CreateModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public Sollicitatie Sollicitatie { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient("SollicitatieApi");
            var response = await client.PostAsJsonAsync("/api/sollicitaties", Sollicitatie);       

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Aanmaken is mislukt.");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}