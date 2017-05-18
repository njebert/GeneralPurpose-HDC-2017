using GeneralPurpose.WebApp.Configuration;
using GeneralPurpose.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GeneralPurpose.WebApp.Controllers
{
    public class CustomersController : Controller
    {
        private APISettings _apiSettings { get; set; }
        public CustomersController(IOptions<APISettings> apiSettings)
        {
            _apiSettings = apiSettings.Value;
        }

        // GET: Customers
        public ActionResult Index()
        {
            //retrieve customers from WebClient call to API layer

            var customersViewModel = new CustomerViewModel();

            List<Customer> retrievedCustomers = new List<Customer>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiSettings.APIUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/Customers").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    retrievedCustomers = JsonConvert.DeserializeObject<List<Customer>>(responseString);
                }
            }

            customersViewModel.customers = retrievedCustomers;

            return View(customersViewModel);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            //retrieve the correct customer

            return View(new Customer());
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                Console.WriteLine("Wait here...");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            //retrieve the correct customer

            return View(new Customer());
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                Console.WriteLine("Wait here...");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            //retrieve the correct customer
            return View();
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                Console.WriteLine("Wait here...");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}