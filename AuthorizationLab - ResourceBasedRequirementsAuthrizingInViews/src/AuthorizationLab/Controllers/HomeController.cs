using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthorizationLab.Controllers
{
 
    
    public class HomeController : Controller
    {
        // GET: /<controller>/

        public IActionResult Index()
        {

            return View();
        }
       
        [Authorize(Policy = "AdministratorOnly")]
        //[Authorize(Roles = "Administrator")]
        public IActionResult AdministratorIndex()
        {
          
            return View();
        }
        [Authorize(Policy = "BuildingEntry")]
        [Authorize(Policy = "Over21Only")]
        [Authorize(Policy = "UserOnly")]
        [Authorize(Policy = "EmployeeId")]
        //[Authorize(Roles = "User")]
        public IActionResult UserIndex()
        {

            return View("~/Views/Home/User.cshtml");
        }
        [Authorize(Policy = "CalibratorOnly")]
        //[Authorize(Roles = "Calibrator")]
        public IActionResult CalibratorIndex()
        {

            return View("~/Views/Home/Calibrator.cshtml");
        }
        [Authorize(Policy = "ProjectLeadOnly")]
        //[Authorize(Roles = "ProjectLead")]
        public IActionResult ProjectLeadIndex()
        {

            return View("~/Views/Home/ProjectLead.cshtml");
        }

    }
}
