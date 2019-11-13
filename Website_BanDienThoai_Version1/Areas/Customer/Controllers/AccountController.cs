using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Website_BanDienThoai_Version1.Data;
using Website_BanDienThoai_Version1.Models;
using Website_BanDienThoai_Version1.Models.ViewModel;

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
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userdetails =  _db.Users
                .SingleOrDefaultAsync(m => m.UserName == model.UserName && m.Password == model.Password);
                if (userdetails != null)
                {
                    if (model.UserName == "phanphuhuy116")
                     {
                          return RedirectToAction("Index", "Home", new { area = "Admin" });
                      }
                       return RedirectToAction("Index", "Home", new { area = "Customer" });
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid login attempt.");
                    return Json(new { status = false, message = "Password or Username không đúng" });
                }
            }
            else
            {
                return View("Index");
            }
     
            

        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegistrationViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Users user = new Users
                    {
                        UserName = model.UserName,
                        Phone = model.Phone,
                        Email = model.Email,
                        Password = model.Password,
                        DateOfBith = model.DateOfBith,
                        Gender = Int32.Parse(model.Gender)
                    };
                    _db.Add(user);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index", "Account");
                }
                catch
                {

                    throw;
                }
            }
            return View(model);
        
                
          
          
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