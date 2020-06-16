using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DatabaseFirstWebApplication.Models;

namespace DatabaseFirstWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // shouldn't read hardcode, but just for a test 
        private johntestContext _context = new johntestContext();
               

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        public IActionResult Index()

        {
            
            //------------------------------------------------------------------------------
            // basic way of returning data 

            var myList = new List<Test>();

            myList = _context.Test.ToList();

            return View(myList);


            //----------------------------------------------------------------------------
            /* calling a SELECT procedure 
            
            var test = new List<Test>();
            
            string myName = "steve";

            test = _context.Test
                    .FromSqlInterpolated($"sp_getdetails @name={myName}")
                    .ToList();

            return View(myList); // just return view so you don't get an error 
            */
            //----------------------------------------------------------------------------

            //----------------------------------------------------------------------------
            /*  calling an INSERT procedure  
            
            var myName = new SqlParameter("@name", "Neil");
            var myPhone = new SqlParameter("@phone", 876);
            _context.Database.ExecuteSqlRaw("dbo.sp_insertdetails @name, @phone", myName, myPhone);
            // n.b. used ExecuteSqlRaw as opposed to ExecuteSqlCommand 
            
            return View(myList); // just return view so you don't get an error 

            */

            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
