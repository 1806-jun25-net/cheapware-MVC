using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cheapware.WebApp.Models;
using CheapWare.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoMvc.Controllers;

namespace CheapWare.WebApp.Controllers
{
    public class CartController : AServiceController
    {

        public CartController(HttpClient httpClient) : base(httpClient)
        { }


        //Get (Index), Add (create), Delete (delete)

        // GET: Inventorys
        public async Task<ActionResult> Index(string username)
        {
            // don't forget to register HttpClient as a singleton service in Startup.cs.

            var request = CreateRequestToService(HttpMethod.Get, "api/cart/");

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    TempData["statuscode"] = response.StatusCode;
                    return View("Error");
                }

                string jsonString = await response.Content.ReadAsStringAsync();
            }
            catch
            {
                return View("Error");
            }
            return View();
        }


        [HttpDelete]
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
        public async Task<ActionResult> Create(Cart cart)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(cart);

                var request = new HttpRequestMessage(HttpMethod.Post, "api/cart");
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



        // GET: Inventorys/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/cart/" + id);
            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

    }
        
}