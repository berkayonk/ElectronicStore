using ElectronicStore.Data.Base;
using ElectronicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Data.Service
{
    public class SellerService : EntityBaseRepository<Seller>, ISellerService
    {
        public SellerService(DatabaseContext context) : base(context)
        {

        }
    }
}
