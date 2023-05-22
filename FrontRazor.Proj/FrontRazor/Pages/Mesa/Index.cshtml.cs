using GerenRest.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace GerenRest.RazorPages.Pages.Mesa
{
    public class Index : PageModel
    {
        public List<MesaModel> MesaModel { get; set; } = new();
        public Index()
        {
            
        }
        public async Task<IActionResult> OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                string url = "http://webapi:80/Mesa";

                var requestMes = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await httpClient.SendAsync(requestMes);
                
                var content = await response.Content.ReadAsStringAsync();
                MesaModel = JsonConvert.DeserializeObject<List<MesaModel>>(content)!;
            }

            return Page();
        }
    }
}