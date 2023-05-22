using GerenRest.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace GerenRest.RazorPages.Pages.Garcon
{
    public class Delete : PageModel
    {
        [BindProperty]
        public GarconModel GarconModel { get; set; } = new();
        public Delete()
        {
            
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            using (var httpClient = new HttpClient())
            {
                string url = $"http://localhost:5239/Garcon/{id}";

                var requestMes = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await httpClient.SendAsync(requestMes);
                
                var content = await response.Content.ReadAsStringAsync();
                GarconModel = JsonConvert.DeserializeObject<GarconModel>(content)!;
            }

            return Page();
        }
    
        public async Task<IActionResult> OnPostAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                string url = $"http://localhost:5239/Garcon/{id}";

                var response = await httpClient.DeleteAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return NotFound();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}