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
    public class PartsJunctionsController : AServiceController
    {

        public PartsJunctionsController(HttpClient httpClient) : base(httpClient)
        { }

        // GET: Inventorys
        public async Task<ActionResult> Index()
        {
            // don't forget to register HttpClient as a singleton service in Startup.cs.

            var request = CreateRequestToService(HttpMethod.Get, "api/partsjunctions");

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    TempData["statuscode"] = response.StatusCode;
                    return View("Error");
                }

                string jsonString = await response.Content.ReadAsStringAsync();

                List<PartsJunctions> pj = JsonConvert.DeserializeObject<List<PartsJunctions>>(jsonString);

                return View(pj);
            }
            catch (HttpRequestException)
            {
                // logging
                return View("Error");
            }
        }

        // GET: Inventorys/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventorys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventorys/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PartsJunctions pj)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(pj);

                var request = new HttpRequestMessage(HttpMethod.Post, "api/partsjunctions");
                {
                    // we set what the Content-Type header will be here
                    request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                };

                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    TempData["statuscode"] = response.StatusCode;
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