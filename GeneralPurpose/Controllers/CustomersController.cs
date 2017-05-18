using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerLogic;
using CustomerLogic.Models;

namespace GeneralPurpose.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerAccessor _customerAccessor;
        public CustomersController(ICustomerAccessor customerAccessor)
        {
            _customerAccessor = customerAccessor;
        }
        [HttpGet("GetCustomerCount")]
        public int GetCustomerCount()
        {
            return _customerAccessor.GetCustomers().Count();
        }

        public List<Customers> GetAll()
        {
            return _customerAccessor.GetCustomers();
        }

        #region Large API Example 1

        //[Route("{pageSize:int}/{pageNumber:int}/orderBy:alpha?")]
        //public IActionResult GetAll(int pageSize, int pageNumber, string orderBy = "")
        //{
        //    var results = _customerAccessor.GetCustomers().Skip(pageSize * pageNumber).Take(pageSize);
        //    if (!string.IsNullOrEmpty(orderBy))
        //    {
        //        // hanldle order By
        //        switch (orderBy)
        //        {
        //            case "Id":
        //                results = results.OrderBy(r => r.CustomerId).ToList();
        //                break;
        //            case "CreditLimit":
        //                results = results.OrderBy(r => r.CreditLimit).ToList();
        //                break;
        //            // Even 
        //            // More
        //            // Options
        //            default:
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        results = results.OrderBy(r => r.CustomerName).ToList();
        //    }

        //    return new ObjectResult(results);
        //}

        #endregion

        #region Large API Example 2

        //[Route("{platform:string?}/{pageSize:int}/{pageNumber:int}/orderBy:alpha?")]
        //public IActionResult GetAll(string platform, int pageSize, int pageNumber, string orderBy = "")
        //{
        //    List<Customers> results = new List<Customers>();

        //    if (platform == "app")
        //    {
        //        // Get Custoemrs for app platform

        //        results = _customerAccessor.GetCustomers().Skip(pageSize * pageNumber).Take(pageSize).ToList();
        //        if (!string.IsNullOrEmpty(orderBy))
        //        {
        //            // hanldle order By
        //            switch (orderBy)
        //            {
        //                case "Id":
        //                    results = results.OrderBy(r => r.CustomerId).ToList();
        //                    break;
        //                case "CreditLimit":
        //                    results = results.OrderBy(r => r.CreditLimit).ToList();
        //                    break;
        //                // Even 
        //                // More
        //                // Options
        //                default:
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            results = results.OrderBy(r => r.CustomerName).ToList();
        //        }
        //    }
        //    else
        //    {
        //        // Get Customers for WebApp
        //        results = _customerAccessor.GetCustomers().ToList();
        //    }

        //    return new ObjectResult(results);
        //}

        #endregion

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetById(long id)
        {
            return new ObjectResult(_customerAccessor.GetCustomers().Where(c => c.CustomerId == id).SingleOrDefault());
        }
    }
}