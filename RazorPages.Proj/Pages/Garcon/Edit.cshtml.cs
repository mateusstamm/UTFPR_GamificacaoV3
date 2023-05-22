using System.Net.Http.Headers;
using System.Text;
using GerenRest.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace GerenRest.RazorPages.Pages.Garcon
{
    public class Edit : PageModel
    {
        [BindProperty]
        public GarconModel GarconModel { get; set; } = new();
        public Edit()
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string jsonData = JsonConvert.SerializeObject(GarconModel);

            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"http://localhost:5239/Garcon/{id}";

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Garcon/Index");
                }               
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
        }
    }
}