using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shabhub.Models;

namespace Shabhub.Controllers
{
    public class RandomDogController : Controller
    {
        // GET: RandomDog/Index
        public async Task<IActionResult> Index()
        {
            string apiUrl = "https://random.dog/woof.json";  // API Endpoint
            DogMedia dogMedia = new DogMedia();  // Model to hold the response

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    dogMedia = JsonConvert.DeserializeObject<DogMedia>(jsonString);  // Deserialize JSON to DogMedia object
                }
                else
                {
                    return StatusCode((int)response.StatusCode);  // Handle error
                }
            }

            return View(dogMedia);  // Pass the dog media to the view
        }
    }
}