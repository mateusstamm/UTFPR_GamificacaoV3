using System.Net.Http.Headers;
using System.Text;
using GerenRest.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace GerenRest.RazorPages.Pages.Garcon
{
    public class Create : PageModel
    {
        [BindProperty]
        public GarconModel GarconModel { get; set; } = new();
        public Create()
        {

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
                string apiUrl = "http://webapi:80/Garcon";

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

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