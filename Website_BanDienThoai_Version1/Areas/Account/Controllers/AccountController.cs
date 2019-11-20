using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website_BanDienThoai_Version1.Data;
using Website_BanDienThoai_Version1.Models.ViewModel;

namespace Website_BanDienThoai_Version1.Areas.Account.Controllers
{
    [Area("Account")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        [TempData]
        public string StatusMessage { get; set; }
        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var log = _db.Users.Where(x => x.UserName.Equals(model.UserName) && x.Password.Equals(model.Password)).FirstOrDefault();
                if (log == null)
                {
                    TempData["StatusMessage"] = "Tài khoản hoặc mật khẩu bị sai!!!";

                    return View(model);
                }
                else
                {
                    if (model.UserName == "phandinhson")
                    {
                        HttpContext.Session.SetInt32("AccountId", log.Id);
                        return RedirectToAction("Index", "Products", new { area = "Admin" });
                    }

                  

                    return RedirectToAction("Index", "Home", new { area = "Customer" });
                }
            }
            return View("Index");
        }
    }
}