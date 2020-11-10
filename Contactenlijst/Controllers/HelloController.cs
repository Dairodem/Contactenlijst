using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contactenlijst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Contactenlijst.Controllers
{
    public class HelloController : Controller
    {
        private readonly IConfiguration _config;
        public HelloController(IConfiguration configuration)
        {
            _config = configuration;
        }
        public IActionResult Developer()
        {
            return View(new DeveloperViewModel 
            { 
            //    FirstName = _config.GetValue<string>("FirstName"), 
            //    LastName = _config["LastName"]

                FirstName = _config["Developer:FirstName"],
                LastName = _config["Developer:LastName"]
            });
        }
    }
}
