using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Website_BanDienThoai_Version1.Models.ViewModel;
using Website_BanDienThoai_Version1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Website_BanDienThoai_Version1.Models;
using System.Diagnostics;

namespace Website_BanDienThoai_Version1.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AccountController : Controller
    {

        private readonly ApplicationDbContext _db;
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
  
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userdetails = await _db.Customers
                .SingleOrDefaultAsync(m => m.UserName == model.UseName && m.Password == model.Password);
                if (userdetails == null)
                {
                    ModelState.AddModelError("Password", "Invalid login attempt.");
                    return View("Index");
                }
                HttpContext.Session.SetString("userId", userdetails.Name);
            }
            else
            {
                return View("Index");
            }
            return RedirectToAction("Index", "Home",new { area="Customer"});
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
 
        public async Task<ActionResult> Register(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                Customers user = new Customers
                {
                    UserName = model.UserName,
                    Phone = model.Phone,
                    Email = model.Email,
                    Password = model.Password,
                    DateOfBith = model.DateOfBith,
                    Gender = model.Gender

                };
                _db.Add(user);
                await _db.SaveChangesAsync();

            }
            else
            {
                return View("Registration");
            }
            return RedirectToAction("Index", "Account");
        }
        // registration Page load
        public IActionResult Registration()
        {
            ViewData["Message"] = "Registration Page";

            return View();
        }
        public void ValidationMessage(string key, string alert, string value)
        {
            try
            {
                TempData.Remove(key);
                TempData.Add(key, value);
                TempData.Add("alertType", alert);
            }
            catch
            {
                Debug.WriteLine("TempDataMessage Error");
            }

        }
    }
}