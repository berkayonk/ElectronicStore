using ElectronicStore.Data.Base;
using ElectronicStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Data.Service
{
    public class WarrantyService : EntityBaseRepository<Warranty>, IWarrantyService
    {
        private readonly DatabaseContext context;
        // Constructer
        public WarrantyService(DatabaseContext Context): base(Context)
        {         
        }
    }
}
