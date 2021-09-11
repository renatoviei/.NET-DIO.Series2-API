using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Series.Web.Controllers
{
    public class SerieController : Controller
    {
        public IActionResult Lista()
        {
            return View();
        }
    }
}
