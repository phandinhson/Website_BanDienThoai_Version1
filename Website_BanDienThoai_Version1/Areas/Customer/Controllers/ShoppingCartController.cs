using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Website_BanDienThoai_Version1.Models.ViewModel;
using Website_BanDienThoai_Version1.Data;
using Microsoft.AspNetCore.Http;
using Website_BanDienThoai_Version1.Extentions;
using Website_BanDienThoai_Version1.Models;
using Microsoft.EntityFrameworkCore;

namespace Website_BanDienThoai_Version1.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public ShoppingCartViewModel ShoppingCartVM { get; set; }
        public ShoppingCartController(ApplicationDbContext db)
        {
            _db = db;
            ShoppingCartVM = new ShoppingCartViewModel()
            {
                Products = new List<Models.Products>()

            };
        }
       

        //Get Index Shopping Cart
        public async Task<IActionResult> Index()
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if(lstShoppingCart.Count>0)
            {
                foreach (var cardItem in lstShoppingCart)
                {
                    Products product = _db.Products
                        .Include(p=>p.SpecialTag)
                        .Include(p=>p.Category)
                        .Where(p => p.Id == cardItem)
                        .FirstOrDefault();
                    ShoppingCartVM.Products.Add(product);
                }
            }
            return View(ShoppingCartVM);
        }
    }
}