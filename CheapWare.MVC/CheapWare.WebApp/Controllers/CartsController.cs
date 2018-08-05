using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CheapWare.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public async Task<ActionResult<Inventorys>> Index()
        {
            // don't forget to register HttpClient as a singleton service in Startup.cs.
            var temp = (int)TempData.Peek("CustomerId");
            var request = CreateRequestToService(HttpMethod.Get, "api/Cart/cartByCustomer/" + temp);

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                string jsonString = await response.Content.ReadAsStringAsync();

                List<Inventorys> i = JsonConvert.DeserializeObject<List<Inventorys>>(jsonString);

                return View(i);
            }
            catch (HttpRequestException)
            {
                // logging
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Index2()
        {
            return View();
        }

        // POST: Inventorys/Create
        [HttpGet]
        public async Task<ActionResult> AddCart(string name)
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

                var request = CreateRequestToService(HttpMethod.Post, "api/cart/AddCart", cart);
                

                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    TempData["statuscode"] = response.StatusCode;
                    return View("Error");
                }



                return View();
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