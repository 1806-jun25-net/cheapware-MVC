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
       public ActionResult Index()
        {
            return View();
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

                var request = new HttpRequestMessage(HttpMethod.Post, "api/cart/AddCart");
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