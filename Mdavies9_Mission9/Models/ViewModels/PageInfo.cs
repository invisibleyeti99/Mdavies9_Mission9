using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mdavies9_Mission9.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((double) TotalNumBooks / BooksPerPage); 
    }
}
