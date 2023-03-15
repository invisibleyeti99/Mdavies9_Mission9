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
        public DonateModel(BookstoreContext temp, Basket b)
        {
            context = temp;
            basket = b;
        }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            
        }
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = context.Books.FirstOrDefault(c => c.BookId == bookId);
            basket.AddItem(b, 1);
            return RedirectToPage(new { ReturnUrl = returnUrl } ); 


        }
        public IActionResult OnPostRemove(int BookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == BookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
