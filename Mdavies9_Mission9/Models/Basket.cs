using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mdavies9_Mission9.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>(); 
        public virtual void AddItem (Book proj, int qty)
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
        public virtual void RemoveItem(Book proj)
        {
            Items.RemoveAll(x => x.Book.BookId == proj.BookId);

        }
        public virtual void ClearBasket()
        {
            Items.Clear();
        }
    }
  
    public class BasketLineItem
    {
        [Key]
        [Required]
        public int LineId { get; set; }
        [Required]
        public Book Book { get; set; }
        [Required]
        public int Quantity { get; set; }
        

    }
}
