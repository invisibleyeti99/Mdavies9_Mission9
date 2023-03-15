using Mdavies9_Mission9.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mdavies9_Mission9.Models
{
    public interface ISalesRepository
    {
       public IQueryable<StoreSales> Sales { get; }
        public void SaveDonation(StoreSales sales);
    } 
}
