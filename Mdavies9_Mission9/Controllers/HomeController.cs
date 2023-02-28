using Mdavies9_Mission9.Models;
using Mdavies9_Mission9.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mdavies9_Mission9.Controllers
{
    public class HomeController : Controller
    {
        private BookstoreContext context { get; set;  }
      
        public HomeController(BookstoreContext x) => context = x;
        public IActionResult Index( int pageNum = 1)
        {
            int NumResults = 10;
            var rx = new BooksVM
            {
                Books = context.Books.OrderBy(x => x.Title).Skip((pageNum - 1) * NumResults).Take(NumResults),
                PageInfo = new PageInfo
                {
                    TotalNumBooks = context.Books.Count(),
                    BooksPerPage = NumResults,
                    CurrPage = pageNum
                    
                    

                }
            };
            return View(rx);
        }
    }
}
