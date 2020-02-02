using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StairsManufacturing.Models;
using StairsManufacturing.Models.Index;

namespace StairsManufacturing.Controllers {
    public class GetDetailsImagesController : Controller {
        public IActionResult GetDetails(IndexModel model) {
            return View();
        }
    }
}