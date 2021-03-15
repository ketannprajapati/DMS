using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Web.Controllers
{
    public class UserFileController : Controller
    {

        //Return List view for user Files List
        public IActionResult List()
        {
            return View();
        }


        //return view for add and Update User files
        public IActionResult AddFile()
        {
            return View();
        }


        //Post User File Data
        public async Task<ActionResult> Create()
        {
            return View("Index");
        }
    }

    
}
