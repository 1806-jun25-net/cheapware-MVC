using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cheapware.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoMvc.Controllers;

namespace CheapWare.WebApp.Controllers
{
    public class RamsController : AServiceController
    {

        public RamsController(HttpClient httpClient) : base(httpClient)
        { }

        // GET: Inventorys
        public async Task<ActionResult> Index()
        {
            // don't forget to register HttpClient as a singleton service in Startup.cs.

            var request = CreateRequestToService(HttpMethod.Get, "api/rams");

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                string jsonString = await response.Content.ReadAsStringAsync();

                List<Rams> ram = JsonConvert.DeserializeObject<List<Rams>>(jsonString);

                return View(ram);
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
            var request = CreateRequestToService(HttpMethod.Get, "api/rams/" + name);

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                string jsonString = await response.Content.ReadAsStringAsync();

                Rams ram = JsonConvert.DeserializeObject<Rams>(jsonString);

                return View(ram);

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
        public async Task<ActionResult> Create(Rams ram)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(ram);

                var request = new HttpRequestMessage(HttpMethod.Post, "api/rams");
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