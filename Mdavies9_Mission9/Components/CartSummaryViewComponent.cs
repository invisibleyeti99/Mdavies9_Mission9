using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mdavies9_Mission9.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mdavies9_Mission9.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket repo { get; set; }
        public CartSummaryViewComponent(Basket a)
        {
            repo = a;
        }
        public IViewComponentResult Invoke()
        {
            return View(repo);
        }
    }
}
