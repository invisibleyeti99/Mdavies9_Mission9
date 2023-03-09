using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mdavies9_Mission9.Infrastructure;
using Mdavies9_Mission9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mdavies9_Mission9.Pages
{
    public class DonateModel : PageModel
    {
        private BookstoreContext context { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        public DonateModel(BookstoreContext temp)
        {
            context = temp;
        }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = context.Books.FirstOrDefault(c => c.BookId == bookId);
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket); 
            return RedirectToPage(new { ReturnUrl = returnUrl } ); 


        }
    }
}
