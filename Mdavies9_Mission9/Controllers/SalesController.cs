using Mdavies9_Mission9.Models;
using Mdavies9_Mission9.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mdavies9_Mission9.Controllers
{
    public class SalesController : Controller
    {   
        private ISalesRepository repo { get; set; }
        private Basket basket { get; set; }
        public SalesController(ISalesRepository temp, Basket b)
        {
            repo = temp;
            basket = b; 
        }
        
        [HttpGet]
        public IActionResult Checkout()
        {

            return View(new StoreSales());
        }
        [HttpPost]
        public IActionResult Checkout(StoreSales sales)
        {
            if (basket.Items.Count() ==0 )
            {
                ModelState.AddModelError("", "Sorry your basket is empty.");

            }
            if (ModelState.IsValid)
            {
                sales.Lines = basket.Items.ToArray();
                repo.SaveDonation(sales);
                basket.ClearBasket();

                return RedirectToPage("/Confirmation"); 
            }
            else
            {
                return View();
            }
        }
    }
}
