using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Website_BanDienThoai_Version1.Controllers
{
    public class PhoneController : Controller
    {
        public IActionResult Phone()
        {
            return View();
        }
    }
}