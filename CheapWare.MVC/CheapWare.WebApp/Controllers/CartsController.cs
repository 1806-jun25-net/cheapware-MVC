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
        public async Task<ActionResult> DeleteCartByCartId(int cartId)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/cart/DeleteByCartId/" + cartId);
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

        [HttpGet]
        public async Task<ActionResult<Inventorys>> Index()
        {
            // don't forget to register HttpClient as a singleton service in Startup.cs.
            var temp = (int)TempData.Peek("CustomerId");
            var request = CreateRequestToService(HttpMethod.Get, "api/Cart/cartByCustomer/" + temp);
            var req = CreateRequestToService(HttpMethod.Get, "api/Cart/CartIdsByCustomer/" + temp);
            try
            {
                var response = await HttpClient.SendAsync(request);
                var res = await HttpClient.SendAsync(req);

                if (!response.IsSuccessStatusCode && !res.IsSuccessStatusCode)
                {
                    TempData["statuscode"] = res.StatusCode;
                    return View("Error");
                }

                string jsonString = await response.Content.ReadAsStringAsync();
                string jString = await res.Content.ReadAsStringAsync();
                List<Inventorys> i = JsonConvert.DeserializeObject<List<Inventorys>>(jsonString);
                List<Carts> c = JsonConvert.DeserializeObject<List<Carts>>(jString);
                List<InventoryCartView> icv = new List<InventoryCartView>();

                for (int l = 0; l < i.Count; l++)
                {
                    var obj = new InventoryCartView()
                    {
                        Name = i[l].Name,
                        Quantity = i[l].Quantity,
                        Category = i[l].Category,
                        Price = i[l].Price,
                        Image = i[l].Image,
                        CartId = c[l].CartId

                    };
                    icv.Add(obj);

                }

                return View(icv);
            }
            catch (HttpRequestException)
            {
                // logging
                return View("Error");
            }
        }




        [HttpPost]
        public async Task<ActionResult> PlaceOrder(List<Inventorys> items)
        {

            if (items.Count == 0)
            {
                return RedirectToAction("Index");
            }
            try
            {
                string jsonString = JsonConvert.SerializeObject(items);

                var request = CreateRequestToService(HttpMethod.Post, "api/Orders/PlaceOrder", items);


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
        [HttpGet]
        public async Task<ActionResult> Delete(int cartId)
        {
            var request = CreateRequestToService(HttpMethod.Delete, "api/Cart/DeleteByCartId/" + cartId);
            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

    }
        
}