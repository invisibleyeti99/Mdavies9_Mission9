using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mdavies9_Mission9.Models;

namespace Mdavies9_Mission9.Components
{
    public class Types : ViewComponent
    {

        private BookstoreContext repo { get; set; }

        public Types(BookstoreContext a)
        {
            repo = a;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.BookStoreCategory = RouteData?.Values["bookCat"];
            var types = repo.Books.Select(x => x.Category).Distinct().OrderBy(x=> x);
            return View(types); 
        }
    }
}
