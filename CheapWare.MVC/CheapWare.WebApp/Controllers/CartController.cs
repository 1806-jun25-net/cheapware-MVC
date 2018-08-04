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


        [HttpDelete]
        public ActionResult Details(int id)
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