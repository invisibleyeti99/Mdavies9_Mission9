using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mdavies9_Mission9.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>(); 
        public void AddItem (Book proj, int qty)
        {
            BasketLineItem Line = Items
                .Where(b => b.Book.BookId == proj.BookId).FirstOrDefault(); 

            if (Line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = proj,
                    Quantity = qty,
                    
                });
            }
            else
            {
                Line.Quantity += qty;
            }
        }
        public double CalcTotal()
        {
            
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);
            

            return sum;
        }
    }
    
    public class BasketLineItem
    {
        public int LineId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        

    }
}
