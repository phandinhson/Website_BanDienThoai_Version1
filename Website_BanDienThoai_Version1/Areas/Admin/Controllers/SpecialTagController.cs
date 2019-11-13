using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Website_BanDienThoai_Version1.Areas.Admin.Controllers
{
    public class SpecialTagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}