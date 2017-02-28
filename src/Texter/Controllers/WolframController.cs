using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Texter.Models;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Texter.Controllers
{
    public class WolframController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }
      [HttpPost]
        public async Task<ActionResult> Index(string question)
        {
            var wolframResultString = await WA.AskWolfram(question);
                return View("Index", wolframResultString);
            
        }
       
    }
}
