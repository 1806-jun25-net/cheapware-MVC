﻿using System;
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
    public class PowerSupplysController : AServiceController
    {

        public PowerSupplysController(HttpClient httpClient) : base(httpClient)
        { }

        // GET: Inventorys
        public async Task<ActionResult> Index()
        {
            // don't forget to register HttpClient as a singleton service in Startup.cs.

            var request = CreateRequestToService(HttpMethod.Get, "api/powersupplys");

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    TempData["statuscode"] = response.StatusCode;
                    return View("Error");
                }

                string jsonString = await response.Content.ReadAsStringAsync();

                List<PowerSupplys> ps = JsonConvert.DeserializeObject<List<PowerSupplys>>(jsonString);

                return View(ps);
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
            var request = CreateRequestToService(HttpMethod.Get, "api/powersupplys/" + name);

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                string jsonString = await response.Content.ReadAsStringAsync();

                PowerSupplys ps = JsonConvert.DeserializeObject<PowerSupplys>(jsonString);

                return View(ps);

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
        public async Task<ActionResult> Create(PowerSupplys ps)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(ps);

                var request = new HttpRequestMessage(HttpMethod.Post, "api/powersupplys");
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