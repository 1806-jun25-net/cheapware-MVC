using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CheapWare.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CheapWare.WebApp.Controllers
{
    public class InventorysController : AServiceController
    {

        public InventorysController(HttpClient httpClient) : base(httpClient)
        { }

        public async Task<ActionResult> SortByCheapest()
        {
            var request = CreateRequestToService(HttpMethod.Get, "api/inventorys");

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                string jsonString = await response.Content.ReadAsStringAsync();

                List<Inventorys> inv = JsonConvert.DeserializeObject<List<Inventorys>>(jsonString).OrderBy(x => x.Price).ToList();

                return View(inv);
            }
            catch (HttpRequestException)
            {
                // logging
                return View("Error");
            }
        }

        public async Task<ActionResult> SortByExpensive()
        {
            var request = CreateRequestToService(HttpMethod.Get, "api/inventorys");

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                string jsonString = await response.Content.ReadAsStringAsync();

                List<Inventorys> inv = JsonConvert.DeserializeObject<List<Inventorys>>(jsonString).OrderByDescending(x => x.Price).ToList();

                return View(inv);
            }
            catch (HttpRequestException)
            {
                // logging
                return View("Error");
            }
        }

        public async Task<ActionResult> GetComputerCases()
        {
            var request = CreateRequestToService(HttpMethod.Get, "api/inventorys");

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                string jsonString = await response.Content.ReadAsStringAsync();

                List<Inventorys> inv = JsonConvert.DeserializeObject<List<Inventorys>>(jsonString).Where(x => x.Category == "ComputerCases").ToList();

                return View(inv);
            }
            catch (HttpRequestException)
            {
                // logging
                return View("Error");
            }
        }

        // GET: Inventorys
        public async Task<ActionResult> Index()
        {
            // don't forget to register HttpClient as a singleton service in Startup.cs.

            var request = CreateRequestToService(HttpMethod.Get, "api/inventorys");

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                string jsonString = await response.Content.ReadAsStringAsync();

                List<Inventorys> inv = JsonConvert.DeserializeObject<List<Inventorys>>(jsonString);

                var tester = TempData.Peek("CustomerId");

                return View(inv);
            }
            catch (HttpRequestException)
            {
                // logging
                return View("Error");
            }
        }

        // GET: Inventorys/Details/5
        public async Task<ActionResult> Details(string name)
        {
            var request = CreateRequestToService(HttpMethod.Get, "api/inventorys/" + name);

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                string jsonString = await response.Content.ReadAsStringAsync();

                Inventorys inv = JsonConvert.DeserializeObject<Inventorys>(jsonString);

                return View(inv);

            }
            catch (HttpRequestException)
            {
                return View("Error");
            }
        }

        // GET: Inventorys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventorys/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Inventorys inv)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(inv);

                var request = new HttpRequestMessage(HttpMethod.Post, "api/inventorys");
                {
                    // we set what the Content-Type header will be here
                    request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                };

                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventorys/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inventorys/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventorys/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventorys/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}