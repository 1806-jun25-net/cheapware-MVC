﻿using System;
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
    public class MotherBoardsController : AServiceController
    {

        public MotherBoardsController(HttpClient httpClient) : base(httpClient)
        { }

        // GET: Inventorys
        public async Task<ActionResult> Index()
        {
            // don't forget to register HttpClient as a singleton service in Startup.cs.

            var request = CreateRequestToService(HttpMethod.Get, "api/motherboards");

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                string jsonString = await response.Content.ReadAsStringAsync();

                List<MotherBoards> mb = JsonConvert.DeserializeObject<List<MotherBoards>>(jsonString);

                return View(mb);
            }
            catch (HttpRequestException)
            {
                // logging
                return View("Error");
            }
        }

        // GET: Inventorys/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var request = CreateRequestToService(HttpMethod.Get, "api/motherboards");

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                string jsonString = await response.Content.ReadAsStringAsync();

                List<MotherBoards> mbs = JsonConvert.DeserializeObject<List<MotherBoards>>(jsonString);

                foreach (var mb in mbs)
                {
                    if (mb.MotherBoardId == id)
                    {
                        return View(mb);
                    }
                }
                return View("Error");
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
        public async Task<ActionResult> Create(MotherBoards mb)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(mb);

                var request = new HttpRequestMessage(HttpMethod.Post, "api/motherboards");
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