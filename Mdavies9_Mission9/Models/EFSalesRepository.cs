using Mdavies9_Mission9.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mdavies9_Mission9.Models
{
    public class EFSalesRepository : ISalesRepository
    {
        private BookstoreContext context;
        public EFSalesRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<StoreSales> Sales => context.StoreSales.Include(x => x.Lines).ThenInclude(x=>x.Book);

        public void SaveDonation(StoreSales sales)
        {
            context.AttachRange(sales.Lines.Select(x => x.Book));

            if (sales.SalesId == 0)
            {
                context.StoreSales.Add(sales);
            }
            context.SaveChanges();
        }
    }
}
