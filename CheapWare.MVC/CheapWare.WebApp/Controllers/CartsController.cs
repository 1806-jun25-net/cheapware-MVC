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
    public class CartsController : AServiceController
    {

        public CartsController(HttpClient httpClient) : base(httpClient)
        { }


        //Get (Index), Add (create), Delete (delete)


        
        [HttpDelete]
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
       public ActionResult Index()
        {
            return View();
        }

        // POST: Inventorys/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(string name)
        {
            var temp = TempData.Peek("CustomerId");
            Carts cart = new Carts
            {
                CustomerId = (int)temp,
                ProductId = name
            };
            try
            {
                string jsonString = JsonConvert.SerializeObject(cart);

                var request = new HttpRequestMessage(HttpMethod.Post, "api/cart/AddToCart");
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

                HttpRequestMessage apiReq = CreateRequestToService(HttpMethod.Get, "api/inventorys/" + name);
                HttpResponseMessage apiResp;
                try
                {
                    apiResp = await HttpClient.SendAsync(apiReq);
                }
                catch
                {
                    return View("Error");
                }
                if (!apiResp.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                string invjsonString = await apiResp.Content.ReadAsStringAsync();

                Inventorys cc = JsonConvert.DeserializeObject<Inventorys>(jsonString);

                //TempData["CustomerId"] = cc;

                return RedirectToAction("index", cc);
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