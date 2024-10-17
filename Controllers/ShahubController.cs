using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Shabhub.Models;
using System.Text;

namespace Shabhub.Controllers
{
    public class ShahubController : Controller
    {
        // GET: ShahubController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7126/api/user";

            List<User> users = new List<User>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<User>>(result);
            }

            return View(users);
        }

        // GET: ShahubController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShahubController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShahubController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User user)
        {
            string apiUrl = "https://localhost:7126/api/user";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(user);
        }

        // GET: ShahubController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShahubController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShahubController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShahubController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
