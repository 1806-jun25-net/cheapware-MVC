﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Cheapware.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace TodoMvc.Controllers
{

    public class AccountController : AServiceController
    {
        // how do we know what username and what roles we have for subsequent requests?
        // could make every API model include that info, so we know. (e.g. model base class)

        // could make an API endpoint to just tell me that info, and then I call that endpoint
        // every time I need to know who I am in MVC, and put that info into e.g. ViewData.
        // that it would be a good candidate for a custom action filter.

        // especially since if i want to put something dynamic in the layout / navbar for my user,
        // then that would be every request.

        public AccountController(HttpClient httpClient) : base(httpClient)
        { }

        // GET: Account/Register
        public ViewResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        public async Task<ActionResult> Register(ViewLoginInfo info)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            Login login = new Login
            {
                Username = info.Username,
                Password = info.Password
            };


            HttpRequestMessage apiAccRequest = CreateRequestToService(HttpMethod.Post, "api/Account/Register", login);

            HttpResponseMessage apiAccResponse;

            try
            {
                apiAccResponse = await HttpClient.SendAsync(apiAccRequest);
            }
            catch
            {
                return View("Error");
            }

            if (!apiAccResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }

            PassCookiesToClient(apiAccResponse);


            //Create customer here
            Customers cust = new Customers
            {
                Username = info.Username,
                Address = info.Address,
                CustomerName = info.CustomerName
            };


            HttpRequestMessage apiCustRequest = CreateRequestToService(HttpMethod.Post, "api/Customers", cust);

            HttpResponseMessage apiCustResponse;

            try
            {
                apiCustResponse = await HttpClient.SendAsync(apiCustRequest);
            }
            catch
            {
                return View("Error");
            }

            if (!apiCustResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }

            return RedirectToAction("Index", "Home");
        }


        // GET: Account/Login
        public ViewResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public async Task<ActionResult> Login(Login account)
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, "api/Account/Login", account);

            HttpResponseMessage apiResponse;
            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch (AggregateException)
            {
                return View("Error");
            }

            if (!apiResponse.IsSuccessStatusCode)
            {
                if (apiResponse.StatusCode == HttpStatusCode.Forbidden)
                {
                    return View("AccessDenied");
                }
                return View("Error");
            }

            PassCookiesToClient(apiResponse);

            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Logout
        public async Task<ActionResult> Logout()
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, "api/Account/Logout");

            HttpResponseMessage apiResponse;

            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch (AggregateException)
            {
                return View("Error");
            }

            if (!apiResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }

            PassCookiesToClient(apiResponse);

            return RedirectToAction("Index", "Home");
        }

        private bool PassCookiesToClient(HttpResponseMessage apiResponse)
        {
            if (apiResponse.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> values))
            {
                string authValue = values.FirstOrDefault(x => x.StartsWith(s_CookieName));
                if (authValue != null)
                {
                    Response.Headers.Add("Set-Cookie", authValue);
                    return true;
                }
            }
            return false;
        }
    }
}